import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
//import { CustomCurrencyPipeModule } from "../models/customCurrencyPipeModule"
import { AdminComponent } from './admin.component';
import { FileUploadComponent } from "./fileupload.component";
import { UserAdminComponent } from "./useradmin.component";
import { CommonModule } from '@angular/common';
import { AuthModule } from '../auth/auth.module';
import { AuthenticationComponent } from '../auth/authentication.component';
import { AuthenticationGuard } from '../auth/authentication.guard';


const routes: Routes = [
  { path: "login", component: AuthenticationComponent },
  {
    path: "", component: AdminComponent,
    canActivateChild:[AuthenticationGuard],
    children: [
      { path: "users", component: UserAdminComponent },
      { path: "upload", component: FileUploadComponent },
      {path:"", component:FileUploadComponent}
    ]
  }
];


@NgModule({
  imports: [RouterModule, FormsModule,RouterModule.forChild(routes),CommonModule,AuthModule],
  declarations: [
    AdminComponent, FileUploadComponent, UserAdminComponent]
})
export class AdminModule { }
