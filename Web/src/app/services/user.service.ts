import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { user, userRequest, userReponse } from '../interfaces/user';
import { environment } from '../../environments/environment';

@Injectable()
export class UserService {
  constructor(private http: HttpClient) { }

httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'Basic ' + btoa('IhhKFcr2ng+rTnP6Wb69x4cZOAMduJ+E4tcbX7ESSd/G+vxhPa/G29mOb4Un9hgo:IhhKFcr2ng+rTnP6Wb69x4cZOAMduJ+E4tcbX7ESSd/G+vxhPa/G29mOb4Un9hgo')
  })
};

  GetAll(companyId: number): Observable<userReponse[]> {
    return this.http.get<userReponse[]>(`${environment.apiUrl}/api/User/${companyId}`,this.httpOptions)
  }
  
  Update(user_: userRequest): Observable<boolean> {
    let request: any = {
      companyId: parseInt(localStorage.getItem("companyId") || "0"),
      userId: user_.userId,
      userName: user_.userName,
      roleId: user_.roleId,
      CreationUserId: 0,
      Active: true
    };
    console.log(request);
    return this.http.put<boolean>(`${environment.apiUrl}/api/User/`,request,this.httpOptions)
  }

  Add(user_: user): Observable<number> {
    let request: any = {
      companyId: parseInt(localStorage.getItem("companyId") || "0"),
      userId: user_.userId,
      userName: user_.userName,
      roleId: user_.roleId,
      CreationUserId: parseInt(localStorage.getItem("userId") || "0"),
      Active: true
    };
    console.log(request);
    return this.http.post<number>(`${environment.apiUrl}/api/User/`,request,this.httpOptions)
  }


}
