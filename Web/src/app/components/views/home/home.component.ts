import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../../../services/project.service';
import { project } from 'src/app/interfaces/project';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  //lstProject: project[]  = [];
  //lstProject: any[]  = ['1','2'];
  //lstProject:string[]=["hola","que","tal","estas"];
  items:string[]=["hola","que","tal","estas"];

  constructor(private _project: ProjectService) { }
  companyId: number = parseFloat(localStorage.getItem('companyId') || "0");
  ngOnInit(): void {
    this._project.GetAll(this.companyId).subscribe(
      result => {
        console.log(result);
        //this.lstProject = result;
      },
      error => {
       console.error(error.message);
      }
    );
  }

}
