import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
    declarations: [],
    imports: [
        CommonModule
    ]
})

export class ProductInsertModule {
    name: string;
    description: string;
    specification: string;
    price: string;
    stock: string;
    categoryID: string;
    providerID: string;
    imageID: string;
    status: string;
    document: string;
    extension: string;
    fileName: string;
}
