import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

export interface PeriodicElement {
  name: string;
  ages: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { name: 'Hydrogen', ages: '1.0079'},
  { name: 'Helium', ages: '4.0026'},
  { name: 'Lithium', ages: '6.94'},
  { name: 'Lithium', ages: '6.94'},
  { name: 'Lithium', ages: '6.94'},
  { name: 'Lithium', ages: '6.94'},
  { name: 'Lithium', ages: '6.94'},
  { name: 'Lithium', ages: '6.94'},
  { name: 'Lithium', ages: '6.94'},
  { name: 'Lithium', ages: '6.94'},
  { name: 'Lithium', ages: '6.94'},
  { name: 'Lithium', ages: '6.94'},
  { name: 'Lithium', ages: '6.94'},
  { name: 'Lithium', ages: '6.94'},
  { name: 'Lithium', ages: '6.94'},
  { name: 'Lithium', ages: '6.94'},
];

@Component({
  selector: 'app-view-category',
  templateUrl: './view-category.component.html',
  styleUrls: ['./view-category.component.css']
})
export class ViewCategoryComponent implements OnInit, AfterViewInit  {

  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
  constructor() { }

  ngOnInit(): void {
  }
  displayedColumns: string[] = [ 'name', 'weight', 'symbol'];
  dataSource = new MatTableDataSource<PeriodicElement>(ELEMENT_DATA);
}
