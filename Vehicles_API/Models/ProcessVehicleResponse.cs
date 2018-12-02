namespace Vehicles_API.Models
{
    public class ProcessVehicleResponse
    {
        public int VehicleId { get; set; }
        public VehicleValidationResultCode ReturnCode { get; set; }

        public ProcessVehicleResponse(VehicleRequest vehicleRequest)
        {
            this.VehicleId = vehicleRequest.VehicleId;
            this.ReturnCode = GetCodeResult(vehicleRequest);
        }

        private VehicleValidationResultCode GetCodeResult(VehicleRequest vehicleRequest)
        {
            string codeResult = "";
            bool validateProperties = true;

            if ((vehicleRequest.Type == null || vehicleRequest.Type.Length == 0) 
                || (vehicleRequest.ManufacturerNameShort == null 
                    || vehicleRequest.ManufacturerNameShort.Length == 0))
            {
                validateProperties = false;
            }

            switch (validateProperties)
            {
                case true:
                    codeResult = "Valid";
                break;

                case false:
                    codeResult = "Invalid";
                break;

                default:
                    codeResult = "NotSpecified";
                break;
            }
            return new VehicleValidationResultCode(codeResult);
        }
    }
}
