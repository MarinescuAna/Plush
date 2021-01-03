import { Component, OnInit } from '@angular/core';
import { ProductsOrderModule } from 'src/app/modules/products-order.module';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {

  total = 0.0;
  constructor(private orderService: OrderService) { }
  data: ProductsOrderModule[];
  
  ngOnInit(): void {
    this.orderService.GetOrderProducts().subscribe(cr => {
      this.data = cr as ProductsOrderModule[];
      this.data.forEach(u => {
        this.total = this.total + Number.parseFloat(u.quantity) * Number.parseFloat(u.price)
      });
    });
  }
}
