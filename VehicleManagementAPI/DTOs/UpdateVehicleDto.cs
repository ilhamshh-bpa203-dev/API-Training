namespace VehicleManagementAPI.DTOs
{
    public class UpdateVehicleDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int MaxSpeed { get; set; }
        public string PlateNumber { get; set; }
        public double FuelLevel { get; set; }
    }
}
