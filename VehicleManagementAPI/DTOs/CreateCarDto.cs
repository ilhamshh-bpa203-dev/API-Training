namespace VehicleManagementAPI.DTOs
{
    public class CreateCarDto
    {
        public string Brand { get; set; }
        public int Year { get; set; }    
        public int MaxSpeed { get; set; }
        public string PlateNumber { get; set; }    
        public string Model { get; set; }    
        public int DoorsCount { get; set; }    
        public double TrunkCapacity { get; set; }    
        public bool IsAutomatic { get; set; }    
        public double FuelLevel { get; set; }    
    }
}
