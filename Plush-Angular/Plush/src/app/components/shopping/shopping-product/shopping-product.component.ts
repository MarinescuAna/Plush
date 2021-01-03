import { Component, Input, OnInit } from '@angular/core';
import { ProductsOrderModule } from 'src/app/modules/products-order.module';

@Component({
  selector: 'app-shopping-product',
  templateUrl: './shopping-product.component.html',
  styleUrls: ['./shopping-product.component.css']
})
export class ShoppingProductComponent implements OnInit {
  @Input() data: ProductsOrderModule;
  src: string;
  constructor() {

  }
  ngOnInit(): void {
    debugger
    if (this.data.document != null && this.data.document != "") {
      this.src = 'data:image/' + this.data.extension + ';base64,' + this.data.document;
    } else {
      this.src = "assets/images/no-img.jpg"
    }
  }

}
