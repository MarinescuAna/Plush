import { Component, Input, OnInit } from '@angular/core';
import { ProductsOrderModule } from 'src/app/modules/products-order.module';
import { QuantityModule } from 'src/app/modules/quantity';
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

  onChange(number:number):void{
    let data=new QuantityModule();
    data.id=this.data.basketId;
    data.number=number;
    debugger
    this.orderService.ChangeQuantity(data).subscribe(cr=>{
      window.location.reload();
    });
  }
  onSubmit():void{
    this.orderService.DeleteCart(this.data.basketId).subscribe(cr=>{
      window.location.reload();
    });
  }
}
