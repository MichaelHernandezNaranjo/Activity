import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../../../services/project.service';
import { UserService } from '../../../services/user.service';
import { project } from 'src/app/interfaces/project';
import { userReponse } from 'src/app/interfaces/user';
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {

  constructor(private _project: ProjectService, private _user: UserService, private spinner: NgxSpinnerService, private toastr: ToastrService) { }

  editar: boolean;
  lstProject: project[]  = [];
  lstUser: userReponse[];

   companyId: number = parseFloat(localStorage.getItem('companyId') || "0");
  ngOnInit(): void {
    this.Consultar();
  }

  Consultar(){
    this.spinner.show();
    this._project.GetAll(this.companyId).subscribe(
      result => {
        console.log(result);
        this.lstProject = result;
        this.spinner.hide();
      },
      err => {
       this.toastr.error(err.message);
       this.spinner.hide();
      }
    );
    this._user.GetAll(this.companyId).subscribe(
      result => {
        console.log(result);
        this.lstUser = result;
      },
      err => {
        this.toastr.error(err.message);
        this.spinner.hide();
      }
    );
  }

  Nuevo(){
    let aux = this.lstProject;
    this.lstProject = [];
    this.lstProject.push({
      companyId: this.companyId,
      projectId: 0,
      projectName: "Nuevo proyecto",
      description: null,
      creationDate: new Date(),
      listProjectUser: null
    });
    //this.lstProject.concat(aux);
    this.lstProject.push.apply(this.lstProject, aux);
    // this._project.Add(project_).subscribe(
    //   result => {
    //     if(result){
    //       alert('ok')
    //       this.Consultar();
    //     }else{
    //       alert('error')
    //     }
    //   },
    //   error => {
    //    console.error(error.message);
    //   }
    // );  
  }

}
