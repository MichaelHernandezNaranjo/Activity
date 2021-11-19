import { Component, OnInit } from '@angular/core';
import { TaskService } from '../../../services/task.service';
import { task } from 'src/app/interfaces/task';

@Component({
  selector: 'app-backlog',
  templateUrl: './backlog.component.html',
  styleUrls: ['./backlog.component.css']
})
export class BacklogComponent implements OnInit {

  companyId: number = parseFloat(localStorage.getItem('companyId') || "0");
  projectId: number = parseFloat(localStorage.getItem('projectId') || "0");
  projectName: string | null = localStorage.getItem('projectName');
  constructor(private _task: TaskService) { }

  task_: task;

  ngOnInit(): void {
    this._task.GetStatus(this.companyId,this.projectId,1).subscribe(
      result => {
        console.log(result);
        this.task_ = result[0];
      },
      error => {
       console.error(error.message);
      }
    );
  }

}
