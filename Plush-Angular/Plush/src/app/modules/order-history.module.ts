import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
    declarations: [],
    imports: [
        CommonModule
    ]
})

export class OrderHistoryModule {
     orderID:string;
     deliveryDate:string;  
     orderDate:string;
     statusOrder:string;
     payment:string; 
     address:string; 
     remarks:string; 
     deliveryType:string; 
     deliveryPrice:string; 
     totalPrice:string;      
}
