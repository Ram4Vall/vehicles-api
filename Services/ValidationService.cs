using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ValidationService : IValidationService
    {

        /// <summary>
        /// Obtain VehicleValidationResultCode from validation of string properties
        /// </summary>
        /// <param name="vehicleRequest">VehicleRequest</param>
        /// <returns>VehicleValidationResultCode</returns>
        public VehicleValidationResultCode ValidateVehicleRequest(VehicleRequest vehicleRequest)
        {
            VehicleValidationResultCode codeResult;
            bool validateProperties = true;

            if ((string.IsNullOrEmpty(vehicleRequest.Type.Trim())) || 
                (string.IsNullOrEmpty(vehicleRequest.ManufacturerNameShort.Trim())))
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

        public ProcessVehicleResponse GetProcessVehicleResponse(VehicleRequest vehicleRequest)
        {
            return new ProcessVehicleResponse(vehicleRequest.VehicleId, ValidateVehicleRequest(vehicleRequest));
        }
    }
}
