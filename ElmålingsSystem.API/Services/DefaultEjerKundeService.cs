using AutoMapper;
using AutoMapper.QueryableExtensions;
using ElmålingsSystem.API.Models;
using ElmålingsSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElmålingsSystem.API.Services
{
    public class DefaultEjerKundeService : IEjerKundeService
    {
        private readonly MålingContext _context;
        private readonly IConfigurationProvider _mappingConfiguration;

        public DefaultEjerKundeService(MålingContext context, IConfigurationProvider mappingConfiguration)
        {
            _context = context;
            _mappingConfiguration = mappingConfiguration;
        }

        public async Task<EjerKundeLinked> GetEjerKundeByCpr(int ejerKundeCprNr)
        {
            //search in EjerKunder(db), if there's a 'Ejerkunde' with a CprNr, equal to ejerKundeCprNr
            var ejerKunde = await _context.EjerKunder.SingleOrDefaultAsync(e => e.CprNr == ejerKundeCprNr);

            if (ejerKunde == null) return null;

            //returns a mapped EjerKundeVM, with attributes from ejerKunde
            //var mappedEjerKunde = _mapper.Map<EjerKundeVM>(ejerKunde);
            var mapper = _mappingConfiguration.CreateMapper();
            return mapper.Map<EjerKundeLinked>(ejerKunde);
        }

        public async Task<IEnumerable<EjerKundeLinked>> GetAllEjerKunder()
        {
            var ejerKunder = _context.EjerKunder.ProjectTo<EjerKundeLinked>(_mappingConfiguration);

            //return _ignore.GetAllModelsWtihIgnoredNullValues(ejerKunder);
            return await ejerKunder.ToArrayAsync();
        }


        public async Task<EjerKundeLinked> PostEjerKunde([FromBody] EjerKundeLinked ejerKunde)
        {
            //maps an 'EjerKunde' with values from EjerkundeVM
            var mapper = _mappingConfiguration.CreateMapper();
            var nyEjerKunde = mapper.Map<EjerKunde>(ejerKunde);

            //saves new 'EjerKunde' to db
            _context.EjerKunder.Add(nyEjerKunde);
            await _context.SaveChangesAsync();

            //returns the newly created 'Ejerkunde' back as an 'EjerKundeVM'
            var mappedEjerKunde = await GetEjerKundeByCpr(nyEjerKunde.CprNr);
            return mappedEjerKunde;
        }

        public async Task<EjerKundeLinked> PutEjerKundeById(int ejerKundeId, [FromBody]EjerKundeLinked ejerkunde)
        {
            //maps an 'EjerKunde' with values from EjerkundeVM
            var mapper = _mappingConfiguration.CreateMapper();
            var editedEjerKunde = mapper.Map<EjerKunde>(ejerkunde);

            editedEjerKunde.KundeId = ejerKundeId;

            //saves the edited 'EjerKunde' to db
            _context.Update(editedEjerKunde).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            //returns the newly edited 'Ejerkunde' back as an 'EjerKundeVM'
            var mappedEjerKunde = await GetEjerKundeByCpr(editedEjerKunde.CprNr);
            //return _ignore.GetModelWithIgnoredNullValues(mappedEjerKunde);
            return mappedEjerKunde;
        }

        public async Task<bool> DeleteEjerKundeByCpr(int ejerKundeCprNr)
        {
            var ejerKunde = await _context.EjerKunder.SingleOrDefaultAsync(m => m.CprNr == ejerKundeCprNr);

            if (ejerKunde == null)
            {
                return false;
            }

            _context.EjerKunder.Remove(ejerKunde);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
 