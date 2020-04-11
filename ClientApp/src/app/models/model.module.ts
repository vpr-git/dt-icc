import { NgModule } from "@angular/core";
import { Repository } from "./repository";
import { NavigationService } from "./navigation.service";

@NgModule({providers:[Repository,NavigationService]})
export class ModelModule { }
