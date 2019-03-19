using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IJsonService
    {
        List<VehicleRequest> GetAllVehicles();
        void SaveVehicle(VehicleRequest vehicleRequest);
    }
}
