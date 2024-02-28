import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { WelcomePageComponent } from './welcome-page/welcome-page.component';
import { SharedModule } from 'src/shared/shared.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { QuotesListComponent } from './quotes-list/quotes-list.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ShipperShipmentDetailsComponent } from './dashboard/shipper-shipment-details/shipper-shipment-details.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    WelcomePageComponent,
    QuotesListComponent,
    DashboardComponent,
    ShipperShipmentDetailsComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    SharedModule,
    FontAwesomeModule,
    NgbModule,
    RouterModule.forRoot([
      { path: '', component: WelcomePageComponent, pathMatch: 'full' },
      { path: 'shippers-dashboard', component: DashboardComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
