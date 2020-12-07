import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import{UserRegisterModule} from 'src/app/modules/user-register.module';
import { AuthService } from 'src/app/shared/auth.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  private pattern =/^([^@\s]+)@((?:[-a-z0-9]+\.)+[a-z]{2,})$/i;
  formRegister = new FormGroup({
    fullname: new FormControl('',[Validators.required]),
    birthday: new FormControl('',[Validators.required]),
    address: new FormControl('', Validators.required),
    email: new FormControl('',[Validators.required,Validators.pattern(this.pattern)]),
    phone: new FormControl('',Validators.required),
    password: new FormControl('',[Validators.required,Validators.minLength(6)]),
    passwordConfirmation: new FormControl('',[Validators.required])
  });
  hide: Boolean = true;
  hide2: Boolean = true;
  constructor( private route: Router, private service:AuthService) { }

  ngOnInit(): void {
  }

  onSubmit(): void{
    let userRegister=new UserRegisterModule();
    userRegister.fullname=this.formRegister.value.fullname;
    userRegister.birthday=this.formRegister.value.birthday;
    userRegister.address=this.formRegister.value.address;
    userRegister.email=this.formRegister.value.email;
    userRegister.password=this.formRegister.value.password;
    userRegister.phone=this.formRegister.value.phone;
    debugger
    this.service.register(userRegister);
  }
  onAccessAccount(): void{
    this.route.navigateByUrl('/login');
  }
  isMatch(): boolean{
    debugger;
    return this.formRegister.controls['password'].value!==this.formRegister.controls['passwordConfirmation'].value? true: false;
  }
}
