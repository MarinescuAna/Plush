
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})

export class UserRegisterModule {
    fullname: string; 
    email   : string;
    password: string; 
    phone   : string;
    address : string;
    birthday: string;
}
