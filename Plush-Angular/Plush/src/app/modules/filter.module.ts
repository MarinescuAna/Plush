import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
    declarations: [],
    imports: [
        CommonModule
    ]
})

export class FilterModule {
    categoryId: string;
    providerId: string;
    deliveryId: string;
    priceMin: string;
    priceMax: string;
}
