import { Injectable } from '@angular/core';
import { Employee } from './employee';

import{HttpClient} from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class EmployeeService { //create an instance of employee
  formData:Employee=new Employee();
  
  employees:Employee[];
  constructor(private httpClient:HttpClient) { }


bindEmployee(){
  this.httpClient.get(environment.apiUrl+"api/emp/GetAllEmployee")
  .toPromise().then(response=>
    this.employees=response as Employee[])

}

//insert employee
insertEmployee(employee:Employee):Observable<any>
{
  return this.httpClient.post(environment.apiUrl+"api/emp/AddEmployee",employee);

}

//update employee
updateEmployee(employee:Employee):Observable<any>
{
  return this.httpClient.put(environment.apiUrl+"api/emp/UpdateEmployee",employee);

}


//delete employee
deleteEmployee(employeeId:number):Observable<any>
{
  return this.httpClient.delete(environment.apiUrl+"api/emp/deleteEmployee?id="+employeeId);

}


//get employee by id
getEmployee(employeeId:number):Observable<any>
{
  return this.httpClient.delete(environment.apiUrl+"api/emp/GetEmployeeById?id="+employeeId);

}

}
