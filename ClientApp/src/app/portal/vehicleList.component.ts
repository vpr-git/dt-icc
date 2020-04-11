import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Vehicle } from "../models/vehicle.model";

@Component({
  selector: "portal-vehicle-list",
  templateUrl: "vehicleList.component.html"
})
export class VehicleListComponent {

  constructor(private repo: Repository) { }

  get vehicles(): Vehicle[] {
   return this.repo.vehicles;
    
  }
}
