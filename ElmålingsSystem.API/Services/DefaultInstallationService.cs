using AutoMapper;
using AutoMapper.QueryableExtensions;
using ElmålingsSystem.API.Models;
using ElmålingsSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElmålingsSystem.API.Services
{
    public class DefaultInstallationService : IInstallationService
    {
        private readonly MålingContext _context;
        private readonly IConfigurationProvider _mappingConfiguration;

        public DefaultInstallationService(MålingContext context, IConfigurationProvider mappingConfiguration)
        {
            _context = context;
            _mappingConfiguration = mappingConfiguration;
        }

        public async Task<InstallationLinked> GetInstallationById(int installationsId)
        {
            //search in Installation(db), if there's a 'installation' with an InstallationsId, equal to installationsId
            var installation = await _context.Installationer.SingleOrDefaultAsync(m => m.InstallationsId == installationsId);

            if (installation == null) return null;

            //returns a mapped InstallationVM, with attributes from Installation
            var mapper = _mappingConfiguration.CreateMapper();

            return  mapper.Map<InstallationLinked>(installation);
        }

        public async Task<IEnumerable<InstallationLinked>> GetAllInstallationerFromKundeCprNr(int kundeCprNr)
        {
            var installationer = _context.Installationer.Where(i => i.EjerKunde.CprNr.Equals(kundeCprNr)).ProjectTo<InstallationLinked>(_mappingConfiguration);

            if (!installationer.Any())
            {
                installationer = _context.Installationer.Where(i => i.LejerKunde.CprNr.Equals(kundeCprNr)).ProjectTo<InstallationLinked>(_mappingConfiguration);
            }

            if (!installationer.Any()) return null;

            return await installationer.ToArrayAsync();
        }

        public async Task<InstallationLinked> PostInstallation(int ejerKundeCprNr, [FromBody] InstallationLinked installation)
        {
            var ejerKunde = await _context.EjerKunder.FirstOrDefaultAsync(e => e.CprNr == ejerKundeCprNr);
            if (ejerKunde == null) return null;

            var mapper = _mappingConfiguration.CreateMapper();

            var nyInstallation = mapper.Map<Installation>(installation);
            nyInstallation.EjerKundeFK = ejerKunde.KundeId;


            _context.Installationer.Add(nyInstallation);
            await _context.SaveChangesAsync();

            var mappedInstallation = await GetInstallationById(nyInstallation.InstallationsId);
            return mappedInstallation;
        }

        public async Task<InstallationLinked> PutInstallationById(int installationsId, [FromBody]InstallationLinked installation)
        {
            //var kunde = await _context.EjerKunder.SingleOrDefaultAsync(k => k.CprNr == ejerKundeCprNr);
            var kunde = await _context.EjerKunder.FirstOrDefaultAsync(k => k.Installationer.FirstOrDefault(i => i.InstallationsId == installationsId).InstallationsId.Equals(installationsId));
            if (kunde == null) return null;

            var mapper = _mappingConfiguration.CreateMapper();
            var editedInstallation = mapper.Map<Installation>(installation);

            editedInstallation.EjerKundeFK = kunde.KundeId;
            editedInstallation.InstallationsId = installationsId;


            _context.Update(editedInstallation).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var mappedInstallation = await GetInstallationById(editedInstallation.InstallationsId);
            return mappedInstallation;
        }

        public async Task<bool> DeleteInstallationById(int installationsId)
        {
            var installation = await _context.Installationer.SingleOrDefaultAsync(m => m.InstallationsId == installationsId);
            if (installation == null) return false;

            _context.Installationer.Remove(installation);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
