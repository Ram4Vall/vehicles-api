namespace Vehicles_API.Models
{
    public class ProcessVehicleResponse
    {
        public int VehicleId { get; set; }
        public VehicleValidationResultCode ResultCode { get; set; }

        public ProcessVehicleResponse(VehicleRequest vehicleRequest)
        {
            this.VehicleId = vehicleRequest.VehicleId;
            this.ResultCode = GetCodeResult(vehicleRequest);
        }

        /// <summary>
        /// Obtain VehicleValidationResultCode from validation of string properties
        /// </summary>
        /// <param name="vehicleRequest">VehicleRequest</param>
        /// <returns>VehicleValidationResultCode</returns>
        private VehicleValidationResultCode GetCodeResult(VehicleRequest vehicleRequest)
        {
            VehicleValidationResultCode codeResult;
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
                    codeResult = VehicleValidationResultCode.Valid;
                break;

                case false:
                    codeResult = VehicleValidationResultCode.Invalid;
                break;

                default:
                    codeResult = VehicleValidationResultCode.NotSpecified;
                break;
            }
            return codeResult;
        }
    }
}
