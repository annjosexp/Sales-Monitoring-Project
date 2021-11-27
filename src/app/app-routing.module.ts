import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { CoordinatorComponent } from './coordinator/coordinator.component';
import { EmployeeListComponent } from './employees/employee-list/employee-list.component';
import { EmployeeComponent } from './employees/employee/employee.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';

import { AuthGuard } from './shared/auth.guard';

const routes: Routes = [ 
{ path: 'login', component: LoginComponent },
{ path: 'employee', component: EmployeeComponent },

{ path: 'employeelist', component: EmployeeListComponent },
{path :'employee/:empId',component:EmployeeComponent}, //route.snapshot.params[]

{path :'home',component:HomeComponent},
{path :'admin',component:AdminComponent,canActivate:[AuthGuard],data:{role:'Admin'}},
{path :'manager',component:CoordinatorComponent, canActivate:[AuthGuard],data:{role:'Sales Coordinator'}},
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
