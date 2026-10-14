namespace VehicleManagementAPI.DTOs
{
    public class CreateTruckDto:BaseVehicleDto
    {
        public double CargoCapacity { get; set; }
        public int AxleCount { get; set; }
        public double CurrentLoad { get; set; }

    }
}
