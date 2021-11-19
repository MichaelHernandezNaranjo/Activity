import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { task, taskRequest } from '../interfaces/task';
import { environment } from '../../environments/environment';

@Injectable()
export class TaskService {
  constructor(private http: HttpClient) { }

httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'Bearer ' + localStorage.getItem('token')
  })
};

  GetAll(companyId: number, projectId: number): Observable<task[]> {
    return this.http.get<task[]>(`${environment.apiUrl}/api/Task/${companyId}/${projectId}`,this.httpOptions)
  }

  GetSprint(companyId: number, projectId: number, sprintId: number): Observable<task[]> {
    return this.http.get<task[]>(`${environment.apiUrl}/api/Task/${companyId}/${projectId}/Where=SprintId:'${sprintId}'`,this.httpOptions)
  }

  GetStatus(companyId: number, projectId: number, taskStatusId: number): Observable<task[]> {
    return this.http.get<task[]>(`${environment.apiUrl}/api/Task/${companyId}/${projectId}/Where=TaskStatusId:'${taskStatusId}'`,this.httpOptions)
  }
  

  Add(task_: task): Observable<number> {
    let request: any = {
      companyId: parseInt(localStorage.getItem("companyId") || "0"),
      taskId: task_.taskId,
      taskName: task_.taskName,
      description: task_.description,
      CreationUserId: parseInt(localStorage.getItem("userId") || "0"),
      Active: true
    };
    console.log(request);
    return this.http.post<number>(`${environment.apiUrl}/api/Task/`,request,this.httpOptions)
  }


}
