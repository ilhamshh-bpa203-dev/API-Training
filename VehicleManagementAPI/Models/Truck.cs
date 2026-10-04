namespace VehicleManagementAPI.Models
{
    public class Truck : Vehicle
    {


        public double CargoCapacity { get; set; }
        public int AxleCount { get; set; }
        public double CurrentLoad { get; set; }


        public Truck(
           string Brand,
           string Model,
           int Year,
           int MaxSpeed,
           string PlateNumber,
           double CargoCapacity,
           int AxleCount,
           double CurrentLoad
        ) : base(Brand, Model, Year, MaxSpeed, PlateNumber)
        {

            this.CargoCapacity = CargoCapacity;
            this.AxleCount = AxleCount;
            this.CurrentLoad = CurrentLoad;
        }
        public override string GetVehicleInfo()
        {
            return $"{ShowBasicInfo()},{MaxSpeed}km/h,{PlateNumber},{CargoCapacity}T,{AxleCount},{CurrentLoad}T";

        }

        public double LoadCargo(double weight)
        {
            if(weight <= 0) weight = 0 ;

            if(CurrentLoad + weight <= CargoCapacity)
            {
                CurrentLoad = +weight;
                return CurrentLoad;
            }
            else
            {
                return CurrentLoad;
            }
        }

        public double CalculateFuelCost(double distance)
        {
            return distance/100 * (25+ CurrentLoad*2) * 1.8 ;
        }
    }
}
