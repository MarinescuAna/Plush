import { Component, Inject, Injector, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ProductViewAdminModule } from 'src/app/modules/product-view-admin.module';
import { ProductViewModule } from 'src/app/modules/product-view.module';
import { AlertService } from 'src/app/services/alert.service';
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
  src:string;
  isChecked:boolean;
  alertService: any;
  @Input() product: ProductViewAdminModule;
  
  constructor(private dialog: MatDialog,
    private service:ProductService,
    private injector: Injector,
    private route: Router) { 
      this.alertService=injector.get(AlertService);
    }

  ngOnInit(): void {
    this.isChecked=this.product.public=='1'? true:false;
    if(this.product.document!=null && this.product.document!=""){
      this.src='data:image/' + this.product.extension + ';base64,' + this.product.document;
    }else{
      this.src ="assets/images/no-img.jpg"
    }
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
    this.service.publishProduct(this.product.productID).subscribe(cr => {
      this.alertService.showSucces('The product was change!');
      this.route.navigateByUrl('/insertProduct');
    });;
  }
  
  delete():void{
    if(confirm("Are you sure?"))
    {
      this.service.deleteProduct(this.product.productID);
    }
  }
}
