namespace VehicleManagementAPI.DTOs
{
    public class CreateMotorcycleDto
    {
        public string Brand { get; set; }
        public int Year { get; set; }
        public int MaxSpeed { get; set; }
        public string PlateNumber { get; set; }
        public double FuelLevel { get; set; }
        public int EngineCapacity { get; set; }
        public string Type { get; set; }
        public bool HasSidecar { get; set; }


    }
}
