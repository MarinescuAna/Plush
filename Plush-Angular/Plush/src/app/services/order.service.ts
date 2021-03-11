import { Injectable, Injector } from '@angular/core';
import { Router } from '@angular/router';
import { AddToBasketModule } from '../modules/add-to-basket.module';
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
    public GetOrderId(): string {
        let id = localStorage.getItem('OrderId');
        if (id === null) {
            super.getOne('GetOrderIs').subscribe(cr => {
                id = cr as string;
            });
            if (id == null || id == '') {
                id = this.create_UUID();
            }
        }
        localStorage.setItem('OrderId', id);
        return id;
    }
    public AddToBasket(idProduct: string, quantity: string): any {
        debugger
        let basket = new AddToBasketModule();
        basket.orderId = this.GetOrderId();
        basket.productId = idProduct;
        basket.quantity = quantity;
        return super.post<any>('AddToCart', basket);
    }
    public BuyProducts() {
        localStorage.removeItem('access_token');
    }

    public GetOrderProducts(): any {
        return super.getMany('GetOrderProducts');
    }

    public FinishOrder(data: any): any {
        return super.update('FinishOrder', data);
    }
    public CancelOrder(data: any): any {
        return super.update("CancelOrder?id=" + data, {});
    }
    public DeliverOrder(data: any): any {
        return super.update("DeliverOrder?id=" + data, {});
    }
    public ChangeQuantity(data: any): any {
        return super.update("ChangeQuantity", data);
    }
    public DeleteCart(id: any): any {
        return super.delete(id, 'DeleteProductFromCart?id=');
    }

    public GetOrderHistory(): any {
        return super.getMany("GetOrderHistory");
    }
    public GetOrdersAsAdmin(): any {
        return super.getMany("GetOrdersAsAdmin");
    }
    public GetOrderProductsHistory(id: any): any {
        return super.getMany("GetOrderProductsHistory?id=" + id);
    }

}