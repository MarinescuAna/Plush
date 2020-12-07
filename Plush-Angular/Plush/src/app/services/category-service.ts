import { Injectable, Injector } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { CategoryViewModule } from '../modules/category-view.module';
import { CategoryModule } from '../modules/category.module';
import { DataService } from './data.service';

@Injectable({
  providedIn: 'root'
})

export class CategoryService extends DataService {
  constructor(injector: Injector,private route: Router) {
    super(injector, 'Category');
  }

  createCategory(module: CategoryModule): void{
    super.post<any>('InsertCategory', module).subscribe(cr => {
        this.alertService.showSucces('The category was created!');
        window.location.reload();
      });
  }

  getCategories(): Observable<CategoryViewModule[]>{
    return super.getMany<CategoryViewModule>('GetCategories');
  }

  deleteCategory(id: any):any{
    return super.delete(id,'DeleteCategory?id=');
  }
}