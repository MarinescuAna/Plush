import { Injectable, Injector } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { DeliveryDDLModule } from '../modules/delivery-ddl.module';
import { DeliveryModule } from '../modules/delivery.module';
import { ProviderDDLModule } from '../modules/provider-ddl.module';
import { ProviderDeliveryInsertModule } from '../modules/provider-delivery-insert.module';
import { ProviderDeliveryModule } from '../modules/provider-delivery.module';
import { ProviderModule } from '../modules/provider.module';
import { DataService } from './data.service';

@Injectable({
  providedIn: 'root'
})

export class ProviderDeliveryService extends DataService {
  constructor(injector: Injector,private route: Router) {
    super(injector, 'ProviderDelivery');
  }

  createProvider(module: ProviderModule): void{
    super.post<any>('InsertProvider', module).subscribe(cr => {
        this.alertService.showSucces('The provider was created!');
        window.location.reload();
      });
  }

  createDelivery(module: DeliveryModule): void{
    super.post<any>('InsertDelivery', module).subscribe(cr => {
        this.alertService.showSucces('The delivery method was created!');
        window.location.reload();
      });
  }

  getProvidersDeliveries():Observable<ProviderDeliveryModule[]>{
    return super.getMany<ProviderDeliveryModule>('GetProvidersDeliveries');
  }

  getProviders():Observable<ProviderDDLModule[]>{
    return super.getMany<ProviderDDLModule>('GetProviders');
  }
  
  getDeliveries():Observable<DeliveryDDLModule[]>{
    return super.getMany<DeliveryDDLModule>('GetDelivery');
  }

  createProviderDelivery(module: ProviderDeliveryInsertModule): void{
    super.post<any>('InsertProviderDelivery', module).subscribe(cr => {
        this.alertService.showSucces('Created!');
        window.location.reload();
      });
  }

  deleteProviderDelivery(id: any):any{
    return super.delete(id,'DeleteProviderDelivery?id=');
  }
}