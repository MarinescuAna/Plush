import { NgModule } from '@angular/core';
import {  RouterModule, Routes } from '@angular/router'
import {ProductsComponent} from './components/product-page/products/products.component';
import {MainPageComponent} from './components/category-page/main-page/main-page.component';
import { ViewProductsComponent } from './components/product-page/view-products/view-products.component';
import { RegisterComponent } from './components/account-page/register/register.component';
import { LoginComponent } from './components/account-page/login/login.component';
import{AuthGuard} from 'src/app/shared/auth.guard';
import { WishlistComponent } from './components/product-page/wishlist/wishlist.component';
import { DeliveryComponent } from './components/delivery-provider-page/delivery/delivery.component';
import { ProviderComponent } from './components/delivery-provider-page/provider/provider.component';

const routes: Routes = [
  {
    path: 'category',
    component: MainPageComponent,
    canActivate:[AuthGuard],
    data: { roles: ["admin"]}
  },
  {
    path: '',
    redirectTo: '/products',
    pathMatch: 'full'
  },
  {
    path:'delivery',
    component: DeliveryComponent,
    canActivate:[AuthGuard],
    data: { roles: ["admin"]}
  },
  {
    path:'provider',
    component: ProviderComponent,
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
  },
  { path: 'products', 
  component:ProductsComponent 
}
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  
})
export class AppRoutingModule { }
