import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { CacheService } from './cache.service'
import { Observable, of } from 'rxjs'
import { switchMap } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {

  constructor(
    private http: HttpClient,
    private _cacheService: CacheService,
  ) { }

  get<T>(options: HttpOptions): Observable<T> {
    return this.httpCall(options)
  }

  private httpCall<T>(options: HttpOptions): Observable<T> {

    // Setup default values
    options.cacheMins = options.cacheMins || 0

    if (options.cacheMins > 0) {
      // Get data from cache
      const data = this._cacheService.load(options.url)
      // Return data from cache
      if (data !== null) {
        return of<T>(data)
      }
    }

    return this.http.request<T>('GET', options.url)
      .pipe(
        switchMap(response => {
          if (options.cacheMins > 0) {
            // Data will be cached
            this._cacheService.save({
              key: options.url,
              data: response,
              expirationMins: options.cacheMins
            })
          }
          return of<T>(response)
        })
      )
  }
}

export class HttpOptions {
  url: string
  cacheMins?: number
}
