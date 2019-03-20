using System.Collections.Generic;
using System.Linq;
using Entities.Models;
using Newtonsoft.Json;
using VehiclesRepository;

namespace Services
{
    public class JsonService : IJsonService
    {
        private readonly IJsonRepository JsonRepository;
        private readonly IValidationService ValidationService;

        public JsonService(IJsonRepository jsonRepository, IValidationService validationService)
        {
            JsonRepository = jsonRepository;
            ValidationService = validationService;
        }

        public List<VehicleRequest> GetAllVehicles()
        {
            return JsonConvert.DeserializeObject<List<VehicleRequest>>(JsonRepository.ReadFile());
        }

        public void SaveVehicle(VehicleRequest vehicleRequest)
        {
            List<VehicleRequest> currentVehicles = GetAllVehicles();

            currentVehicles.Add(vehicleRequest);

            string jsonString = JsonConvert.SerializeObject(currentVehicles);
            JsonRepository.WriteFile(jsonString);
        }

        public void SaveUpdateVehicle(VehicleRequest vehicleRequest)
        {
            List<VehicleRequest> currentVehicles = GetAllVehicles();
            VehicleRequest vehicle = currentVehicles.FirstOrDefault(x => x.VehicleId == vehicleRequest.VehicleId);

            if (vehicle == null)
            {
                currentVehicles.Add(vehicleRequest);
            }
            else
            {
                int index = currentVehicles.FindIndex(x => x.VehicleId == vehicleRequest.VehicleId);
                currentVehicles[index] = vehicleRequest;
            }

            string jsonString = JsonConvert.SerializeObject(currentVehicles);
            JsonRepository.WriteFile(jsonString);
        }

        public void SaveList(List<VehicleRequest> vehicles)
        {
            foreach (VehicleRequest vehicle in vehicles)
            {
                SaveVehicle(vehicle);
            }
        }

    }
}
