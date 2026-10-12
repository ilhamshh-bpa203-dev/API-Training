namespace VehicleManagementAPI.DTOs
{
    public class FuelCostResponseDto
    {
        public int VehicleId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Distance { get; set; }
        public double FuelConsumption { get; set; }
        public double FuelPrice { get; set; }
        public double TotalCost { get; set; }
    }
}
