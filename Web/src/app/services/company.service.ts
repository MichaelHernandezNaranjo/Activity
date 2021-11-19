import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { company } from '../interfaces/company';
import { environment } from '../../environments/environment';

@Injectable()
export class CompanyService {
  constructor(private http: HttpClient) { }

httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'Basic ' + btoa('IhhKFcr2ng+rTnP6Wb69x4cZOAMduJ+E4tcbX7ESSd/G+vxhPa/G29mOb4Un9hgo:IhhKFcr2ng+rTnP6Wb69x4cZOAMduJ+E4tcbX7ESSd/G+vxhPa/G29mOb4Un9hgo')
  })
};

  GetAll(): Observable<company[]> {
    return this.http.get<company[]>(`${environment.apiUrl}/api/Company`,this.httpOptions)
  }


}
