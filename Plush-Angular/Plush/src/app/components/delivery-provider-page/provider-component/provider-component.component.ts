import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ProviderModule } from 'src/app/modules/provider.module';
import{ProviderDeliveryService} from'src/app/services/provider-delivery-service';

@Component({
  selector: 'app-provider-component',
  templateUrl: './provider-component.component.html',
  styleUrls: ['./provider-component.component.css']
})
export class ProviderComponentComponent implements OnInit {

  formProvider = new FormGroup({
    name: new FormControl('',[Validators.required]),
    address: new FormControl('',[Validators.required])
  });
  
  constructor(private service:ProviderDeliveryService) { }

  ngOnInit(): void {
  }

  onSubmit():void{
    let newRecord=new ProviderModule();
    newRecord.contactData=this.formProvider.value.address;
    newRecord.name=this.formProvider.value.name;
    debugger
    this.service.createProvider(newRecord);
  }

}
