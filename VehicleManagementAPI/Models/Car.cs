using Microsoft.AspNetCore.Http.HttpResults;

namespace VehicleManagementAPI.Models
{
    public class Car : Vehicle
    {

        public int DoorsCount { get; set; }
        public double TrunkCapacity { get; set; }
        public bool IsAutomatic { get; set; }

        public Car(
            string Brand,
            string Model,
            int Year,
            int MaxSpeed,
            string PlateNumber,
            int DoorsCount,
            double TrunkCapacity,
            bool IsAutomatic
        ) : base(Brand, Model, Year, MaxSpeed, PlateNumber)
        {
            
            this.DoorsCount = DoorsCount;
            this.TrunkCapacity = TrunkCapacity;
            this.IsAutomatic = IsAutomatic;
        }

        public override string GetVehicleInfo()
        {
            return $"{ShowBasicInfo()},{MaxSpeed}km/h,{PlateNumber},{DoorsCount},{TrunkCapacity}l,Automatic gear:{IsAutomatic}";
        }
        public override string ShowBasicInfo()
        {
            return base.ShowBasicInfo();
        }

        public double CalculateFuelCost(double distance)
        {
            if (distance <= 0) return 0;

            return distance/100 * 8 * 1.5;
        }
    }   
}
