import { Component, Inject, OnInit, Optional } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProductViewAdminModule } from 'src/app/modules/product-view-admin.module';

@Component({
  selector: 'app-dialog-about-product',
  templateUrl: './dialog-about-product.component.html',
  styleUrls: ['./dialog-about-product.component.css']
})
export class DialogAboutProductComponent implements OnInit {

  product:ProductViewAdminModule;
  ngOnInit(): void {
  }
  constructor( @Optional() @Inject(MAT_DIALOG_DATA) public data: any) {
    this.product = data.product;
  }
}
