import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router'
import {ProductsComponent} from './components/product-page/products/products.component';
import {CategoriesComponent} from './components/category-page/categories/categories.component';
const routes: Routes = [
  {
    path: 'category',
    component: CategoriesComponent
  },
  {
    path: 'products',
    component: ProductsComponent
  },
  {
    path: '',
    redirectTo: '/products',
    pathMatch: 'full'
  }
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  
})
export class AppRoutingModule { }
