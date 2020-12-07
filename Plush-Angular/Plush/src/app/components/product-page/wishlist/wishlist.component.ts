import { Component, OnInit } from '@angular/core';
import { ProductViewModule } from 'src/app/modules/product-view.module';
import { WishlistService } from 'src/app/services/wishlist.service';

@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.css']
})
export class WishlistComponent implements OnInit {

  products: ProductViewModule[];
  constructor(private service: WishlistService) { }

  ngOnInit(): void {
    this.service.getFavorites().subscribe(cr => {
      this.products = cr as ProductViewModule[];
    });
  }

}
