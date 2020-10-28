import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router'
import {ProductsComponent} from './components/product-page/products/products.component';
import {MainPageComponent} from './components/category-page/main-page/main-page.component';
import { ProviderDeliveryViewComponent } from './components/delivery-provider-page/provider-delivery-view/provider-delivery-view.component';
const routes: Routes = [
  {
    path: 'category',
    component: MainPageComponent
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
    component: ProviderDeliveryViewComponent
  }
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  
})
export class AppRoutingModule { }
