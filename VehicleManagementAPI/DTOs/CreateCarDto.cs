namespace VehicleManagementAPI.DTOs
{
    public class CreateCarDto:BaseVehicleDto
    {
        public string Model { get; set; }
        public int DoorsCount { get; set; }    
        public double TrunkCapacity { get; set; }    
        public bool IsAutomatic { get; set; }    
    }
}
