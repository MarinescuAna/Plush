import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {ProviderDeliveryModule} from 'src/app/modules/provider-delivery.module';
import { ProviderDeliveryService } from 'src/app/services/provider-delivery-service';

@Component({
  selector: 'app-provider-delivery-table',
  templateUrl: './provider-delivery-table.component.html',
  styleUrls: ['./provider-delivery-table.component.css']
})
export class ProviderDeliveryTableComponent implements AfterViewInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  displayedColumns: string[] = [ 
    'providerName', 
    'providerContactData',
    'deliveryName',
    'deliverySpecification',
    'specification',
    'deliveryCompany',
    'price',
    'symbol'];

  dataSource : any;

  ngAfterViewInit() {
    this.service.getProvidersDeliveries().subscribe( cr =>
      {
        this.dataSource=new MatTableDataSource<ProviderDeliveryModule>(cr as ProviderDeliveryModule[]);
        this.dataSource.paginator = this.paginator;
      }
    ); 
   
    
  }
  constructor(private service: ProviderDeliveryService) {
   
   }

   deleteProviderDelivery(id: any):void {
    this.service.deleteProviderDelivery(id).subscribe(cr =>{
      window.location.reload();
    });
   }
}
