import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../shared/user';
import { AuthService } from '../shared/auth.service';
import { Jwtresponse } from '../shared/jwtresponse';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  //decalre variables
  loginForm!: FormGroup;
  isSubmitted = false;
  loginUser: User = new User();
  error = '';
  jwtResponse: any = new Jwtresponse;
  constructor(private formBuilder: FormBuilder, private router: Router, private authService: AuthService) { }

  ngOnInit(): void {
    //FormGroup

    this.loginForm = this.formBuilder.group(
      {
        UserName: ['', [Validators.required, Validators.minLength(2)]],
        UserPassword: ['', [Validators.required]]

      }
    );

  }
  //get controls
  get formControls() {
    return this.loginForm.controls;
  }

  //login verify credentials
  loginCredentials() {
    //valid or invalid
    this.isSubmitted = true;
    console.log(this.loginForm.value);

    //invalid
    if (this.loginForm.invalid) {
      return;
    }

    //valid
    if (this.loginForm.valid) {
      //calling method from Authservice -Authorization
      this.authService.loginVerify(this.loginForm.value).subscribe(data => {
        console.log(data);
        //token with usertypeand name
        this.jwtResponse = data;

        //either in local or session
        sessionStorage.setItem("jwtToken", this.jwtResponse.token);

        //check the usertype -- based on it redirect our application
        if (this.jwtResponse.UserType === 'Admin') {
          //logged as Admin
          console.log("Admin");
          localStorage.setItem("username", this.jwtResponse.UserName);
          localStorage.setItem("ACCESS_ROLE", this.jwtResponse.UserType);
          sessionStorage.setItem("userpassword", this.jwtResponse.UserName);
          this.router.navigateByUrl('/admin');
        }
        else if (this.jwtResponse.UserType === 'Sales Coordinator') {
          //logged as manager
          console.log("Sales Coordinator");
          localStorage.setItem("username", this.jwtResponse.UserName);
          localStorage.setItem("ACCESS_ROLE", this.jwtResponse.UserType);
          sessionStorage.setItem("userpassword", this.jwtResponse.UserName);
          this.router.navigateByUrl('/coordinator');
        }
        
        else {
          this.error = "sorry.. Invalid authorized role..This module is not authorized"
        }
      },
        error => {
          this.error = "Invalid user name or password.. try again.."
        });


    }

  }



}

