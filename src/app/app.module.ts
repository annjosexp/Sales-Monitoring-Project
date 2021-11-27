import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';
import { EmployeeComponent } from './employees/employee/employee.component';
import { EmployeeListComponent } from './employees/employee-list/employee-list.component';
import { VisitComponent } from './visits/visit/visit.component';
import { VisitListComponent } from './visits/visit-list/visit-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { NgxPaginationModule } from 'ngx-pagination';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {AuthGuard} from './shared/auth.guard';
import { AuthService } from './shared/auth.service';
import { AuthInterceptor } from './shared/auth.interceptor';
import {EmployeeService} from './shared/employee.service';
import {VisitService} from './shared/visit.service';
import { CoordinatorComponent } from './coordinator/coordinator.component'

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    AdminComponent,
    EmployeeComponent,
    EmployeeListComponent,
    VisitComponent,
    VisitListComponent,
    CoordinatorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(),
    NgxPaginationModule,
    Ng2SearchPipeModule,
    ReactiveFormsModule
  ],
  providers: [EmployeeService,VisitService,AuthGuard,AuthService,
    {
      provide:HTTP_INTERCEPTORS,
      useClass:AuthInterceptor,
      multi:true
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
