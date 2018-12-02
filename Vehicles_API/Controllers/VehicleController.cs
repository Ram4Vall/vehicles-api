using Microsoft.AspNetCore.Mvc;
using Vehicles_API.Models;

namespace Vehicles_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
        [HttpGet]
        public VehicleRequest get()
        {
            return new VehicleRequest();
        }

        [HttpPost]
        [Route("ProcessVehicle")]
        public ProcessVehicleResponse ProcessVehicle(VehicleRequest vehicleRequest)
        {
            return new ProcessVehicleResponse(vehicleRequest);
        }
    }
}
