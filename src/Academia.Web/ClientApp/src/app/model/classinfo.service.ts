import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { catchError, map, tap } from 'rxjs/operators';

import { ClassInfo } from './classInfo';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class ClassinfoService {

  readonly classInfoUrl = 'api/classinfos';

  constructor(private http: HttpClient) { }

  getClassInfos(): Observable<ClassInfo[]> {
    return this.http.get<ClassInfo[]>(this.classInfoUrl)
      .pipe(
      tap(classinfo => this.log(`fetched class infos`)),
      catchError(this.handleError(`getClassInfos`))
      ) as Observable<ClassInfo[]>;
  }

  getClassInfo(id: string): Observable<ClassInfo> {
    const url = `${this.classInfoUrl}/?id=${id}`;
    return this.http.get<ClassInfo>(url)
      .pipe(
        map(classInfo => classInfo[0]),
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} classInfo id=${id}`);
        }),
        catchError(this.handleError<ClassInfo>(`getClassInfo id=${id}`))
      );
  }

  addClassInfo(classInfo: ClassInfo): Observable<ClassInfo> {
    return this.http.post<ClassInfo>(this.classInfoUrl, classInfo, httpOptions)
      .pipe(
      tap((classInfo: ClassInfo) => this.log(`added classInfo w/ id=${classInfo.id}`)),
      catchError(this.handleError(`addClassInfo`))
      ) as Observable<ClassInfo>;
  }

  deleteClassInfo(classInfo: ClassInfo): Observable<ClassInfo> {
    const url = `${this.classInfoUrl}/${classInfo.id}`;

    return this.http.delete<ClassInfo>(url, httpOptions).pipe(
      tap(_ => this.log(`delete classInfo id=${classInfo.id}`)),
      catchError(this.handleError<ClassInfo>('deleteClassInfo'))
    );
  }

  updateClassInfo(classInfo: ClassInfo): Observable<any> {
    const url = `${this.classInfoUrl}/${classInfo.id}`;
    return this.http.put(url, classInfo, httpOptions).pipe(
      tap(_ => this.log(`update classinfo id=${classInfo.id}`)),
      catchError(this.handleError<any>('updateClassInfo'))
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
    console.log('ClassInfoService: ' + message);
  }

}
