import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
    declarations: [],
    imports: [
        CommonModule
    ]
})

export class ProductViewModule {
    productID: string;
    name: string;
    description: string;
    specification: string;
    price: string;
    categoryName: string;
    providerName: string;
    providerSpecification: string;
    datetime: string;   
    document: string;
    extension: string;
    fileName: string;
    imageID:string;
    wishlist:boolean;
    categoryID:string;
    providerID:string;
    display:boolean;
}
