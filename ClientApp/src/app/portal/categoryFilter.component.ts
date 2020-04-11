import { Component } from "@angular/core";
import { Repository } from '../models/repository';
import { NavigationService } from '../models/navigation.service';

@Component({
  selector: "portal-categoryfilter",
  templateUrl: "categoryFilter.component.html"
})
export class CategoryFilterComponent {

  constructor(private repo: Repository,public service:NavigationService) { }
}
