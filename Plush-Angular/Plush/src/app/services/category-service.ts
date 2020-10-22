import { Injectable, Injector } from '@angular/core';
import { Router } from '@angular/router';
import { CategoryModule } from '../modules/category.module';
import { DataService } from './data.service';

@Injectable({
  providedIn: 'root'
})

export class GroupService extends DataService {
  constructor(injector: Injector,private route: Router) {
    super(injector, 'Category');
  }

  CreateCategory(module: CategoryModule){
    super.post<CategoryModule>('CreateCategory', module).subscribe(cr => {
        this.alertService.showSucces('The category was created!');
      });
  }

}