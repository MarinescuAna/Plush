import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
    declarations: [],
    imports: [
        CommonModule
    ]
})

export class ProductsOrderModule {
    productID: string;
    name: string;
    price: string;
    document: string;
    extension: string;
    fileName: string;
    quantity:string;
}
