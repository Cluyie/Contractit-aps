using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ElmålingsSystem.API.Models;
using ElmålingsSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ElmålingsSystem.API.Services
{
    public class DefaultMåleVærdierService : IMåleVærdierService
    {
        private readonly MålingContext _context;
        private readonly IConfigurationProvider _mappingConfiguration;

        public DefaultMåleVærdierService(MålingContext context, IConfigurationProvider mappingConfiguration)
        {
            _context = context;
            _mappingConfiguration = mappingConfiguration;
        }

        public async Task<IEnumerable<MåleVærdierLinked>> GetAllMåleVærdierFromMålerIdAndDate(int målerId, DateTime start, DateTime end)
        {
            
            var måleVærdier = _context.Måleværdier
                .Where((m => m.Måler.MålerId.Equals(målerId) &&
                m.AflæsningDatoTid >= start &&
                m.AflæsningDatoTid < end)).ProjectTo<MåleVærdierLinked>(_mappingConfiguration);

            if (måleVærdier == null) return null;

            return await måleVærdier.ToArrayAsync();
        }
    }
}
