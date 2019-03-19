using System;
using System.Collections.Generic;
using Entities.Models;
using Newtonsoft.Json;
using VehiclesRepository;

namespace Services
{
    public class JsonService : IJsonService
    {
        private readonly IJsonRepository JsonRepository;

        public JsonService(IJsonRepository jsonRepository)
        {
            JsonRepository = jsonRepository;
        }

        public List<VehicleRequest> GetAllVehicles()
        {
            return JsonConvert.DeserializeObject<List<VehicleRequest>>(JsonRepository.ReadFile());
        }

        public void SaveVehicle(VehicleRequest vehicleRequest)
        {
            string jsonString = JsonConvert.SerializeObject(vehicleRequest);
            JsonRepository.WriteFile(jsonString);
        }
    }
}
