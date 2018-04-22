import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { catchError, map, tap } from 'rxjs/operators';

import { Institute } from './institute';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

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

  getInstitute(id: string): Observable<Institute> {
    const url = `${this.instituteUrl}/?id=${id}`;
    return this.http.get<Institute>(url)
      .pipe(
        map(institute => institute[0]),
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} institute id=${id}`);
        }),
        catchError(this.handleError<Institute>(`getInstitute id=${id}`))
      );
  }

  addInstitute(institute: Institute): Observable<Institute> {
    return this.http.post<Institute>(this.instituteUrl, institute, httpOptions)
      .pipe(
      tap((institute: Institute) => this.log(`added institute w/ id=${institute.id}`)),
      catchError(this.handleError(`addInstitute`))
      ) as Observable<Institute>;
  }

  deleteInstitute(institute: Institute): Observable<Institute> {
    const url = `${this.instituteUrl}/${institute.id}`;

    return this.http.delete<Institute>(url, httpOptions).pipe(
      tap(_ => this.log(`delete institute id=${institute.id}`)),
      catchError(this.handleError<Institute>('deleteInstitute'))
    );
  }

  updateInstitute(institute: Institute): Observable<any> {
    const url = `${this.instituteUrl}/${institute.id}`;
    return this.http.put(url, institute, httpOptions).pipe(
      tap(_ => this.log(`update institute id=${institute.id}`)),
      catchError(this.handleError<any>('updateInstitute'))
    );
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
