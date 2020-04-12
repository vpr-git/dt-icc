import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VehicleSelectionComponent } from "./portal/vehicleSelection.component";
import { PageNotFoundComponent } from './portal/pageNotFound.component';

const routes: Routes = [
  { path: "admin", loadChildren: () => import("./admin/admin.module").then(m => m.AdminModule)},
  { path: "portal/:category", component: VehicleSelectionComponent },
  { path: "portal", component: VehicleSelectionComponent },
  { path: "", redirectTo: "/portal", pathMatch: "full" },
  { path: '**',  component:PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
