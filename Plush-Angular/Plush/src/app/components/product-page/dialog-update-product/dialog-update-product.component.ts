import { Component, Inject, Injector, OnInit, Optional } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CategoryViewModule } from 'src/app/modules/category-view.module';
import { ProductUpdateModule } from 'src/app/modules/product-update.module';
import { ProductViewAdminModule } from 'src/app/modules/product-view-admin.module';
import { ProviderDDLModule } from 'src/app/modules/provider-ddl.module';
import { AlertService } from 'src/app/services/alert.service';
import { CategoryService } from 'src/app/services/category-service';
import { ProductService } from 'src/app/services/product.service';
import { ProviderDeliveryService } from 'src/app/services/provider-delivery-service';

@Component({
  selector: 'app-dialog-update-product',
  templateUrl: './dialog-update-product.component.html',
  styleUrls: ['./dialog-update-product.component.css']
})
export class DialogUpdateProductComponent implements OnInit {

  product: ProductViewAdminModule;
  providers: ProviderDDLModule[];
  categories: CategoryViewModule[];
  formProduct: FormGroup;
  newProduct = new ProductUpdateModule();
  fileName: string;

  ngOnInit(): void {
    this.providerService.getProviders().subscribe(cr => {
      this.providers = cr as ProviderDDLModule[];
    });
    this.categoryService.getCategories().subscribe(cr => {
      this.categories = cr as CategoryViewModule[];
    });
  }
  constructor(@Optional() @Inject(MAT_DIALOG_DATA) public data: any,
    private providerService: ProviderDeliveryService,
    private categoryService: CategoryService,
    private productService: ProductService) {
    this.product = data.product;
    this.formProduct = new FormGroup({
      name: new FormControl(this.product.name),
      price: new FormControl(this.product.price),
      stock: new FormControl(this.product.stock),
      category: new FormControl(''),
      provider: new FormControl('')
    });
  }

  onSubmit(): void {
    var changes = 0;
    this.newProduct.productID = this.product.productID+"";
    this.newProduct.imageID = this.newProduct.imageID==null? this.newGuid():this.newProduct.imageID;

    if (this.newProduct.fileName != "" && this.newProduct.fileName != this.product.name) {
      changes++;
    }
    if (this.formProduct.value.name != "" && this.formProduct.value.name != this.product.name) {
      changes++;
      this.newProduct.name = this.formProduct.value.name;
    }
    if (this.formProduct.value.price != "" && this.formProduct.value.price != this.product.price) {
      changes++;
      this.newProduct.price = this.formProduct.value.price + '';
    }
    if (this.formProduct.value.stock != "" && this.formProduct.value.stock != this.product.stock) {
      changes++;
      this.newProduct.stock = this.formProduct.value.stock + '';
    }
    if (this.formProduct.value.category != "" && this.formProduct.value.category != this.product.categoryName) {
      changes++;
      this.newProduct.categoryName = this.formProduct.value.category;
    }
    if (this.formProduct.value.provider != "" && this.formProduct.value.provider != this.product.providerName) {
      changes++;
      this.newProduct.providerName = this.formProduct.value.provider;
    }

    if (changes > 0) {
      this.productService.updateProduct(this.newProduct);
    }
  }
  private newGuid(): string {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
      var r = Math.random() * 16 | 0,
        v = c == 'x' ? r : (r & 0x3 | 0x8);
      return v.toString(16);
    });
  }
  onFileChange(event): void {
    const reader = new FileReader();
    if (event.target.files && event.target.files.length) {
      this.fileName = event.target.files[0].name;
      const [file] = event.target.files;
      reader.readAsDataURL(file);
      reader.onload = () => {
        this.newProduct.extension = this.fileName.split('.')[1];
        this.newProduct.fileName = this.fileName.split('.')[0];
        this.newProduct.document = reader.result.toString().split(',')[1];
        this.newProduct.imageID = this.product.imageID==null? this.newGuid():this.product.imageID;
      };
    }
  }

}
