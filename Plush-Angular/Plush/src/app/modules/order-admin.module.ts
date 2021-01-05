import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
    declarations: [],
    imports: [
        CommonModule
    ]
})

export class OrderAdminModule {
     orderID:string;
     email:string;  
     address:string;
     phone:string;
     payment:string; 
     delivery:string; 
     remarks:string; 
     total:string;      
     orderDate:string;
}
