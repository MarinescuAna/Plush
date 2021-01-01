import { Component, Injector, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CategoryViewModule } from 'src/app/modules/category-view.module';
import {ProductInsertModule} from 'src/app/modules/product-insert.module';
import { ProviderDDLModule } from 'src/app/modules/provider-ddl.module';
import { AlertService } from 'src/app/services/alert.service';
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
  newRecord=new ProductInsertModule();
  fileName:string;
  isChecked=false;
  categories: CategoryViewModule[];
  providers: ProviderDDLModule[];
  constructor(private categoryService:CategoryService,
    private productService:ProductService,
    private providerService:ProviderDeliveryService,
    private injector: Injector) { }

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe(cr => {
      this.categories=cr as CategoryViewModule[];
    });
    this.providerService.getProviders().subscribe(cr => {
      this.providers=cr as ProviderDDLModule[];
    });
  }

  onSubmit():void{
    this.newRecord.specification=this.formProduct.value.specifications;
    this.newRecord.name=this.formProduct.value.name;
    this.newRecord.categoryID=this.formProduct.value.category;
    this.newRecord.description=this.formProduct.value.description;
    this.newRecord.price=this.formProduct.value.price+'';
    this.newRecord.stock=this.formProduct.value.stock+'';
    this.newRecord.status=this.isChecked==true? '0':'1';
    this.newRecord.providerID=this.formProduct.value.provider;
    debugger
    this.productService.createProduct(this.newRecord); 
  }
  create_UUID():string{
    var dt = new Date().getTime();
    var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
        var r = (dt + Math.random()*16)%16 | 0;
        dt = Math.floor(dt/16);
        return (c=='x' ? r :(r&0x3|0x8)).toString(16);
    });
    return uuid;
}

  onFileChange(event): void {
    const reader = new FileReader();
    if (event.target.files && event.target.files.length) {
      this.fileName = event.target.files[0].name;
      if (this.fileName.split('.')[1] === 'jpg' || this.fileName.split('.')[1] === 'png' || this.fileName.split('.')[1] === 'jpeg') {
        const [file] = event.target.files;
          reader.readAsDataURL(file);
          reader.onload = () => {
                                   this.newRecord.extension = this.fileName.split('.')[1];
                                   this.newRecord.fileName = this.fileName.split('.')[0];
                                   this.newRecord.document = reader.result.toString().split(',')[1];
                                   this.newRecord.imageID=this.create_UUID();
          };
      }else{
        this.injector.get(AlertService).showError('Invalid file! You can only send jpg, png and jpeg files!');
      }
    }
  }
}
