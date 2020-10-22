import { Component, OnInit } from '@angular/core';

export interface PeriodicElement {
  name: string;
  ages: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { name: 'Hydrogen', ages: '1.0079'},
  { name: 'Helium', ages: '4.0026'},
  { name: 'Lithium', ages: '6.94'},
];

@Component({
  selector: 'app-view-category',
  templateUrl: './view-category.component.html',
  styleUrls: ['./view-category.component.css']
})
export class ViewCategoryComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  displayedColumns: string[] = [ 'name', 'weight', 'symbol'];
  dataSource = ELEMENT_DATA;
}
