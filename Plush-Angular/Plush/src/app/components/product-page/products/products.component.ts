import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CategoryViewModule } from 'src/app/modules/category-view.module';
import { ProductViewModule } from 'src/app/modules/product-view.module';
import { ProviderDDLModule } from 'src/app/modules/provider-ddl.module';
import { CategoryService } from 'src/app/services/category-service';
import { ProductService } from 'src/app/services/product.service';
import { ProviderDeliveryService } from 'src/app/services/provider-delivery-service';
import { AuthService } from 'src/app/shared/auth.service';
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  formSearchPred = new FormGroup({
    searchKeyWordPred: new FormControl('')
  });

  formSearch = new FormGroup({
    searchKeyWord: new FormControl('')
  });

  isChecked: boolean;
  formProvider = new FormGroup({
    categoryId: new FormControl(''),
    providerId: new FormControl(''),
    priceMin: new FormControl(''),
    priceMax: new FormControl('')
  });
  categories: CategoryViewModule[];
  providers: ProviderDDLModule[];
  products: ProductViewModule[];
  filterProducts: ProductViewModule[];

  constructor(private service: ProductService,
    private user: AuthService,
    private categoryService: CategoryService,
    private providerService: ProviderDeliveryService,
    private SpinnerService: NgxSpinnerService) { }

  ngOnInit(): void {

    this.SpinnerService.show();

    this.service.getPublicProducts().subscribe(cr => {
      this.products = cr as ProductViewModule[];
      this.filterProducts = this.products;
      this.SpinnerService.hide();
    });

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
  }
  changeStatus() {
    if (this.isChecked == false) {
      this.filterProducts = this.products;
      if (this.formProvider.value.providerId != "") {
        this.filterProducts = this.filterProducts.filter(element => element.providerID === this.formProvider.value.providerId)
      }
      if (this.formProvider.value.categoryId != "") {
        this.filterProducts = this.filterProducts.filter(element => element.categoryID === this.formProvider.value.categoryId)
      }
      if (this.formProvider.value.priceMax != "") {
        this.filterProducts = this.filterProducts.filter(element => parseFloat(element.price) <= parseFloat(this.formProvider.value.priceMax))
      }
      if (this.formProvider.value.priceMin != "") {
        this.filterProducts = this.filterProducts.filter(element => parseFloat(element.price) >= parseFloat(this.formProvider.value.priceMin))
      }
    }
  }

  onSearch(): void {
    this.service.SearchLucene(this.formSearch.value.searchKeyWord).subscribe(
      cr => {
        this.filterProducts = cr as ProductViewModule[];
      }
    );
  }

  onSearchPred(): void {
    debugger
    this.filterProducts = this.products;
    if (this.formSearchPred.value.searchKeyWordPred.name == null) {
      this.filterProducts = this.filterProducts.filter(element => element.name.includes(this.formSearchPred.value.searchKeyWordPred.toUpperCase()));
    } else {
      this.filterProducts = this.filterProducts.filter(element => element.name.includes(this.formSearchPred.value.searchKeyWordPred.name.toUpperCase()));
    }

  }
  onSubmit(): void {
    this.filterProducts = this.products;
    if (this.formProvider.value.providerId != "") {
      this.filterProducts = this.filterProducts.filter(element => element.providerID === this.formProvider.value.providerId)
    }
    if (this.formProvider.value.categoryId != "") {
      this.filterProducts = this.filterProducts.filter(element => element.categoryID === this.formProvider.value.categoryId)
    }
    if (this.formProvider.value.priceMax != "") {
      this.filterProducts = this.filterProducts.filter(element => parseFloat(element.price) <= parseFloat(this.formProvider.value.priceMax))
    }
    if (this.formProvider.value.priceMin != "") {
      this.filterProducts = this.filterProducts.filter(element => parseFloat(element.price) >= parseFloat(this.formProvider.value.priceMin))
    }
  }
  keyword = 'name';

  selectEvent(item) {
    // do something with selected item
  }

  onChangeSearch(val: string) {
    // fetch remote data from here
    // And reassign the 'data' which is binded to 'data' property.
  }

  onFocused(e) {
    // do something when input is focused
  }
}

