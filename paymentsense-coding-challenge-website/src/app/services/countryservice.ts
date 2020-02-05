import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Country } from '../country-list/interfaces/country';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  countries$: Subject<Country[]> = new Subject<Country[]>();
  constructor(private httpClient: HttpClient) { }

  public getCountries() {
    return this.httpClient.get<Country[]>('https://localhost:44341/paymentsensecodingchallenge/countries')
      .subscribe(data => {
        this.countries$.next(data);
      }, error => {
        console.log(error)
      });
  }
}
