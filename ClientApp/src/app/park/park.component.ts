import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import {ParkingService} from "../services/parking.service";
import { ParkingGridComponentComponent } from '../parking-grid/parking-grid.component';

@Component({
  selector: 'app-park',
  templateUrl: './park.component.html'
})
export class ParkComponent {

  @ViewChild(ParkingGridComponentComponent, { static: false })
  parkingGridComponent: any;
  
  parkingInfo: any;

  vehicleType: string = 'Motorcycle';
  location: string = 'Mall';
  requestState = true;


  constructor(private parkingService: ParkingService) {}

  parkVehicle() {
    
    this.parkingService.parkVehicle({
      vehicleType:  this.vehicleType,
      location:  this.location,
    }).subscribe((res: any) => {
      this.vehicleType = 'Motorcycle';
      this.parkingInfo=res;
      this.parkingGridComponent.getParkingSpot();
    });
  }
}
