import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductViewModule } from 'src/app/modules/product-view.module';
import { WishlistService } from 'src/app/services/wishlist.service';
import { AuthService } from 'src/app/shared/auth.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  url = "/src/app/images/logo.png";
  title = 'Plush';
  isLogged = false;
  isAdmin = false;
  constructor(private service: AuthService,
    private serviceWishlist: WishlistService,
    private route: Router) {
    this.isLogged = this.service.isLogged();
    this.isAdmin = this.service.getRole().toLowerCase() == "admin" ? true : false;
  }

  ngOnInit(): void {
  }
  logout(): void {
    this.service.doLogout();
    window.location.reload();
  }

}
