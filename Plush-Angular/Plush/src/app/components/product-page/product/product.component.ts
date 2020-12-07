import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ProductViewModule } from 'src/app/modules/product-view.module';
import { ProductAboutComponent } from '../product-about/product-about.component';
import { ProductImageViewComponent } from '../product-image-view/product-image-view.component';
import { WishlistService } from 'src/app/services/wishlist.service';
import { window } from 'rxjs/operators';
import { AuthService } from 'src/app/shared/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  src: string;
  isfavorite = false;
  @Input() product: ProductViewModule;
  constructor(private dialog: MatDialog,
    private wishlist: WishlistService,
    private userService: AuthService,
    private route: Router) { }

  ngOnInit(): void {
    this.isfavorite=this.product.wishlist;
    if (this.product.document != null && this.product.document != "") {
      this.src = 'data:image/' + this.product.extension + ';base64,' + this.product.document;
    } else {
      this.src = "assets/images/no-img.jpg"
    }
  }
  openDialog(): void {
    const diagRef = this.dialog.open(ProductImageViewComponent, { data: { src: this.src } });
  }
  openDialogDetails(): void {
    const diagRef = this.dialog.open(ProductAboutComponent, { data: { product: this.product } });
  }
  favorite(): void {
    debugger
    if (!this.userService.isLogged()) {
      this.route.navigate(['/login']);
      return;
    }
    this.wishlist.addToFavorite(this.product.productID).subscribe(cr => {
      this.isfavorite = this.isfavorite == false ? true : false;
    });
  }
}
