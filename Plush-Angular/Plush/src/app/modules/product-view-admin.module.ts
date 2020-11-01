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
    description: string;
    specification: string;
    price: string;
    stock: string;
    categoryName: string;
    categorySpecification: string;
    providerName: string;
    providerSpecification: string;
    datetime: string;
    public:string;
}
