import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderHistoryModule } from 'src/app/modules/order-history.module';
import { ProductsOrderModule } from 'src/app/modules/products-order.module';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css']
})
export class OrderDetailsComponent implements OnInit {

  order: OrderHistoryModule;
  products: ProductsOrderModule[];
  constructor( private route: ActivatedRoute, public orderService:OrderService, private router:Router) {
    this.route.queryParams.subscribe(
      params => {
        this.order = params as OrderHistoryModule;
      }
    );
    if(this.order.orderID!=null ||this.order.orderID!="")
    {
      this.orderService.GetOrderProductsHistory(this.order.orderID).subscribe(cr=>{
        this.products = cr as ProductsOrderModule[];
      });
    }
  }

  ngOnInit(): void {
  }
  
  onSubmit():void{
    this.router.navigateByUrl("history");
  }

}
