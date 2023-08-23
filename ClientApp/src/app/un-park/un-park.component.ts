import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import {ParkingService} from "../services/parking.service";
import { ParkingGridComponentComponent } from '../parking-grid/parking-grid.component';

@Component({
  selector: 'app-unpark',
  templateUrl: './un-park.component.html'
})
export class UnParkComponent implements OnInit {

  @ViewChild(ParkingGridComponentComponent, { static: false })
  parkingGridComponent: any;

  ticketNumber: any;
  receiptInfo: any;
  requestState = true;
  availableTicketNumbers: any;
  ticketsStatus: boolean = false;

  constructor(private parkingService: ParkingService) {}

  ngOnInit(): void {
    this.getParkingTickets();
  }

  getParkingTickets(): void {
    this.parkingService.getAvailableTicketNumber().subscribe((tickets) => {
      this.availableTicketNumbers = tickets;
      if (tickets.length === 0) this.ticketsStatus = true;
    });
  }

  unparkVehicle() {
    this.parkingService.unparkVehicle({ticketNumber: this.ticketNumber}).subscribe((receipt) => {
      this.ticketNumber = null;
      this.receiptInfo = receipt;
      this.requestState = true;
      this.parkingGridComponent.getParkingSpot();
      this.getParkingTickets();
    });
  }
}
