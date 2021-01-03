import { Injectable, Injector } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AddToBasketModule } from '../modules/add-to-basket.module';
import { CategoryViewModule } from '../modules/category-view.module';
import { CategoryModule } from '../modules/category.module';
import { DataService } from './data.service';

@Injectable({
    providedIn: 'root'
})

export class OrderService extends DataService {
    constructor(injector: Injector, private route: Router) {
        super(injector, 'Order');
    }

    private create_UUID(): string {
        var dt = new Date().getTime();
        var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = (dt + Math.random() * 16) % 16 | 0;
            dt = Math.floor(dt / 16);
            return (c == 'x' ? r : (r & 0x3 | 0x8)).toString(16);
        });
        return uuid;
    }
    private GetOrderId(): string {
        let id = localStorage.getItem('OrderId');
        if (id === null) {
            id = this.create_UUID();
            localStorage.setItem('OrderId', id);
        }
        return id;
    }
    public AddToBasket(idProduct: string, quantity:string): any {
        debugger
        let basket = new AddToBasketModule();
        basket.orderId = this.GetOrderId();
        basket.productId = idProduct;
        basket.quantity=quantity;
        return super.post<any>('AddToCart', basket);
    }
    public BuyProducts() {
        localStorage.removeItem('access_token');
    }

    public GetOrderProducts(): any{
        return super.getMany('GetOrderProducts?orderId='+this.GetOrderId());
    }

}