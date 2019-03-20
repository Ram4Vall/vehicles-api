namespace Entities.Models
{
    public class ProcessVehicleResponse
    {
        public int VehicleId { get; set; }
        public VehicleValidationResultCode ResultCode { get; set; }

        public ProcessVehicleResponse(int vehicleId, VehicleValidationResultCode vehicleValidationResultCode)
        {
            VehicleId = vehicleId;
            ResultCode = vehicleValidationResultCode;
        }

        public ProcessVehicleResponse()
        {

        }
    }
}
