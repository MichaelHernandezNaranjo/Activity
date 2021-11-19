import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { CompanyService } from '../../../services/company.service';
import { Router } from '@angular/router';
import { company } from 'src/app/interfaces/company';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private _auth: AuthService, private _company: CompanyService, private router: Router) { }
  
  lstCompany: company[] | null = null;

  items:string[]=["hola","que","tal","estas"];

  ngOnInit(): void {
    console.log("ngOnInit");
    this._company.GetAll().subscribe(
      result => {
        console.log(result);
        this.lstCompany = result;
      },
      error => {
       console.error(error.message);
      }
    );
  }

  email: string = "";
  password: string = "";
  companyId: number = 0;

  onClick(){
    this._auth.login(this.companyId, this.email, this.password)
      .subscribe(
        result => {
            this._auth.sessionOn(result);
            this.router.navigate(['Home'])
        },
        error =>  {
          this.password = "";
          console.error(error.message)
        }
      );
  }


}
