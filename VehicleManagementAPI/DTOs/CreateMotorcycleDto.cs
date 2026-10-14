using VehicleManagementAPI.Models;
using VehicleManagementAPI.Utilities.Enums;

namespace VehicleManagementAPI.DTOs
{
    public class CreateMotorcycleDto:BaseVehicleDto
    {
        public int EngineCapacity { get; set; }
        public MotorcycleType Type { get; set; }
        public bool HasSidecar { get; set; }


    }
}
