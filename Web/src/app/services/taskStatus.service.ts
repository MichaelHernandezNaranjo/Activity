import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { taskStatus, taskStatusRequest } from '../interfaces/taskStatus';
import { environment } from '../../environments/environment';

@Injectable()
export class TaskStatusService {
  constructor(private http: HttpClient) { }

httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'Bearer ' + localStorage.getItem('token')
  })
};

  GetAll(companyId: number, projectId: number): Observable<taskStatus[]> {
    return this.http.get<taskStatus[]>(`${environment.apiUrl}/api/TaskStatus/${companyId}/${projectId}`,this.httpOptions)
  }
  

  Add(taskStatus_: taskStatus): Observable<number> {
    let request: any = {
      companyId: parseInt(localStorage.getItem("companyId") || "0"),
      taskStatusId: taskStatus_.taskStatusId,
      taskStatusName: taskStatus_.taskStatusName,
      CreationUserId: parseInt(localStorage.getItem("userId") || "0"),
      Active: true
    };
    console.log(request);
    return this.http.post<number>(`${environment.apiUrl}/api/TaskStatus/`,request,this.httpOptions)
  }


}
