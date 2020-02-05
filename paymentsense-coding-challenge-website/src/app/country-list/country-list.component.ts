import { Component, OnInit, OnDestroy } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { Observable, Subscription } from 'rxjs';
import { Country } from './interfaces/country';
import { CountryService } from '../services/countryservice';
import { MatTableDataSource, MatSort } from '@angular/material';
import { DataSource } from '@angular/cdk/table';

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class CountryListComponent implements OnInit {
  dataSource = new MatTableDataSource<Country>();
  countriesData$: Subscription;
  columnsToDisplay: string[] = ['flag', 'name'];
  constructor(private _countryService: CountryService) {

  }

  ngOnInit() {
    this.countriesData$ = this._countryService.countries$.subscribe(data => {
      if (data) {
        this.dataSource.data = data;
      }
    });
    this._countryService.getCountries();
  }

  ngOnDestroy() {
    this.countriesData$.unsubscribe();
  }
}




