import { Component, Inject, OnInit, Optional } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-product-image-view',
  templateUrl: './product-image-view.component.html',
  styleUrls: ['./product-image-view.component.css']
})
export class ProductImageViewComponent implements OnInit {
  src: string;

  ngOnInit(): void {
  }
  constructor( @Optional() @Inject(MAT_DIALOG_DATA) public data: any) {
    this.src = data.src;
  }


}
