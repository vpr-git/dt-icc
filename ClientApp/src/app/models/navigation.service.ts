import { Injectable } from "@angular/core";
import { Router, ActivatedRoute, NavigationEnd } from "@angular/router";
import { Repository } from '../models/repository';
import { filter } from "rxjs/operators";

@Injectable()
export class NavigationService {

  constructor(private repository: Repository, private router: Router,
    private active: ActivatedRoute) {
    router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe(ev => this.handleNavigationChange());
  }

  private handleNavigationChange() {
    let active = this.active.firstChild.snapshot;
    if (active.url.length > 0 && active.url[0].path === "portal") {
      let category = active.params["category"];
      this.repository.filter.category = category || "All";
      this.repository.getVehicles();
    }
  }

  get categories(): string[] {
    return this.repository.categories;
  }

  get currentCategory(): string {
    return this.repository.filter.category || "All";
  }

  set currentCategory(newCategory: string) {
    this.router.navigateByUrl(`/portal/${(newCategory || "").toLowerCase()}`);
  }

}
