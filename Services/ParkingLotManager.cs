using aiico.Constants;
using aiico.FeeModels;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Services;

using System;
using System.Collections.Generic;

    public class ParkingLotManager
    {
        private Dictionary<string, IFeeModel> _feeModelByLocation;
        private List<string> _vehicleTypes;
        private List<Ticket> _tickets;
        private int _ticketCounter = 1;
        private Dictionary<string, Dictionary<string, List<int>>> _availableSpotsMap = new Dictionary<string, Dictionary<string, List<int>>>();
        
        public ParkingLotManager()
        {
            _availableSpotsMap = ParkingLotConstants.InitialSpots.Map;

            _feeModelByLocation = new Dictionary<string, IFeeModel>
            {
                { "Mall", new MallFeeModel() },
                { "Stadium", new StadiumFeeModel() },
                { "Airport", new AirportFeeModel() }
            };
     
            _vehicleTypes = new List<string>
            {
                ParkingLotConstants.VehicleType.Motorcycle.ToString(),
                ParkingLotConstants.VehicleType.Car.ToString(),
                ParkingLotConstants.VehicleType.Bus.ToString(),
                ParkingLotConstants.VehicleType.Truck.ToString(),
            };


            _tickets = new List<Ticket>();
        }

        public Ticket  ParkVehicle(Parking parking)
        {
            if (!_feeModelByLocation.ContainsKey(parking.Location))
            {
                return (null!);
            }
    
            if (!_vehicleTypes.Contains(parking.VehicleType))
            {
                return (null!);
            }

            int spotNumber = FindAvailableSpot(parking.Location, parking.VehicleType);

            if (spotNumber == 0)
            {
                Ticket noticket = new Ticket
                {
                    TicketNumber = 0,
                    SpotNumber = 0,
                    EntryDateTime = DateTime.Now,
                    Vehicle = parking.VehicleType,
                    Location = parking.Location
                };

                return noticket;
            }


            Ticket ticket = new Ticket
            {
                TicketNumber = _ticketCounter++,
                SpotNumber = spotNumber,
                EntryDateTime = DateTime.Now,
                Vehicle = parking.VehicleType,
                Location = parking.Location
            };


            _tickets.Add(ticket);
            Console.WriteLine(ticket.Vehicle);

            return ticket;
        }

        public Receipt UnparkVehicle(Ticket ticketObj)
        {
            Ticket? ticket = _tickets.Find(t => t.TicketNumber == ticketObj.TicketNumber);
            if (ticket == null)
            {
                return new Receipt
                {
                    ErrorMessage = "Invalid ticket number."
                };
            }

            if (ticket.Vehicle != null)
            {
                AddSpot(ticket.Location, ticket.Vehicle, ticket.SpotNumber);
                _tickets.Remove(ticket);

            }


            DateTime exitTime = DateTime.Now;
            decimal fee = ticket?.Location != null
                ? CalculateFee(ticket, exitTime)
                : 0; 

            Receipt receipt = new Receipt
            {
                ReceiptNumber = ticket?.TicketNumber ?? throw new InvalidOperationException("Ticket is null."),
                EntryDateTime = ticket?.EntryDateTime ?? throw new InvalidOperationException("Ticket is null."),
                ExitDateTime = exitTime,
                Fee = fee,
                Location = ticket.Location
            };

            return receipt;
        }

        private int FindAvailableSpot(string location, string vehicleType)
        {

            List<int> availableSpots = GetAvailableSpotsForLocation(location, vehicleType);

            if (availableSpots.Count > 0)
            {
                int spotNumber = availableSpots[0];
                availableSpots.RemoveAt(0);
                UpdateAvailableSpotsForLocation(location, vehicleType, availableSpots);

                return spotNumber;
            }
            else
            {
                return 0;
            }
        }
        
        

        private List<int> GetAvailableSpotsForLocation(string location, string vehicleType)
        {
            if (_availableSpotsMap.TryGetValue(location, out var locationSpots)
                && locationSpots.TryGetValue(vehicleType, out var availableSpots))
            {
                return availableSpots;
            }

            return new List<int>();
        }
        
        public Dictionary<string, Dictionary<string, List<int>>> GetAllAvailableSpots()
        {
            return _availableSpotsMap;
        }   
        
        public List<Ticket> GetAllTickets()
        {
            return _tickets;
        }

        public void AddSpot(string location, string vehicleType, int spotNumber)
        {
            if (!_availableSpotsMap.ContainsKey(location))
            {
                _availableSpotsMap[location] = new Dictionary<string, List<int>>();
            }

            if (!_availableSpotsMap[location].ContainsKey(vehicleType))
            {
                _availableSpotsMap[location][vehicleType] = new List<int>();
            }

            _availableSpotsMap[location][vehicleType].Add(spotNumber);
        }


        private void UpdateAvailableSpotsForLocation(string location, string vehicleType, List<int> availableSpots)
        {

            Dictionary<string, Dictionary<string, List<int>>> locationSpotsMap = new Dictionary<string, Dictionary<string, List<int>>>();


            if (!locationSpotsMap.ContainsKey(location))
            {
                locationSpotsMap[location] = new Dictionary<string, List<int>>();
            }


            if (!locationSpotsMap[location].ContainsKey(vehicleType))
            {
                locationSpotsMap[location][vehicleType] = new List<int>();
            }


            locationSpotsMap[location][vehicleType] = availableSpots;
            
        }



        private decimal CalculateFee(Ticket ticket, DateTime exitTime)
        {
            IFeeModel? feeModel = ticket.Location != null ? _feeModelByLocation[ticket.Location] : null;
            if (feeModel == null)
            {
                throw new InvalidOperationException("Invalid Location.");
            }

            return feeModel.CalculateFee(ticket.EntryDateTime, exitTime, ticket.Vehicle ?? throw new ArgumentNullException(nameof(ticket.Vehicle)));
        }

        public List<Ticket> ReinitializeParkingLot()
        {
            _availableSpotsMap = new Dictionary<string, Dictionary<string, List<int>>>(ParkingLotConstants.InitialSpots.Map);

            _tickets.Clear();
            _ticketCounter = 1;
            return _tickets;
        }

        
    }
