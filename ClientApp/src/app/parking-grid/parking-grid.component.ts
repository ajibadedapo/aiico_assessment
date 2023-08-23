import { Component, EventEmitter, Input, Output } from '@angular/core';
import {ParkingService} from "../services/parking.service";

@Component({
  selector: 'app-parking-grid',
  templateUrl: './parking-grid.component.html'
})
export class ParkingGridComponentComponent {

  availableSpotsMap: Record<string, Record<string, number[]>> = {};

  constructor(private parkingService: ParkingService) {}

  ngOnInit(): void {
    this.getParkingSpot();
  }

  getParkingSpot() {
    this.parkingService.getAllAvailableSpots().subscribe((spotsMap) => {
      this.availableSpotsMap = spotsMap;
    });
  }
}
