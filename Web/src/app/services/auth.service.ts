import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { user } from '../interfaces/user';
import { environment } from '../../environments/environment';

@Injectable()
export class AuthService {
  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'Basic ' + btoa('IhhKFcr2ng+rTnP6Wb69x4cZOAMduJ+E4tcbX7ESSd/G+vxhPa/G29mOb4Un9hgo:IhhKFcr2ng+rTnP6Wb69x4cZOAMduJ+E4tcbX7ESSd/G+vxhPa/G29mOb4Un9hgo')
    })
  };

  login(companyId: number, email: string, password: string): Observable<user> {
    return this.http.post<user>(`${environment.apiUrl}/api/Login`, {companyId: companyId, email: email, password: password})
  }

  sessionOn(_user: user){
    localStorage.setItem('companyId', _user.companyId.toString());
    localStorage.setItem('userId', _user.userId.toString());
    localStorage.setItem('userName', _user.userName);
    localStorage.setItem('email', _user.email);
    localStorage.setItem('roleId', _user.roleId.toString());
    localStorage.setItem('roleName', _user.roleName);
    localStorage.setItem('token', _user.token);
  }

  sessionOff() {
    localStorage.removeItem('companyId');
    localStorage.removeItem('userId');
    localStorage.removeItem('userName');
    localStorage.removeItem('email');
    localStorage.removeItem('roleId');
    localStorage.removeItem('roleName');
    localStorage.removeItem('token');
  }

  public get loggedIn(): boolean {
    return (localStorage.getItem('userId') !== null);
  }
}
