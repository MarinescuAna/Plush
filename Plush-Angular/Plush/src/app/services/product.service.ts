import { Injectable, Injector } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { CategoryViewModule } from '../modules/category-view.module';
import { ProductInsertModule } from '../modules/product-insert.module';
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
        //this.route.navigateByUrl['\products'];
      });
  }

  getPublicProducts(): Observable<ProductInsertModule[]>{
    debugger;
    return super.getMany<ProductInsertModule>('GetPublicProducts');
  }

  deleteCategory(id: any):void{
    super.delete(id,'DeleteCategory');
  }
}