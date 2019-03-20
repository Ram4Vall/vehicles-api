using Entities.Models;
using System.Collections.Generic;

namespace Services
{
    public interface IJsonService
    {
        List<VehicleRequest> GetAllVehicles();
        void SaveVehicle(VehicleRequest vehicleRequest);
        void SaveUpdateVehicle(VehicleRequest vehicleRequest);
        void SaveList(List<VehicleRequest> vehicles);
    }
}
