import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private _auth: AuthService, private router: Router) { }

  ngOnInit(): void {
  }

  sessionOff(){
    this._auth.sessionOff();
    this.router.navigate(['Login'])
  }
    userId: string | null = localStorage.getItem('userId');
    userName: string | null = localStorage.getItem('userName');
    email: string | null = localStorage.getItem('email');
    roleName: string | null = localStorage.getItem('roleName');


  

}
