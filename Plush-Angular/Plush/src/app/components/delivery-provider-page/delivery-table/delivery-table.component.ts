import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { DeliveryDDLModule } from 'src/app/modules/delivery-ddl.module';
import { ProviderDeliveryService } from 'src/app/services/provider-delivery-service';

@Component({
  selector: 'app-delivery-table',
  templateUrl: './delivery-table.component.html',
  styleUrls: ['./delivery-table.component.css']
})
export class DeliveryTableComponent implements OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  displayedColumns: string[] = [ 
    'deliveryName',
    'deliverySpecification',
    'price',
    'symbol'];

  dataSource : any;

  ngOnInit() {
    debugger
    this.service.getDeliveries().subscribe( cr =>
      {
        debugger
        this.dataSource=new MatTableDataSource<DeliveryDDLModule>(cr as DeliveryDDLModule[]);
        this.dataSource.paginator = this.paginator;
      }
    ); 
   
    
  }
  constructor(private service: ProviderDeliveryService) {
   debugger
   }

   deleteDelivery(id: any):void {
    this.service.deleteDelivery(id).subscribe(cr =>{
      window.location.reload();
    });
   }
}
