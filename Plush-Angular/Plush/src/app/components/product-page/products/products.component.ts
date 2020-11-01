import { Component, OnInit } from '@angular/core';
import { ProductViewModule } from 'src/app/modules/product-view.module';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  products: ProductViewModule[];
  constructor(private service: ProductService) { }

  ngOnInit(): void {
    this.service.getPublicProducts().subscribe(cr => {
      this.products = cr as ProductViewModule[];
    });
  }

}
