import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ProviderModule } from 'src/app/modules/provider.module';
import { ProviderDeliveryService } from 'src/app/services/provider-delivery-service';

@Component({
  selector: 'app-provider-table',
  templateUrl: './provider-table.component.html',
  styleUrls: ['./provider-table.component.css']
})
export class ProviderTableComponent implements AfterViewInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  displayedColumns: string[] = [ 
    'providerName', 
    'providerContactData',
    'symbol'];

  dataSource : any;

  ngAfterViewInit() {
    debugger
    this.service.getProviders().subscribe( cr =>
      {
        this.dataSource=new MatTableDataSource<ProviderModule>(cr as ProviderModule[]);
        this.dataSource.paginator = this.paginator;
      }
    ); 
   
    
  }
  constructor(private service: ProviderDeliveryService) {
   
   }

   deleteProvider(id: any):void {
    this.service.deleteProvider(id).subscribe(cr =>{
      window.location.reload();
    });
   }
}
