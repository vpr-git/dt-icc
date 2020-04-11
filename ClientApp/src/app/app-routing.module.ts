import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VehicleSelectionComponent } from "./portal/vehicleSelection.component";

const routes: Routes = [
  { path: "admin", loadChildren: () => import("./admin/admin.module").then(m => m.AdminModule)},
  { path: "portal/:category", component: VehicleSelectionComponent },
  { path: "portal", component: VehicleSelectionComponent },
  //{ path: "portal", redirectTo:"portal/",pathMatch:"full" },
  { path: "", redirectTo: "/portal", pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
