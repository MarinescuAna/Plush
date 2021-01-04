import { Component, Input, OnInit } from '@angular/core';
import { ProductsOrderModule } from 'src/app/modules/products-order.module';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-shopping-product',
  templateUrl: './shopping-product.component.html',
  styleUrls: ['./shopping-product.component.css']
})
export class ShoppingProductComponent implements OnInit {
  @Input() data: ProductsOrderModule;
  src: string;
  constructor(private orderService: OrderService) {

  }
  ngOnInit(): void {
    if (this.data.document != null && this.data.document != "") {
      this.src = 'data:image/' + this.data.extension + ';base64,' + this.data.document;
    } else {
      this.src = "assets/images/no-img.jpg"
    }
  }

  onSubmit():void{

    this.orderService.DeleteCart(this.data.basketId).subscribe(cr=>{
      window.location.reload();
    });
  }
}
