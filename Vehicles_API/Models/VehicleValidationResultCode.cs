using System;

namespace Vehicles_API.Models
{
    public class VehicleValidationResultCode
    {
        public string ResultCode { get; set; }

        public VehicleValidationResultCode(string resultCode)
        {
            this.ResultCode = resultCode;
        }


    }
}
