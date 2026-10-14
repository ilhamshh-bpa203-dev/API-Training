namespace VehicleManagementAPI.Models
{
    public class Motorcycle : Vehicle
    {
        public int EngineCapacity { get; set; }
        public bool HasSidecar { get; set; }
        public string Type { get; set; }

        public Motorcycle(
            string Brand,
            string Model,
            int Year,
            int MaxSpeed,
            string PlateNumber,
            int EngineCapacity,
            string Type,
            bool HasSidecar
        ) : base(Brand, Model, Year, MaxSpeed, PlateNumber)
        {

            this.EngineCapacity = EngineCapacity;
            this.Type = Type;
            this.HasSidecar = HasSidecar;
        }
        public override string GetVehicleInfo()
        {
           return $"{ShowBasicInfo()},{MaxSpeed}km/h,{PlateNumber},{EngineCapacity}cc,{Type},Has Sidecar:{HasSidecar}}}";
        }

        public double CalculateFuelCost(double distance)
        {
            if (distance <= 0) return 0;

            return distance / 100 * 4 * 1.5;
        }
    }
}
