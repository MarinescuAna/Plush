import { Component, Input, OnInit } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { OrderHistoryModule } from 'src/app/modules/order-history.module';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.css']
})
export class OrderHistoryComponent implements OnInit {

  @Input() data: OrderHistoryModule;
  constructor(private orderService:OrderService, private route:Router) {

   }

  ngOnInit(): void {
  }

  onSubmit():void{
    let navigationExtras: NavigationExtras = {
      queryParams: this.data
    };
    this.route.navigate(['\orderHistory'], navigationExtras);
  }

  onCancel():void{
    this.orderService.CancelOrder(this.data.orderID).subscribe(
      cr =>{
        window.location.reload();
      }
    );
  }
}
