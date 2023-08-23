using aiico.FeeModels;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly ParkingLotManager _parkingLotManager;

        public ParkingController(ParkingLotManager parkingLotManager)
        {
            _parkingLotManager = parkingLotManager;
        }

        [HttpPost]
        public IActionResult ParkVehicle([FromBody] Parking parking)
        {
            var ticket = _parkingLotManager.ParkVehicle(parking);
            return Ok(ticket);
        }

        [HttpPost("unpark")]
        public IActionResult UnparkVehicle([FromBody] Ticket ticketNumber)
        {
            var receipt = _parkingLotManager.UnparkVehicle(ticketNumber);
            return Ok(receipt);
        }
        
        [HttpGet("available-parking")]
        public IActionResult AvailableParkingn()
        {
            var allAvailableSpots = _parkingLotManager.GetAllAvailableSpots();
            return Ok(allAvailableSpots);
        }
        
        [HttpGet("available-tickets")]
        public IActionResult AvailableTickets()
        {
            var allAvailableTickets = _parkingLotManager.GetAllTickets();
            return Ok(allAvailableTickets);
        }
        
        [HttpGet("reinitialize-parking")]
        public IActionResult ReinitializeParkingLot()
        {
            var allAvailableTickets = _parkingLotManager.ReinitializeParkingLot();
            return Ok(allAvailableTickets);
        }
    }
}
