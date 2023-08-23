using aiico.Constants;

namespace aiico.FeeModels
{
    using System;

    public class StadiumFeeModel : IFeeModel
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
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
        }

        private decimal CalculateMotorcycleFee(TimeSpan duration)
        {
            if (duration.TotalHours < 4)
            {
                return ParkingLotConstants.FeeModelConstants.Stadium.MotorcycleInitialFee;
            }
            else
            {
                int additionalHours = (int)Math.Ceiling(duration.TotalHours) - 4;
                decimal totalFee = ParkingLotConstants.FeeModelConstants.Stadium.MotorcycleInitialFee
                                + (additionalHours * ParkingLotConstants.FeeModelConstants.Stadium.MotorcycleHourlyFee);
                return totalFee;
            }
        }

        private decimal CalculateCarSUVFee(TimeSpan duration)
        {
            if (duration.TotalHours < 4)
            {
                return ParkingLotConstants.FeeModelConstants.Stadium.CarSUVInitialFee;
            }
            else
            {
                int additionalHours = (int)Math.Ceiling(duration.TotalHours) - 4;
                decimal totalFee = ParkingLotConstants.FeeModelConstants.Stadium.CarSUVInitialFee
                                + (additionalHours * ParkingLotConstants.FeeModelConstants.Stadium.CarSUVHourlyFee);
                return totalFee;
            }
        }
    }
}
