import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ProductViewAdminModule } from 'src/app/modules/product-view-admin.module';
import { ProductViewModule } from 'src/app/modules/product-view.module';
import { ProductService } from 'src/app/services/product.service';
import { DialogAboutProductComponent } from '../dialog-about-product/dialog-about-product.component';
import { DialogUpdateProductComponent } from '../dialog-update-product/dialog-update-product.component';
import { ProductImageViewComponent } from '../product-image-view/product-image-view.component';

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.css']
})
export class ViewProductComponent implements OnInit {
  src="assets/images/no-img.jpg";
  isChecked:boolean;
  @Input() product: ProductViewAdminModule;
  
  constructor(private dialog: MatDialog,
    private service:ProductService) { }

  ngOnInit(): void {
    this.isChecked=this.product.public=='1'? true:false;
  }
  
  openDialog(): void {
    const diagRef = this.dialog.open(ProductImageViewComponent, { data: { src: this.src } });
  }

  openDialogDetails(): void{
   const diagRef = this.dialog.open(DialogAboutProductComponent, { data: { product: this.product } });
  }

  update(): void{
    const diagRef = this.dialog.open(DialogUpdateProductComponent, { data: { product: this.product } });
   }

  changeStatus():void{
    this.service.publishProduct(this.product.productID);
  }
  delete():void{
    if(confirm("Are you sure?"))
    {
      this.service.deleteProduct(this.product.productID);
    }
  }
}
