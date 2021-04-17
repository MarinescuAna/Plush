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
    price: string;
    stock: string;
    categoryName: string;
    providerName: string;
    document: string;
    extension: string;
    fileName: string;
    imageID:string;
}
