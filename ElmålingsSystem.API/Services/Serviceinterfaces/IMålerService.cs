using System.Threading.Tasks;
using ElmålingsSystem.API.Models;
using ElmålingsSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElmålingsSystem.API.Services
{
    public interface IMålerService
    {
        Task<MålerLinked> GetMålerByInstallationsId(int installationsId);
        Task<MålerLinked> PostMåler(int installationsId, [FromBody] MålerLinked måler);
        Task<MålerLinked> PutMålerById(int målerId, [FromBody] MålerLinked måler);
        Task<bool> DeleteMålerById(int målerId);
    }
}