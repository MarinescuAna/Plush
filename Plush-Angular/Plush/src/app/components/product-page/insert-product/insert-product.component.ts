import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CategoryModule } from 'src/app/modules/category.module';
import {ProductInsertModule} from 'src/app/modules/product-insert.module';
import { ProviderDDLModule } from 'src/app/modules/provider-ddl.module';
import { CategoryService } from 'src/app/services/category-service';
import { ProductService } from 'src/app/services/product.service';
import { ProviderDeliveryService } from 'src/app/services/provider-delivery-service';

@Component({
  selector: 'app-insert-product',
  templateUrl: './insert-product.component.html',
  styleUrls: ['./insert-product.component.css']
})
export class InsertProductComponent implements OnInit {

  formProduct = new FormGroup({
    name: new FormControl('',[Validators.required]),
    description: new FormControl('',[Validators.required]),
    price: new FormControl('',[Validators.required]),
    stock: new FormControl('',[Validators.required]),
    category: new FormControl('',[Validators.required]),
    provider: new FormControl('',[Validators.required]),
    status: new FormControl(''),
    specifications: new FormControl('',[Validators.required])
  });
  isChecked=false;
  categories: CategoryModule[];
  providers: ProviderDDLModule[];
  constructor(private categoryService:CategoryService,
    private productService:ProductService,
    private providerService:ProviderDeliveryService) { }

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe(cr => {
      this.categories=cr as CategoryModule[];
    });
    this.providerService.getProviders().subscribe(cr => {
      this.providers=cr as ProviderDDLModule[];
    });
  }

  onSubmit():void{
     let newRecord=new ProductInsertModule();
    newRecord.specification=this.formProduct.value.specifications;
    newRecord.name=this.formProduct.value.name;
    newRecord.category=this.formProduct.value.category;
    newRecord.description=this.formProduct.value.description;
    newRecord.price=this.formProduct.value.price+'';
    newRecord.stock=this.formProduct.value.stock+'';
    newRecord.status=this.isChecked==true? '0':'1';
    newRecord.provider=this.formProduct.value.provider;
    debugger
    this.productService.createProduct(newRecord); 
  }
}
