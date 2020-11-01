import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CategoryViewModule } from 'src/app/modules/category-view.module';
import{ProductUpdateModule} from 'src/app/modules/product-update.module';
import { ProductViewAdminModule } from 'src/app/modules/product-view-admin.module';
import { ProviderDDLModule } from 'src/app/modules/provider-ddl.module';
import { CategoryService } from 'src/app/services/category-service';
import { ProductService } from 'src/app/services/product.service';
import { ProviderDeliveryService } from 'src/app/services/provider-delivery-service';

@Component({
  selector: 'app-dialog-update-product',
  templateUrl: './dialog-update-product.component.html',
  styleUrls: ['./dialog-update-product.component.css']
})
export class DialogUpdateProductComponent implements OnInit {

  product:ProductViewAdminModule;
  providers: ProviderDDLModule[];
  categories:CategoryViewModule[];
  formProduct :FormGroup;

  ngOnInit(): void {
    this.providerService.getProviders().subscribe(cr => {
      this.providers=cr as ProviderDDLModule[];
    });
    this.categoryService.getCategories().subscribe(cr => {
      this.categories=cr as CategoryViewModule[];
    });
  }
  constructor( @Optional() @Inject(MAT_DIALOG_DATA) public data: any,
    private providerService: ProviderDeliveryService,
    private categoryService: CategoryService,
    private productService: ProductService) {
    this.product = data.product;
    this.formProduct = new FormGroup({
      name: new FormControl(this.product.name),
      description: new FormControl(this.product.description),
      price: new FormControl(this.product.price),
      stock: new FormControl(this.product.stock),
      category: new FormControl(''),
      provider: new FormControl(''),
      specifications: new FormControl(this.product.specification)
    });
  }

  onSubmit():void{
    var changes=0;
    let newProduct=new ProductUpdateModule();
    newProduct.productID=this.product.productID;

    if(this.formProduct.value.name!="" && this.formProduct.value.name!=this.product.name){
      changes++;
      newProduct.name=this.formProduct.value.name;
    }
    if(this.formProduct.value.description!="" && this.formProduct.value.description!=this.product.description){
      changes++;
      newProduct.description=this.formProduct.value.description;
    }
    if(this.formProduct.value.specifications!="" && this.formProduct.value.specifications!=this.product.specification){
      changes++;
      newProduct.specification=this.formProduct.value.specifications;
    }
    if(this.formProduct.value.price!="" && this.formProduct.value.price!=this.product.price){
      changes++;
      newProduct.price=this.formProduct.value.price+'';
    }
    if(this.formProduct.value.stock!="" && this.formProduct.value.stock!=this.product.stock){
      changes++;
      newProduct.stock=this.formProduct.value.stock+'';
    }
    if(this.formProduct.value.category!="" && this.formProduct.value.category!=this.product.categoryName){
      changes++;
      newProduct.categoryName=this.formProduct.value.category;
    }
    if(this.formProduct.value.provider!="" && this.formProduct.value.provider!=this.product.providerName){
      changes++;
      newProduct.providerName=this.formProduct.value.provider;
    }
 
    if(changes>0){
      this.productService.updateProduct(newProduct);
    }
  }

}
