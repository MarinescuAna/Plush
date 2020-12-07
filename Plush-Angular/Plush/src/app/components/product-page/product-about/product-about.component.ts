import { Component, Inject, OnInit, Optional } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProductViewModule } from 'src/app/modules/product-view.module';

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
  constructor( @Optional() @Inject(MAT_DIALOG_DATA) public data: any) {
    debugger
    this.product = data.product;
    if(this.product.document!=null && this.product.document!=""){
      this.src='data:image/' + this.product.extension + ';base64,' + this.product.document;
    }else{
      this.src ="assets/images/no-img.jpg"
    }
  }
}
