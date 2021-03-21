import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { JwtModule } from '@auth0/angular-jwt';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { MenuComponent } from './components/menu/menu.component';
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
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import {MatDialogModule} from '@angular/material/dialog';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatAutocompleteModule} from '@angular/material/autocomplete';

import { CategoryModule } from 'src/app/modules/category.module';
import { CategoryViewModule } from 'src/app/modules/category-view.module';
import { ViewCategoryComponent } from './components/category-page/view-category/view-category.component';
import { MainPageComponent } from './components/category-page/main-page/main-page.component'
import {AuthconfigInterceptor} from 'src/app/shared/authconfig.interceptor';
import {MatRadioModule} from '@angular/material/radio';
import { AlertService } from './services/alert.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppErrorHandler } from 'src/app/handler-error/app-error-handler';
import { DeliveryComponentComponent } from './components/delivery-provider-page/delivery-component/delivery-component.component';
import { ProviderComponentComponent } from './components/delivery-provider-page/provider-component/provider-component.component';
import { ProductAboutComponent } from './components/product-page/product-about/product-about.component';
import { ProductImageViewComponent } from './components/product-page/product-image-view/product-image-view.component';
import { ViewProductsComponent } from './components/product-page/view-products/view-products.component';
import { ViewProductComponent } from './components/product-page/view-product/view-product.component';
import { DialogAboutProductComponent } from './components/product-page/dialog-about-product/dialog-about-product.component';
import { DialogUpdateProductComponent } from './components/product-page/dialog-update-product/dialog-update-product.component';
import { LoginComponent } from './components/account-page/login/login.component';
import { RegisterComponent } from './components/account-page/register/register.component';
import { WishlistComponent } from './components/product-page/wishlist/wishlist.component';
import { ProductsComponent } from './components/product-page/products/products.component';
import { NgxSpinnerModule } from "ngx-spinner";
import { ProviderTableComponent } from './components/delivery-provider-page/provider-table/provider-table.component';
import { DeliveryTableComponent } from './components/delivery-provider-page/delivery-table/delivery-table.component';
import { DeliveryComponent } from './components/delivery-provider-page/delivery/delivery.component';
import { ProviderComponent } from './components/delivery-provider-page/provider/provider.component';
import { ShoppingProductComponent } from './components/shopping/shopping-product/shopping-product.component';
import { BasketComponent } from './components/shopping/basket/basket.component';
import { DialogProductQuantityComponent } from './components/product-page/dialog-product-quantity/dialog-product-quantity.component';
import { InformationComponent } from './components/shopping/information/information.component';
import { OrdersHistoryComponent } from './components/shopping/orders-history/orders-history.component';
import { OrderHistoryComponent } from './components/shopping/order-history/order-history.component';
import { OrderDetailsComponent } from './components/shopping/order-details/order-details.component';
import { OrdersAdminComponent } from './components/shopping/orders-admin/orders-admin.component'; 

export function tokenGetter() {
  return localStorage.getItem('access_token');
}

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    ProductComponent,
    CategoriesComponent,
    InsertProductComponent,
    ViewCategoryComponent,
    MainPageComponent,
    DeliveryComponentComponent,
    ProviderComponentComponent,
    ProductAboutComponent,
    ProductImageViewComponent,
    ViewProductsComponent,
    ViewProductComponent,
    DialogAboutProductComponent,
    DialogUpdateProductComponent,
    LoginComponent,
    RegisterComponent,
    WishlistComponent,
    ProductsComponent,
    ProviderTableComponent,
    DeliveryTableComponent,
    DeliveryComponent,
    ProviderComponent,
    ShoppingProductComponent,
    BasketComponent,
    DialogProductQuantityComponent,
    InformationComponent,
    OrdersHistoryComponent,
    OrderHistoryComponent,
    OrderDetailsComponent,
    OrdersAdminComponent
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
    JwtModule.forRoot({
      config: {
      tokenGetter: tokenGetter
    }}),
    MatTableModule,
    MatSlideToggleModule,
    MatDialogModule,
    MatProgressBarModule,
    NgxSpinnerModule,
    MatRadioModule,
    MatAutocompleteModule
  ],
  providers: [
    AppErrorHandler,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthconfigInterceptor,
      multi: true
    },
    AlertService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
