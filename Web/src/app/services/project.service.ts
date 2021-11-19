import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { project, projectRequest } from '../interfaces/project';
import { environment } from '../../environments/environment';

@Injectable()
export class ProjectService {
  constructor(private http: HttpClient) { }

httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'Basic ' + btoa('IhhKFcr2ng+rTnP6Wb69x4cZOAMduJ+E4tcbX7ESSd/G+vxhPa/G29mOb4Un9hgo:IhhKFcr2ng+rTnP6Wb69x4cZOAMduJ+E4tcbX7ESSd/G+vxhPa/G29mOb4Un9hgo')
  })
};

  GetAll(companyId: number): Observable<project[]> {
    return this.http.get<project[]>(`${environment.apiUrl}/api/Project/${companyId}`,this.httpOptions)
  }
  
  Update(project_: project): Observable<boolean> {
    let arrayUsers:any[] = [];
    project_.listProjectUser?.forEach( function(v,i){
      arrayUsers.push({userId: v.userId});
    });
    let request: any = {
      companyId: project_.companyId,
      projectId: project_.projectId,
      projectName: project_.projectName,
      description: project_.description,
      Active: true,
      ListProjectUser: project_.listProjectUser
    };
    console.log("pot:",request);
    return this.http.put<boolean>(`${environment.apiUrl}/api/Project/`,request,this.httpOptions)
  }

  Add(project_: project): Observable<number> {
    let request: any = {
      companyId: parseInt(localStorage.getItem("companyId") || "0"),
      projectId: project_.projectId,
      projectName: project_.projectName,
      description: project_.description,
      CreationUserId: parseInt(localStorage.getItem("userId") || "0"),
      Active: true
    };
    console.log(request);
    return this.http.post<number>(`${environment.apiUrl}/api/Project/`,request,this.httpOptions)
  }


}
