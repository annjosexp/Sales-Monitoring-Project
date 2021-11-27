import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from 'src/app/shared/employee';
import { EmployeeService } from 'src/app/shared/employee.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  
    empId:number;
    employee: Employee = new Employee();
    constructor(public empService: EmployeeService,private toxterService: ToastrService, private router :Router, 
      private route :ActivatedRoute  ) { }
  
    ngOnInit(): void {
      
  
  
      //get empId from Activated route
      this.empId = this.route.snapshot.params['empId'];
  
      if (this.empId !=0 || (this.empId!=null)) {}
      
      //getEmployee
      this.empService.getEmployee(this.empId).subscribe(
        data => {
          console.log(data);
         
        },
        error => console.log(error)
      );
    }
    onSubmit(form: NgForm) {
  
      console.log(form.value);
      let addId=this.empService.formData.EmpId;
  //insert
  
  if(addId==0||addId==null)
  {
    this.insertEmployee(form);
    //window.location.reload();
  
  }
  //update
  else{
  
    console.log("update");
    this.updateEmployee(form);
  
  }
  
    }
  
    //clear all content at initialisation
  
    resetform(form?: NgForm) {
      if (form != null) {
        form.resetForm();
      }
    }
  
  //insert employee
  insertEmployee(form?:NgForm)
  {
    console.log("inserting employee...")
    this.empService.insertEmployee(form.value).subscribe(
      (result)=>
      {
        console.log("result"+result);
        this.resetform(form);
        this.toxterService.success('Employee details Inserted!', 'succes!');
      }
    );
    window.location.reload();
  }
  //update employee
  
  updateEmployee(form?:NgForm)
  {
    console.log("updating employee...")
    this.empService.updateEmployee(form.value).subscribe(
      (result)=>
      {
        console.log("result"+result);
        this.resetform(form);
        this.toxterService.success('Employee details Updated!', 'succes!');
        
      }
    );
    window.location.reload();
  }
  }
  
  
  