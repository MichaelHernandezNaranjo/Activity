import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { TagInputModule } from 'ngx-chips';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';

import { LayoutModule } from './components/layout/layout.module';
import { LoginComponent } from './components/views/login/login.component';

import { AuthGuard } from './auth.guard';
import { AuthService } from './services/auth.service';
import { CompanyService } from './services/company.service';
import { ProjectService } from './services/project.service';
import { SprintService } from './services/sprint.service';
import { TaskService } from './services/task.service';
import { TaskStatusService } from './services/taskStatus.service';
import { UserService } from './services/user.service';
import { TableComponent } from './components/utilities/table/table.component';
import { ProjectsComponent } from './components/views/projects/projects.component';
import { CardProjectComponent } from './components/views/projects/card-project/card-project.component';
import { TruncatePipe } from './pipes/truncate.pipe';
import { BoardComponent } from './components/views/board/board.component';
import { BacklogComponent } from './components/views/backlog/backlog.component';

import { DayPilotModule } from 'daypilot-pro-angular';
//import {DayPilot, DayPilotKanbanComponent} from "daypilot-pro-angular";



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    TableComponent,
    ProjectsComponent,
    CardProjectComponent,
    TruncatePipe,
    BoardComponent,
    BacklogComponent
  ],
  imports: [
    BrowserModule,
    LayoutModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    TagInputModule,
    BrowserAnimationsModule,
    DayPilotModule
  ],
  providers: [
    AuthGuard,
    AuthService,
    CompanyService,
    ProjectService,
    SprintService,
    TaskService,
    TaskStatusService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
