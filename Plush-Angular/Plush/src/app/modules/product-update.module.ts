import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
    declarations: [],
    imports: [
        CommonModule
    ]
})

export class ProductUpdateModule {
    productID: string;
    name: string;
    description: string;
    specification: string;
    price: string;
    stock: string;
    categoryName: string;
    providerName: string;
}
