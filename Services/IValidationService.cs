using Entities.Models;

namespace Services
{
    public interface IValidationService
    {
        VehicleValidationResultCode ValidateVehicleRequest(VehicleRequest vehicleRequest);
         ProcessVehicleResponse GetProcessVehicleResponse(VehicleRequest vehicleRequest);
    }
}
