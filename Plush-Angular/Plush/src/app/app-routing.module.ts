import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router'
import {ProductsComponent} from './components/product-page/products/products.component';
import {MainPageComponent} from './components/category-page/main-page/main-page.component';
import { ProviderDeliveryViewComponent } from './components/delivery-provider-page/provider-delivery-view/provider-delivery-view.component';
import { ViewProductsComponent } from './components/product-page/view-products/view-products.component';
import { RegisterComponent } from './components/account-page/register/register.component';
import { LoginComponent } from './components/account-page/login/login.component';
import{AuthGuard} from 'src/app/shared/auth.guard';
import { WishlistComponent } from './components/product-page/wishlist/wishlist.component';

const routes: Routes = [
  {
    path: 'category',
    component: MainPageComponent,
    canActivate:[AuthGuard],
    data: { roles: ["admin"]}
  },
  {
    path: 'products',
    component: ProductsComponent
  },
  {
    path: '',
    redirectTo: '/products',
    pathMatch: 'full'
  },
  {
    path:'deliveryProvider',
    component: ProviderDeliveryViewComponent,
    canActivate:[AuthGuard],
    data: { roles: ["admin"]}
  },
  {
    path:'insertProduct',
    component:ViewProductsComponent,
    canActivate:[AuthGuard],
    data: { roles: ["admin"]}
  },
  {
    path:'wishlist',
    component:WishlistComponent,
    canActivate:[AuthGuard],
    data: { roles: ["user"]}
  },
  {
    path:'login',
    component:LoginComponent
  },
  {
    path:'register',
    component:RegisterComponent
  }
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  
})
export class AppRoutingModule { }
