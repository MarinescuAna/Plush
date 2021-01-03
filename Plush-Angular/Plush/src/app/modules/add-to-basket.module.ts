
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
    declarations: [],
    imports: [
        CommonModule
    ]
})

export class AddToBasketModule {
    orderId: string;
    productId: string;
    quantity:string;
}