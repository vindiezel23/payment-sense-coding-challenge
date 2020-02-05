import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PaymentsenseCodingChallengeApiService } from './services';
import { HttpClientModule } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MatTableModule } from '@angular/material';
import { MatCardModule } from '@angular/material/card';
import { MatPaginatorModule } from '@angular/material/paginator';
import { CountryListComponent } from './country-list/country-list.component';

@NgModule({
  declarations: [
    AppComponent,
    CountryListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FontAwesomeModule,
    MatTableModule,
    MatCardModule,
    MatPaginatorModule
  ],
  providers: [PaymentsenseCodingChallengeApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
