import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { from } from 'rxjs';
import{ProviderDeliveryInsertModule} from 'src/app/modules/provider-delivery-insert.module';
import { ProviderDeliveryService } from 'src/app/services/provider-delivery-service';
import{ProviderDDLModule} from 'src/app/modules/provider-ddl.module';
import{DeliveryDDLModule} from 'src/app/modules/delivery-ddl.module';

@Component({
  selector: 'app-provider-delivery-component',
  templateUrl: './provider-delivery-component.component.html',
  styleUrls: ['./provider-delivery-component.component.css']
})
export class ProviderDeliveryComponentComponent implements OnInit {

  formProvider = new FormGroup({
    deliveryCompany: new FormControl('',[Validators.required]),
    specification: new FormControl('',[Validators.required]),
    price: new FormControl('',[Validators.required]),
    deliveryName: new FormControl('',[Validators.required]),
    providerName: new FormControl('',[Validators.required])
  });

  providers: ProviderDDLModule[];
  deliveries: DeliveryDDLModule[];

  constructor(private service:ProviderDeliveryService) { }

  ngOnInit(): void {
    this.service.getProviders().subscribe(
      cr =>{
        this.providers = cr as ProviderDDLModule[];
      }
    );
    this.service.getDeliveries().subscribe(
      cr =>{
        this.deliveries = cr as DeliveryDDLModule[];
      }
    );
  }

  onSubmit():void{
    let newRecord=new ProviderDeliveryInsertModule();
    newRecord.deliveryCompany=this.formProvider.value.deliveryCompany;
    newRecord.providerName=this.formProvider.value.providerName;
    newRecord.deliveryName=this.formProvider.value.deliveryName;
    newRecord.specification=this.formProvider.value.specification;
    newRecord.price=this.formProvider.value.price;
    debugger
    this.service.createProviderDelivery(newRecord);
  }


}
