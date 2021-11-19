import { Component,ViewChild, OnInit } from '@angular/core';
import {DayPilot, DayPilotKanbanComponent} from "daypilot-pro-angular";
import { TaskService } from '../../../services/task.service';
import { TaskStatusService } from '../../../services/taskStatus.service';
import { task } from 'src/app/interfaces/task';
import { taskStatus } from 'src/app/interfaces/taskStatus';


@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit {

  
  @ViewChild("kanban") kanban: DayPilotKanbanComponent;

  constructor(private _task: TaskService, private _taskStatus: TaskStatusService) {
  }

  cards: any[] = [];

  columns: any[] = [];

  ngOnInit(): void {
    this.Consultar();
    
    // this.config.columns = this.columns;
    // this.config.cards = this.cards;
    // this.cards.push({id: 7, name: "name 7", column: "1", text: "This is a description of task #7.", barColor: "#F6B26B"});

  }

  config: any = {
    columnWidthSpec: "Fixed",
    cellMarginBottom: 40,
    onCardMoved: function (args: any) {
      alert("Moved");
      console.log(args);
    },
    onCardClick: function (args: any) {
      alert("Click");
      console.log(args);
    }
  };

  companyId: number = parseFloat(localStorage.getItem('companyId') || "0");
  lstTask: task[];
  Consultar(){
    this._taskStatus.GetAll(this.companyId,1).subscribe(
      result => {
        this.columns = result.map(function(_taskStatus: taskStatus){
          return  {name: _taskStatus.taskStatusName, id: _taskStatus.taskStatusId}
        });
        this.config.columns = this.columns;
        console.log('COL',this.columns);
      },
      error => {
       console.error(error.message);
      }
    );

    this._task.GetSprint(this.companyId,1,1).subscribe(
      result => {
        this.cards = result.map(function(_task: task){
          return  {id: _task.taskId, "name": _task.taskName, column: _task.taskStatusId, text: _task.description, barColor: "#F6B26B"};
        });
        this.config.cards = this.cards;
        console.log('COL',this.cards);
      },
      error => {
       console.error(error.message);
      }
    );

  }

  
  


  ngAfterViewInit(): void {

  }

  add(): void {
    var name = prompt("New card name:", "Task");
    if (!name) {
        return;
    }
    
  }

 

}
