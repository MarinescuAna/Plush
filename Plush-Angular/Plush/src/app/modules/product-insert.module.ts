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
    category: string;
    provider: string;
    status: string;
}
