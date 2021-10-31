using ElmålingsSystem.API.Models;
using ElmålingsSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElmålingsSystem.API.Services
{
    public interface IEjerKundeService
    {
        Task<EjerKundeLinked> GetEjerKundeByCpr(int ejerKundeCprNr);
        Task<IEnumerable<EjerKundeLinked>> GetAllEjerKunder();
        Task<EjerKundeLinked> PostEjerKunde([FromBody] EjerKundeLinked ejerKunde);
        Task<EjerKundeLinked> PutEjerKundeById(int ejerKundeId, [FromBody] EjerKundeLinked ejerKunde);
        Task<bool> DeleteEjerKundeByCpr(int ejerKundeCprNr);
    }
}
