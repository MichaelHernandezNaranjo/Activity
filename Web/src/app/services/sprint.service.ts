import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { sprint, sprintRequest } from '../interfaces/sprint';
import { environment } from '../../environments/environment';

@Injectable()
export class SprintService {
  constructor(private http: HttpClient) { }

httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'Basic ' + btoa('IhhKFcr2ng+rTnP6Wb69x4cZOAMduJ+E4tcbX7ESSd/G+vxhPa/G29mOb4Un9hgo:IhhKFcr2ng+rTnP6Wb69x4cZOAMduJ+E4tcbX7ESSd/G+vxhPa/G29mOb4Un9hgo')
  })
};

  GetAll(companyId: number, projectId: number): Observable<sprint[]> {
    return this.http.get<sprint[]>(`${environment.apiUrl}/api/Sprint/${companyId}/${projectId}`,this.httpOptions)
  }
  

  Add(sprint_: sprint): Observable<number> {
    let request: any = {
      companyId: parseInt(localStorage.getItem("companyId") || "0"),
      sprintId: sprint_.sprintId,
      sprintName: sprint_.sprintName,
      description: sprint_.description,
      CreationUserId: parseInt(localStorage.getItem("userId") || "0"),
      Active: true
    };
    console.log(request);
    return this.http.post<number>(`${environment.apiUrl}/api/Sprint/`,request,this.httpOptions)
  }


}
