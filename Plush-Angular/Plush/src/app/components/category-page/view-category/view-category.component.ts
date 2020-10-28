import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { CategoryViewModule } from 'src/app/modules/category-view.module';
import { CategoryService } from 'src/app/services/category-service';


@Component({
  selector: 'app-view-category',
  templateUrl: './view-category.component.html',
  styleUrls: ['./view-category.component.css']
})
export class ViewCategoryComponent implements AfterViewInit  {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  displayedColumns: string[] = [ 'categoryId','name', 'ages', 'symbol'];
  dataSource : any;
  index: any;
  ngAfterViewInit() {
    this.categoryService.getCategories().subscribe( cr =>
      {
        debugger
        this.dataSource=new MatTableDataSource<CategoryViewModule>(cr as CategoryViewModule[]);
        this.dataSource.paginator = this.paginator;
      }
    ); 
   
    
  }
  constructor(private categoryService: CategoryService) {
   
   }

   deleteCategory(i: any, id: any):void {
   
    debugger
   }
}
