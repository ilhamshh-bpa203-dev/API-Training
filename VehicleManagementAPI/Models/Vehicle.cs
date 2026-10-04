using System.Data;

namespace VehicleManagementAPI.Models
{
    public abstract class Vehicle
    {

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int MaxSpeed { get; set; }
        public string PlateNumber { get; set; }
        public double FuelLevel { get; set; } = 100;
        public DateTime CreatedAt { get; set; }

        protected Vehicle(string Brand,string Model, int Year, int MaxSpeed, string PlateNumber)
        {
            this.Brand = Brand;
            this.Model = Model;
            this.Year = Year;
            this.MaxSpeed = MaxSpeed;
            this.PlateNumber = PlateNumber;
        }

        public abstract string GetVehicleInfo();

        public virtual string ShowBasicInfo()
        {
            return $"{Brand},{Model},{Year}";
        }
    }
}
