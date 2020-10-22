import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  formCategory = new FormGroup({
    name: new FormControl('',[Validators.required]),
    ages: new FormControl('',[Validators.required])
  });

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit(): void{
    /*const temp=new GroupCreateModule();
    temp.description=this.formCreateGroup.value.description;
    temp.groupName=this.formCreateGroup.value.name;
    temp.studentCreatorEmail=this.authService.getUserEmail();
    temp.teacherEmail=this.formCreateGroup.value.emailTeacher;
    debugger
    this.groupService.CreateNewGroup(temp);*/
  }

}
