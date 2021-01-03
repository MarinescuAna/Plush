import { Component, Injector, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DeliveryDDLModule } from 'src/app/modules/delivery-ddl.module';
import { OrderService } from 'src/app/services/order.service';
import { UserInformationModule } from 'src/app/modules/user-info.module';
import { ProviderDeliveryService } from 'src/app/services/provider-delivery-service';
import { AuthService } from 'src/app/shared/auth.service';
import { AlertService } from 'src/app/services/alert.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-information',
  templateUrl: './information.component.html',
  styleUrls: ['./information.component.css']
})
export class InformationComponent implements OnInit {

  formInfo: FormGroup;
  email:string;
  deliveries: DeliveryDDLModule[];
  constructor(private deliveryService:ProviderDeliveryService,
    private authService:AuthService,
    private orderService:OrderService,
    private injector: Injector,
    private route:Router) { }

  ngOnInit(): void {
    this.deliveryService.getDeliveries().subscribe(cr => {
      this.deliveries=cr as DeliveryDDLModule[];
    });
    this.email=this.authService.getEmail();
    this.formInfo=new FormGroup({
      address: new FormControl("",[Validators.required]),
      remarks: new FormControl(''),
      payment: new FormControl('',[Validators.required]),
      phone: new FormControl("",[Validators.required]),
      delivery: new FormControl('',[Validators.required])
    });
  }

  onSubmit():void{
    let information=new UserInformationModule();
    information.address=this.formInfo.value.address;
    information.remarks=this.formInfo.value.remarks;
    information.phone=this.formInfo.value.phone;
    information.delivery=this.formInfo.value.delivery;
    information.payment=this.formInfo.value.payment;
    this.orderService.FinishOrder(information).subscribe(cr=>{
      localStorage.removeItem('OrderId');
      this.injector.get(AlertService).showSucces("The order has been placed!");
      this.route.navigateByUrl('/products');
     }); 
  }
 
  
}
