import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import {OrderHistoryModule} from 'src/app/modules/order-history.module';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-orders-history',
  templateUrl: './orders-history.component.html',
  styleUrls: ['./orders-history.component.css']
})
export class OrdersHistoryComponent implements OnInit {

  orders: OrderHistoryModule[];
  constructor(private orderService:OrderService,private SpinnerService: NgxSpinnerService) {

   }

  ngOnInit(): void {
    this.SpinnerService.show();
    this.orderService.GetOrderHistory().subscribe(cr=>{
      this.orders=cr as OrderHistoryModule[];
      this.SpinnerService.hide();
    });
  }

}
