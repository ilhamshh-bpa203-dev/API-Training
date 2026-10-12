namespace VehicleManagementAPI.DTOs
{
    public class CreateTruckDto
    {
        public string Brand { get; set; }
        public int Year { get; set; }
        public int MaxSpeed { get; set; }
        public string PlateNumber { get; set; }
        public double FuelLevel { get; set; }
        public double CargoCapacity { get; set; }
        public int AxleCount { get; set; }
        public double CurrentLoad { get; set; }

    }
}
