import { Injectable, Injector } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ProductInsertModule } from '../modules/product-insert.module';
import { ProductViewModule } from '../modules/product-view.module';
import { ProductViewAdminModule } from '../modules/product-view-admin.module';
import { DataService } from './data.service';

@Injectable({
  providedIn: 'root'
})

export class ProductService extends DataService {
  constructor(injector: Injector,private route: Router) {
    super(injector, 'Product');
  }

  createProduct(module: ProductInsertModule): void{
    super.post<any>('InsertProduct', module).subscribe(cr => {
        this.alertService.showSucces('The product was created!');
        window.location.reload();
      });
  }

  getPublicProducts(): Observable<ProductViewModule[]>{
    return super.getMany<ProductViewModule>('GetPublicProducts');
  }

  getProducts(): Observable<ProductViewAdminModule[]>{
    return super.getMany<ProductViewAdminModule>('GetProducts');
  }

  deleteProduct(id: any):void{
    super.delete(id,'DeleteProduct?id=').subscribe(cr => {
      this.alertService.showSucces('The product was successfully deleted!');
      window.location.reload();
    });;
  }

  publishProduct(id: any): Observable<any>{
    return super.update('PublishProduct?id='+id, '');
  }
  updateProduct(data: any): void{
    super.update('UpdateProduct', data).subscribe(cr => {
        this.alertService.showSucces('The product was change!');
        window.location.reload();
      });
  }
}