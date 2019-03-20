using Entities.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Services
{
    public interface ICsvService
    {
        byte[] GenerateCSVExport();
        List<VehicleRequest> ImportCsvVehicles(IFormFile Documento);
    }
}
