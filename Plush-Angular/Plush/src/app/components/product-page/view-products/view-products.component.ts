import { Component, OnInit } from '@angular/core';
import { ProductViewAdminModule } from 'src/app/modules/product-view-admin.module';
import { ProductViewModule } from 'src/app/modules/product-view.module';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-view-products',
  templateUrl: './view-products.component.html',
  styleUrls: ['./view-products.component.css']
})
export class ViewProductsComponent implements OnInit {


  products: ProductViewAdminModule[];
  constructor(private service: ProductService) { }

  ngOnInit(): void {
    this.service.getProducts().subscribe(cr => {
      this.products = cr as ProductViewAdminModule[];
    });
  }


}
