import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})

export class UserInformationModule {
    address   : string;
    remarks: string; 
    delivery: string; 
    payment: string; 
    phone: string; 
}
