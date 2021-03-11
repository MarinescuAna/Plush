import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { CategoryViewModule } from 'src/app/modules/category-view.module';
import { CategoryService } from 'src/app/services/category-service';


@Component({
  selector: 'app-view-category',
  templateUrl: './view-category.component.html',
  styleUrls: ['./view-category.component.css']
})
export class ViewCategoryComponent implements AfterViewInit  {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  displayedColumns: string[] = [ 'name', 'symbol'];
  dataSource : any;
  ngAfterViewInit() {
    this.categoryService.getCategories().subscribe( cr =>
      {
        this.dataSource=new MatTableDataSource<CategoryViewModule>(cr as CategoryViewModule[]);
        this.dataSource.paginator = this.paginator;
      }
    );  
  }
  constructor(private categoryService: CategoryService, private route: Router) {
   
   }

   deleteCategory(id: any):void {
      this.categoryService.deleteCategory(id).subscribe(cr => {
        window.location.reload();
      });
   }
}
