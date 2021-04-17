import { Component, Inject, OnInit, Optional } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-product-specifications',
  templateUrl: './product-specifications.component.html',
  styleUrls: ['./product-specifications.component.css']
})
export class ProductSpecificationsComponent implements OnInit {

  text:string;

  ngOnInit(): void {
  }
  constructor( @Optional() @Inject(MAT_DIALOG_DATA) public data: any) {
    this.text = data.text;
  }

}
