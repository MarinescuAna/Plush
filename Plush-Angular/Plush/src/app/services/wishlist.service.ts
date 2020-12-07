import { Injectable, Injector } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ProductViewModule } from '../modules/product-view.module';
import { DataService } from './data.service';

@Injectable({
  providedIn: 'root'
})

export class WishlistService extends DataService {
  constructor(injector: Injector,private route: Router) {
    super(injector, 'Wishlist');
  }

  addToFavorite(module: any): any{
    return super.post<any>('Like?productId='+module, {});
  }

  getFavorites():Observable<ProductViewModule[]>{
    return super.getMany<ProductViewModule>('GetAllProducts');
  }

}