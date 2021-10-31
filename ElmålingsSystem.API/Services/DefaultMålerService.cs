using AutoMapper;
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
    public class DefaultMålerService : IMålerService
    {
        private readonly MålingContext _context;
        private readonly IConfigurationProvider _mappingConfiguration;

        public DefaultMålerService(MålingContext context, IConfigurationProvider mappingConfiguration)
        {
            _context = context;
            _mappingConfiguration = mappingConfiguration;
        }

        public async Task<MålerLinked> GetMålerByInstallationsId(int installationsId)
        {
            //search in Måler(db), if there's a 'Måler' with a MålerId, equal to målerId
            var måler = await _context.Måler.SingleOrDefaultAsync(m => m.Installation.InstallationsId == installationsId);

            if (måler == null) return null;

            //returns a mapped MålerVM, with attributes from Måler
            var mapper = _mappingConfiguration.CreateMapper();

            return mapper.Map<MålerLinked>(måler);
        }

        public async Task<MålerLinked> PostMåler(int installationsId, [FromBody] MålerLinked måler)
        {
            var installation = await _context.Installationer.FirstOrDefaultAsync(i => i.InstallationsId == installationsId);
            if (installation == null) return null;

            var mapper = _mappingConfiguration.CreateMapper();

            var nyMåler = mapper.Map<Måler>(måler);
            nyMåler.InstallionFK = installation.InstallationsId;

            _context.Måler.Add(nyMåler);
            await _context.SaveChangesAsync();

            var mappedMåler = await GetMålerByInstallationsId(nyMåler.MålerId);

            return mappedMåler;
        }

        public async Task<MålerLinked> PutMålerById(int målerId, [FromBody] MålerLinked måler)
        {
            var installation = await _context.Installationer.SingleOrDefaultAsync(k => k.Måler.MålerId.Equals(målerId));
            if (installation == null) return null;

            var mapper = _mappingConfiguration.CreateMapper();
            var editedMåler = mapper.Map<Måler>(måler);

            editedMåler.InstallionFK = installation.InstallationsId;
            editedMåler.MålerId = målerId;

            _context.Update(editedMåler).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var mappedMåler = await GetMålerByInstallationsId(editedMåler.MålerId);
            return mappedMåler;
        }     

        public async Task<bool> DeleteMålerById(int målerId)
        {
            var måler = await _context.Måler.SingleOrDefaultAsync(m => m.MålerId == målerId);
            if (måler == null) return false;

            _context.Måler.Remove(måler);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
