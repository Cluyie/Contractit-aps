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
        Task<EjerKundeDTO> GetEjerKundeByCpr(int ejerKundeCprNr);
        Task<IEnumerable<EjerKundeDTO>> GetAllEjerKunder();
        Task<EjerKundeDTO> PostEjerKunde([FromBody] EjerKundeDTO ejerKunde);
        Task<EjerKundeDTO> PutEjerKundeById(int ejerKundeId, [FromBody] EjerKundeDTO ejerKunde);
        Task<bool> DeleteEjerKundeByCpr(int ejerKundeCprNr);
    }
}
