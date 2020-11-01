import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import {ProductViewModule} from 'src/app/modules/product-view.module';
import { ProductAboutComponent } from '../product-about/product-about.component';
import { ProductImageViewComponent } from '../product-image-view/product-image-view.component';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  src="assets/images/no-img.jpg";
  @Input() product: ProductViewModule;
  constructor(private dialog: MatDialog) { }

  ngOnInit(): void {
  }
  openDialog(): void {
    const diagRef = this.dialog.open(ProductImageViewComponent, { data: { src: this.src } });
  }
  openDialogDetails(): void{
    debugger
    const diagRef = this.dialog.open(ProductAboutComponent, { data: { product: this.product } });
  }
}
