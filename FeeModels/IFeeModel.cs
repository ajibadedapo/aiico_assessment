namespace aiico.FeeModels;

using System;

public interface IFeeModel
{
    decimal CalculateFee(DateTime entryTime, DateTime exitTime, String vehicleType);
}

