import { Repository } from '../models/repository';
import { Component } from '@angular/core';
import { AuthenticationService } from '../auth/authentication.service';

@Component({templateUrl:"admin.component.html"})
export class AdminComponent {
  constructor(private repo: Repository,public authService:AuthenticationService) {
    //this.repo.filter.reset();
    //this.repo.getVehicles();
  }
}





























