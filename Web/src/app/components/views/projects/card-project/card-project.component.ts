import { Component, OnInit, Input } from '@angular/core';
import { project, projectUser } from 'src/app/interfaces/project';
import { TagModel } from 'ngx-chips/core/accessor';
import { ProjectService } from 'src/app/services/project.service';
import { userReponse } from 'src/app/interfaces/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-card-project',
  templateUrl: './card-project.component.html',
  styleUrls: ['./card-project.component.css']
})


export class CardProjectComponent implements OnInit {

  editar: boolean = false;

  @Input() project: project;
  @Input() users: userReponse[];

  lstUser: projectUser[] = [{ userId: 4, userName: "prueba" }];
  constructor(private _project: ProjectService, private router: Router) {
    
   }

  ngOnInit(): void {
    console.log("llege",this.project)
    if(this.project.projectId == 0){
      this.editar = true;
    }
    // this.project.listProjectUser?.forEach();
    // this.lstUser = this.project.listProjectUser?.values;
  }

  onAdding(item: any){
    console.log("change",item);
  }

  Seleccionar(project_: project){
    localStorage.setItem('projectId', project_.projectId.toString());
    localStorage.setItem('projectName', project_.projectName);
    this.router.navigate(['Backlog'])
  }

  Guardar(project_: project){
    this.editar = false;
    console.log("guardar:",this.lstUser);
    if(project_.projectId == 0){
      this._project.Add(project_).subscribe(
      result => {
        if(result){
         // this.Consultar();
        }else{
          alert('error')
        }
      },
      error => {
       console.error(error.message);
      }
    );
    }else{
      this._project.Update(project_).subscribe(
        result => {
          if(result){
            alert('ok')
          }else{
            alert('error')
          }
        },
        error => {
         console.error(error.message);
        }
      );
    }
  }

  

}
