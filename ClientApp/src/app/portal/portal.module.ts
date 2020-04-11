import { NgModule } from "@angular/core";
import { BrowserModule } from '@angular/platform-browser';
import { CategoryFilterComponent } from "./categoryFilter.component";
import { VehicleSelectionComponent } from './vehicleSelection.component';
import { VehicleListComponent } from './vehicleList.component';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { CustomCurrencyPipeModule } from "../models/customCurrencyPipeModule"
import { RouterModule } from "@angular/router";

@NgModule({
  declarations: [CategoryFilterComponent, VehicleListComponent, VehicleSelectionComponent, CustomCurrencyPipeModule],
  imports: [BrowserModule, RouterModule],
  exports: [VehicleSelectionComponent,HttpClientModule]
})
export class PortalModule { }
