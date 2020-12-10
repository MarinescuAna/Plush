import { Component, OnInit } from '@angular/core';
import { ProductViewAdminModule } from 'src/app/modules/product-view-admin.module';
import { ProductService } from 'src/app/services/product.service';
import { NgxSpinnerService } from "ngx-spinner"; 
@Component({
  selector: 'app-view-products',
  templateUrl: './view-products.component.html',
  styleUrls: ['./view-products.component.css']
})
export class ViewProductsComponent implements OnInit {


  products: ProductViewAdminModule[];
  constructor(private service: ProductService,private SpinnerService: NgxSpinnerService) { }

  ngOnInit(): void {
    this.SpinnerService.show();
    this.service.getProducts().subscribe(cr => {
      this.products = cr as ProductViewAdminModule[];
      this.SpinnerService.hide();
    });
  }


}
