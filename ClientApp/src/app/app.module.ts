import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { ModelModule } from './models/model.module'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { PortalModule } from './portal/portal.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ModelModule,
    FormsModule,
    ReactiveFormsModule,
    PortalModule      
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
