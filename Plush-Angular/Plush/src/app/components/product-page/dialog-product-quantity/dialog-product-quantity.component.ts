import { Component, Inject, Injector, OnInit, Optional } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProductViewModule } from 'src/app/modules/product-view.module';
import { AlertService } from 'src/app/services/alert.service';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-dialog-product-quantity',
  templateUrl: './dialog-product-quantity.component.html',
  styleUrls: ['./dialog-product-quantity.component.css']
})
export class DialogProductQuantityComponent implements OnInit {

  formProduct= new FormGroup({
    quantity: new FormControl('1',[Validators.required])
  });

  product:ProductViewModule;
  ngOnInit(): void {
  }
  constructor( @Optional() @Inject(MAT_DIALOG_DATA) public data: any, private orderService:OrderService, private injector:Injector) {
    this.product = data['product'] as ProductViewModule;
  }

  onSubmit():void{
    debugger
    this.orderService.AddToBasket(this.product.productID,this.formProduct.value.quantity).subscribe(cr => {
      this.injector.get(AlertService).showSucces("The product was added into you shopping cart!");
    });
  
  }
}
