import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { MenuComponent } from './components/menu/menu.component';
import { ProductsComponent } from './components/product-page/products/products.component';
import { ProductComponent } from './components/product-page/product/product.component';
import { CategoriesComponent } from './components/category-page/categories/categories.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatCardModule} from '@angular/material/card';
import { InsertProductComponent } from './components/product-page/insert-product/insert-product.component'
import {AppRoutingModule} from '../app/app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    ProductsComponent,
    ProductComponent,
    CategoriesComponent,
    InsertProductComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatCardModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
