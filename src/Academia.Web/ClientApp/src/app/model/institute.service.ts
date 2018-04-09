import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { catchError, map, tap } from 'rxjs/operators';

import { Institute } from './institute';

@Injectable()
export class InstituteService {

  readonly instituteUrl = 'api/institute';

  constructor(private http: HttpClient) { }

  getInstitutes(): Observable<Institute[]> {
    return this.http.get<Institute[]>(this.instituteUrl)
      .pipe(
      tap(institutes => this.log(`fetched institutes`)),
      catchError(this.handleError(`getInstitutes`))
      ) as Observable<Institute[]>;
  }

  /**
   * Returns a function that handles Http operation failures.
   * This error handler lets the app continue to run as if no error occurred.
   * @param operation - name of the operation that failed
   */
  private handleError<T>(operation = 'operation') {
    return (error: HttpErrorResponse): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      const message = (error.error instanceof ErrorEvent) ?
        error.error.message :
        `server returned code ${error.status} with body "${error.error}"`;

      // TODO: better job of transforming error for user consumption
      throw new Error(`${operation} failed: ${message}`);
    };

  }

  private log(message: string) {
    console.log('InstituteService: ' + message);
  }

}
