import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { company } from '../interfaces/company';
import { environment } from '../../environments/environment';

@Injectable()
export class CompanyService {
  constructor(private http: HttpClient) { }



  GetAll(): Observable<company[]> {
    return this.http.get<company[]>(`${environment.apiUrl}/api/Company`)
  }


}
