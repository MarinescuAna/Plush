import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CategoryViewModule } from 'src/app/modules/category-view.module';
import { DeliveryDDLModule } from 'src/app/modules/delivery-ddl.module';
import { FilterModule } from 'src/app/modules/filter.module';
import { ProductViewModule } from 'src/app/modules/product-view.module';
import { ProviderDDLModule } from 'src/app/modules/provider-ddl.module';
import { CategoryService } from 'src/app/services/category-service';
import { ProductService } from 'src/app/services/product.service';
import { ProviderDeliveryService } from 'src/app/services/provider-delivery-service';
import { AuthService } from 'src/app/shared/auth.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  formProvider = new FormGroup({
    categoryId: new FormControl(''),
    providerId: new FormControl(''),
    priceMin: new FormControl(''),
    priceMax: new FormControl('')
  });
  categories: CategoryViewModule[];
  providers: ProviderDDLModule[];
  products: ProductViewModule[];

  constructor(private service: ProductService,
    private user: AuthService,
    private categoryService: CategoryService,
    private providerService: ProviderDeliveryService) { }

  ngOnInit(): void {
    if (this.products == null) {
      if (this.user.isLogged() && this.user.getRole().toLowerCase() == "user") {
        this.service.getPublicProductsLogged().subscribe(cr => {
          this.products = cr as ProductViewModule[];
        });
      } else {
        this.service.getPublicProducts().subscribe(cr => {
          this.products = cr as ProductViewModule[];
        });
      }
    }
    if (this.categories == null) {
      this.categoryService.getCategories().subscribe(cr => {
        this.categories = cr as CategoryViewModule[];
      });
    }
    if (this.providers == null) {
      this.providerService.getProviders().subscribe(
        cr => {
          this.providers = cr as ProviderDDLModule[];
        }
      );
    }
    debugger
  }
  onSubmit(): void {
    debugger
    this.products.forEach(element => {
      element.display = true;
      if (this.formProvider.value.providerId != "") {
        element.display = element.providerID === this.formProvider.value.providerId;
      }

      if (this.formProvider.value.categoryId != "") {
        element.display = element.categoryID === this.formProvider.value.categoryId;
      }

      if (this.formProvider.value.priceMax != "") {
        element.display = parseFloat(element.price) <= parseFloat(this.formProvider.value.priceMax);
      }

      if (this.formProvider.value.priceMin != "") {
        element.display = parseFloat(element.price) >= parseFloat(this.formProvider.value.priceMin);
      }

    });

    this.ngOnInit();
  }

}
