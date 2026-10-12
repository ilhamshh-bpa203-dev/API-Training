namespace VehicleManagementAPI.DTOs
{
    public class VehicleStatisticsDto
    {
        public int TotalVehicles { get; set; }
        public int CarsCount { get; set; }
        public int MotorcyclesCount { get; set; }
        public int TrucksCount { get; set; }
        public double AverageMaxSpeed { get; set; }
        public string FastestVehicle { get; set; }
        public string MostExpensiveFuelVehicle { get; set; }
        public double TotalCurrentLoad { get; set; }
    }
}
