using ElmålingsSystem.API.Models;
using ElmålingsSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElmålingsSystem.API.Services
{
    public interface ILejerKundeService
    {
        Task<LejerKundeLinked> GetLejerKundeByCpr(int lejerKundeCprNr);
        Task<IEnumerable<LejerKundeLinked>> GetAllLejerKunder();
        Task<LejerKundeLinked> PostLejerKunde(int installationsId, [FromBody]LejerKundeLinked lejerKunde);
        Task<LejerKundeLinked> PutLejerKundeById(int lejerKundeId, LejerKundeLinked lejerKunde);
        Task<bool> DeleteLejerKundeByCpr(int lejerKundeCprNr);
    }
}
