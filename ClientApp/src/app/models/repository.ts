import { Vehicle } from "./vehicle.model";
import { Injectable } from '@angular/core';
import { Filter } from "./configClasses.repository";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";


const vehicelsURL = "/api/vehicles";

type vehiclesMetadata = {
  data: Vehicle[],
  categories: string[]
}

@Injectable()
export class Repository {
  vehicle: Vehicle;
  vehicles: Vehicle[];
  isFileUploaded: boolean;
  filter: Filter = new Filter();
  categories: string[] = [];
  constructor(private http: HttpClient) {
    //this.getVehicles();
  }

  getVehicles() {

    let url = `${vehicelsURL}`;
     if (this.filter.category) {
      url += `?category=${this.filter.category}`;
    }    
    url += "&metadata=true";
    this.http.get<vehiclesMetadata>(url)
      .subscribe(response => { this.vehicles = response.data; this.categories = response.categories });
  }


  login(name: string, password: string): Observable<boolean> {
    return this.http.post<boolean>("/api/account/login", { name: name, password: password });
    
  }

  logout() {
    this.http.post("/api/account/logout", null).subscribe( response=> {});
  }
  
}
