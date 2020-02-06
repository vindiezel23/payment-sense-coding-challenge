import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Country } from '../country-list/interfaces/country';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  countries$: Subject<Country[]> = new Subject<Country[]>();
  constructor(private httpClient: HttpClientService) { }

  public getCountries() {
    return this.httpClient.get<Country[]>({ url:'https://localhost:44341/paymentsensecodingchallenge/countries', cacheMins: 1 })
      .subscribe(data => {
        this.countries$.next(data);
      }, error => {
        console.log(error)
      });
  }
}
