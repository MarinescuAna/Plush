import { Component, OnInit } from '@angular/core';
import { ProductViewModule } from 'src/app/modules/product-view.module';
import { WishlistService } from 'src/app/services/wishlist.service';
import { NgxSpinnerService } from "ngx-spinner"; 

@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.css']
})
export class WishlistComponent implements OnInit {

  products: ProductViewModule[];
  constructor(private service: WishlistService,
    private SpinnerService: NgxSpinnerService) { }

  ngOnInit(): void {
    this.SpinnerService.show();
    this.service.getFavorites().subscribe(cr => {
      this.products = cr as ProductViewModule[];
      this.SpinnerService.hide();
    });
  }

}
