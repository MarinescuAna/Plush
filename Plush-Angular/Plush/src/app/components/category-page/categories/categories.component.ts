import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CategoryModule } from 'src/app/modules/category.module';
import { CategoryService } from 'src/app/services/category-service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  formCategory = new FormGroup({
    name: new FormControl('',[Validators.required])
  });

  constructor(private service: CategoryService) { }

  ngOnInit(): void {
  }

  onSubmit(): void{
    const temp=new CategoryModule();
    temp.name=this.formCategory.value.name;
    debugger
    this.service.createCategory(temp);
  }

}
