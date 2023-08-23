namespace aiico.Constants;

public static class ParkingLotConstants
{
    public enum VehicleType
    {
        Motorcycle,
        Car,
        Bus,
        Truck
    }

    public static class Location
    {
        public const string Mall = "Mall";
        public const string Stadium = "Stadium";
        public const string Airport = "Airport";
    }

    public static class InitialSpots
    {
        public static readonly Dictionary<string, Dictionary<string, List<int>>> Map = new Dictionary<string, Dictionary<string, List<int>>>
        {
            [Location.Mall] = new Dictionary<string, List<int>>
            {
                [VehicleType.Motorcycle.ToString()] = new List<int> { 1, 2, 3, 4 },
                [VehicleType.Car.ToString()] = new List<int> { 101, 102, 103, 104 },
                [VehicleType.Bus.ToString()] = new List<int> { 201, 202, 203 },
            },
            [Location.Stadium] = new Dictionary<string, List<int>>
            {
                [VehicleType.Motorcycle.ToString()] = new List<int> { 1001, 1002, 1003, 1004 },
                [VehicleType.Car.ToString()] = new List<int> { 1101, 1102, 1103, 1104 },
            },
            [Location.Airport] = new Dictionary<string, List<int>>
            {
                [VehicleType.Motorcycle.ToString()] = new List<int> { 2001, 2002, 2003, 2004 },
                [VehicleType.Car.ToString()] = new List<int> { 2101, 2102, 2103, 2104 },
                [VehicleType.Bus.ToString()] = new List<int> { 2201, 2202, 2203 },
            }
        };
    }
    
    
    public static class FeeModelConstants
    {
        public static class Airport
        {
            public const decimal MotorcycleHourlyFee = 5;
            public const decimal CarSUVHourlyFee = 10;
            public const decimal BusTruckHourlyFee = 15;
        }
        
        public static class Mall
        {
            public const decimal MotorcycleHourlyFee = 7;
            public const decimal CarSUVHourlyFee = 9;
            public const decimal BusTruckHourlyFee = 11;
        }
        public static class Stadium
        {
            public const decimal MotorcycleInitialFee = 30;
            public const decimal MotorcycleHourlyFee = 100;
            public const decimal CarSUVInitialFee = 60;
            public const decimal CarSUVHourlyFee = 200;
        }
    }
}
