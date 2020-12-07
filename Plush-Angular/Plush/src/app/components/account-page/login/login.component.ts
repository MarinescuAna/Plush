import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import{UserLoginModule} from'src/app/modules/user-login.module';
import { AuthService } from 'src/app/shared/auth.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  private pattern =/^([^@\s]+)@((?:[-a-z0-9]+\.)+[a-z]{2,})$/i;
  formLogin = new FormGroup({
    email: new FormControl('',[Validators.required,Validators.pattern(this.pattern)]),
    password: new FormControl('',[Validators.required,Validators.minLength(6)])
  });
  hide: Boolean = true;
  constructor(private route:Router, private service: AuthService) { }

  ngOnInit(): void {
  }

  onSubmit(): void{
    debugger
    let userLogin= new UserLoginModule();
    userLogin.email=this.formLogin.value.email;
    userLogin.password=this.formLogin.value.password;
    this.service.login(userLogin);
  }

  onCreateAccount(): void{
    this.route.navigateByUrl('/register');
  }
}
