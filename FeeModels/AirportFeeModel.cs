using aiico.Constants;

namespace aiico.FeeModels
{
    using System;

    public class AirportFeeModel : IFeeModel
    {
        public decimal CalculateFee(DateTime entryTime, DateTime exitTime, string vehicleType)
        {
            TimeSpan parkingDuration = exitTime - entryTime;
            return CalculateFeeBasedOnDuration(parkingDuration, vehicleType);
        }

        private decimal CalculateFeeBasedOnDuration(TimeSpan duration, string vehicleType)
        {
            switch (vehicleType)
            {
                case "Motorcycle":
                    return CalculateMotorcycleFee(duration);
                case "Car":
                case "SUV":
                    return CalculateCarSUVFee(duration);
                case "Bus":
                case "Truck":
                    return CalculateBusTruckFee(duration);
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
        }

        private decimal CalculateMotorcycleFee(TimeSpan duration)
        {
            int hours = (int)Math.Ceiling(duration.TotalHours);
            decimal totalFee = hours * ParkingLotConstants.FeeModelConstants.Airport.MotorcycleHourlyFee;
            return totalFee;
        }

        private decimal CalculateCarSUVFee(TimeSpan duration)
        {
            int hours = (int)Math.Ceiling(duration.TotalHours);
            decimal totalFee = hours * ParkingLotConstants.FeeModelConstants.Airport.CarSUVHourlyFee;
            return totalFee;
        }

        private decimal CalculateBusTruckFee(TimeSpan duration)
        {
            int hours = (int)Math.Ceiling(duration.TotalHours);
            decimal totalFee = hours * ParkingLotConstants.FeeModelConstants.Airport.BusTruckHourlyFee;
            return totalFee;
        }
    }
}