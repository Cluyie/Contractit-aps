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
        Task<InstallationDTO> GetInstallationById(int installationsId);
        Task<IEnumerable<InstallationDTO>> GetAllInstallationerFromKundeCprNr(int ejerKundeCprNr);
        Task<InstallationDTO> PostInstallation(int ejerKundeCprNr, [FromBody] InstallationDTO installation);
        Task<InstallationDTO> PutInstallationById(int installationsId, [FromBody] InstallationDTO installation);
        Task<bool> DeleteInstallationById(int installationsId);
    }
}
