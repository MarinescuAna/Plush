import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { MenuComponent } from './components/menu/menu.component';
import { ProductsComponent } from './components/product-page/products/products.component';
import { ProductComponent } from './components/product-page/product/product.component';
import { CategoriesComponent } from './components/category-page/categories/categories.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule } from '@angular/material/card';
import { InsertProductComponent } from './components/product-page/insert-product/insert-product.component'
import { AppRoutingModule } from '../app/app-routing.module';
import { FlexLayoutModule } from "@angular/flex-layout";
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ToastrModule } from 'ngx-toastr';
import {MatButtonModule} from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSelectModule} from '@angular/material/select';

import { CategoryModule } from 'src/app/modules/category.module';
import { CategoryViewModule } from 'src/app/modules/category-view.module';
import { ViewCategoryComponent } from './components/category-page/view-category/view-category.component';
import { MainPageComponent } from './components/category-page/main-page/main-page.component'

import{ AlertService } from './services/alert.service';
import { HttpClientModule } from '@angular/common/http';
import {AppErrorHandler} from 'src/app/handler-error/app-error-handler';
import { DeliveryComponentComponent } from './components/delivery-provider-page/delivery-component/delivery-component.component';
import { ProviderComponentComponent } from './components/delivery-provider-page/provider-component/provider-component.component';
import { ProviderDeliveryViewComponent } from './components/delivery-provider-page/provider-delivery-view/provider-delivery-view.component';
import { ProviderDeliveryTableComponent } from './components/delivery-provider-page/provider-delivery-table/provider-delivery-table.component';
import { ProviderDeliveryComponentComponent } from './components/delivery-provider-page/provider-delivery-component/provider-delivery-component.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    ProductsComponent,
    ProductComponent,
    CategoriesComponent,
    InsertProductComponent,
    ViewCategoryComponent,
    MainPageComponent,
    DeliveryComponentComponent,
    ProviderComponentComponent,
    ProviderDeliveryViewComponent,
    ProviderDeliveryTableComponent,
    ProviderDeliveryComponentComponent
  ],
  imports: [
    
    HttpClientModule,
    CategoryViewModule,
    MatPaginatorModule,
    MatButtonModule,
    CategoryModule,
    BrowserModule,
    BrowserAnimationsModule,
    MatCardModule,
    AppRoutingModule,
    FlexLayoutModule,
    MatIconModule,
    MatFormFieldModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatSelectModule,
    ToastrModule.forRoot(),
    MatTableModule
  ],
  providers: [
    AppErrorHandler,
    AlertService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
