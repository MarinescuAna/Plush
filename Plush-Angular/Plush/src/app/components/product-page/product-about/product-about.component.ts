import { Component, Inject, OnInit, Optional } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProductViewModule } from 'src/app/modules/product-view.module';
import { ProductSpecificationsComponent } from '../product-specifications/product-specifications.component';

@Component({
  selector: 'app-product-about',
  templateUrl: './product-about.component.html',
  styleUrls: ['./product-about.component.css']
})
export class ProductAboutComponent implements OnInit {

  product:ProductViewModule;
  src:string;
  ngOnInit(): void {
  }
  constructor( @Optional() @Inject(MAT_DIALOG_DATA) public data: any,
  private dialog: MatDialog) {
    debugger
    this.product = data.product;
    if(this.product.document!=null && this.product.document!=""){
      this.src='data:image/' + this.product.extension + ';base64,' + this.product.document;
    }else{
      this.src ="assets/images/no-img.jpg"
    }
  }

  openDialogDetails(): void {
    const diagRef = this.dialog.open(ProductSpecificationsComponent, { data: { text: this.product.specifications } });
  }
}
