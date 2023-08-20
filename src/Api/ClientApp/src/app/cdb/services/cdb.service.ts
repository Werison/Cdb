import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CdbResponse } from '../models/cdb-response.model';
import { Cdb } from '../models/cdb.model';

@Injectable({
  providedIn: 'root'
})
export class CdbService {

  constructor(private http: HttpClient) { }

  calculate(cdb: Cdb): Observable<CdbResponse> {
    return this.http.post<CdbResponse>('https://localhost:44400/cdb', cdb);
  }
}
