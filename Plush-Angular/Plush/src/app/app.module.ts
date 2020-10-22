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

import { CategoryModule } from 'src/app/modules/category.module';
import { ViewCategoryComponent } from './components/category-page/view-category/view-category.component';
import { MainPageComponent } from './components/category-page/main-page/main-page.component'

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    ProductsComponent,
    ProductComponent,
    CategoriesComponent,
    InsertProductComponent,
    ViewCategoryComponent,
    MainPageComponent
  ],
  imports: [
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
    ToastrModule.forRoot(),
    MatTableModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
