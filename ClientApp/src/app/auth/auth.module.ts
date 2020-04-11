import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AuthenticationComponent } from './authentication.component';
import { AuthenticationService } from './authentication.service';
import { AuthenticationGuard } from './authentication.guard';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [RouterModule, FormsModule, CommonModule],
  declarations: [AuthenticationComponent],
  providers: [AuthenticationService, AuthenticationGuard],
  exports:[AuthenticationComponent]
})
export class AuthModule { }
