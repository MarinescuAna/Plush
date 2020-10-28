import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ProviderDeliveryService } from 'src/app/services/provider-delivery-service';
import{DeliveryModule} from 'src/app/modules/delivery.module';

@Component({
  selector: 'app-delivery-component',
  templateUrl: './delivery-component.component.html',
  styleUrls: ['./delivery-component.component.css']
})
export class DeliveryComponentComponent implements OnInit {
  formDelivery = new FormGroup({
    name: new FormControl('',[Validators.required]),
    specifications: new FormControl('',[Validators.required])
  });
  
  constructor(private service:ProviderDeliveryService) { }

  ngOnInit(): void {
  }

  onSubmit():void{
    let newRecord=new DeliveryModule();
    newRecord.specification=this.formDelivery.value.specifications;
    newRecord.name=this.formDelivery.value.name;
    debugger
    this.service.createDelivery(newRecord);
  }
}
