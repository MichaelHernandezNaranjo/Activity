import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { CompanyService } from '../../../services/company.service';
import { Router } from '@angular/router';
import { company } from 'src/app/interfaces/company';
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private _auth: AuthService, private _company: CompanyService, private router: Router, private spinner: NgxSpinnerService, private toastr: ToastrService) { }
 
  lstCompany: company[] | null = null;

  ngOnInit(): void {
    this.spinner.show();
    console.log("ngOnInit");
    this._company.GetAll().subscribe(
      result => {
        console.log(result);
        this.lstCompany = result;
        this.spinner.hide();
      },
      err => {
       this.spinner.hide();
       this.toastr.error(err.message);
      }
    );
  }

  email: string = "";
  password: string = "";
  companyId: number = 0;

  onClick(){
    this.spinner.show();
    this._auth.login(this.companyId, this.email, this.password)
      .subscribe(
        result => {
            this.toastr.success('Hello world!', 'Toastr fun!');
            this._auth.sessionOn(result);
            this.router.navigate(['Home']);
            this.spinner.hide();
        },
        err =>  {
          this.password = "";
          this.spinner.hide();
          this.toastr.error(err.message);
        }
      );
  }


}
