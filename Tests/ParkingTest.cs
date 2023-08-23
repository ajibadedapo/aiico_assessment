using System;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Controllers;
using Services;
using Models;

namespace Tests
{
    public class ParkingControllerTests
    {
        [Fact]
        public void ParkVehicle_ValidInput_ReturnsOkResult()
        {
            var parkingLotManagerMock = new Mock<ParkingLotManager>();
            var controller = new ParkingController(parkingLotManagerMock.Object);
            var vehicle = new Parking() { VehicleType = "Motorcycle", Location = "Mall" };

            var result = controller.ParkVehicle(vehicle);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UnparkVehicle_ValidTicketNumber_ReturnsOkResult()
        {
            var parkingLotManagerMock = new Mock<ParkingLotManager>();
            var controller = new ParkingController(parkingLotManagerMock.Object);
            var ticket = new Ticket { TicketNumber = 1 }; 

            var result = controller.UnparkVehicle(ticket); 

            Assert.IsType<OkObjectResult>(result);
        }

    }
}