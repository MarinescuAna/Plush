import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
    declarations: [],
    imports: [
        CommonModule
    ]
})

export class ProductViewAdminModule {
    productID: string;
    name: string;
    price: string;
    stock: string;
    categoryName: string;
    providerName: string;
    providerSpecification: string;
    datetime: string;
    public:string;
    document: string;
    extension: string;
    fileName: string;
    imageID:string;
}
