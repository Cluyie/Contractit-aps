using ElmålingsSystem.API.Models;
using ElmålingsSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElmålingsSystem.API.Services
{
    public interface IInstallationService
    {
        Task<InstallationLinked> GetInstallationById(int installationsId);
        Task<IEnumerable<InstallationLinked>> GetAllInstallationerFromKundeCprNr(int ejerKundeCprNr);
        Task<InstallationLinked> PostInstallation(int ejerKundeCprNr, [FromBody] InstallationLinked installation);
        Task<InstallationLinked> PutInstallationById(int installationsId, [FromBody] InstallationLinked installation);
        Task<bool> DeleteInstallationById(int installationsId);
    }
}
