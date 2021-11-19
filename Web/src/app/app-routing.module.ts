import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { AuthGuard } from './auth.guard';

import { LayoutComponent } from './components/layout/layout.component';
import { LoginComponent } from './components/views/login/login.component';
import { HomeComponent } from './components/views/home/home.component';
import { ProjectsComponent } from './components/views/projects/projects.component';
import { BacklogComponent } from './components/views/backlog/backlog.component';
import { BoardComponent } from './components/views/board/board.component';

//import { USUARIO_ROUTES } from './components/views/factura-venta/factura-venta.routers';


const routes: Routes = [
    //{ path: '**', pathMatch: 'full', redirectTo: 'Home' },
    { path: 'Login', component: LoginComponent },
    {
      path: '', component: LayoutComponent, canActivate: [AuthGuard],
      children: [
        {path: '', component: ProjectsComponent, canActivate: [AuthGuard]},
        {path: 'Home', component: ProjectsComponent, canActivate: [AuthGuard]},
       // {path: 'usuario/:id', component: FacturaVentaComponent,children: USUARIO_ROUTES },
        {path: 'Projects', component: ProjectsComponent , canActivate: [AuthGuard]},
        {path: 'Backlog', component: BacklogComponent , canActivate: [AuthGuard]},
        {path: 'Board', component: BoardComponent , canActivate: [AuthGuard]}
      ]
    }

    // { path: 'Home', component: HomeComponent },
    // { path: 'Movimientos/Ventas', component: VentasComponent }
  
  ];
  
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }