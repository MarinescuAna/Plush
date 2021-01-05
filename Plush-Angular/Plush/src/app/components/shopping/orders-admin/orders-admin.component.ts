import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import{OrderAdminModule} from 'src/app/modules/order-admin.module';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-orders-admin',
  templateUrl: './orders-admin.component.html',
  styleUrls: ['./orders-admin.component.css']
})
export class OrdersAdminComponent implements AfterViewInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  displayedColumns: string[] = [ 'OrderId', 'UserEmail', 'UserAddress', 'UserPhone', 'Delivery', 'Payment', 'TotalPrice', 'Remarks','OrderDate', 'symbol'];
  dataSource : any;
  ngAfterViewInit() {
    this.SpinnerService.show();
    this.orderService.GetOrdersAsAdmin().subscribe( cr =>
      {
        this.dataSource=new MatTableDataSource<OrderAdminModule>(cr as OrderAdminModule[]);
        this.dataSource.paginator = this.paginator; 
        this.SpinnerService.hide();
      }

    );  
  }
  constructor(private orderService: OrderService, private route: Router,private SpinnerService: NgxSpinnerService) {
   
   }

   deliver(id: any):void {
      this.orderService.DeliverOrder(id).subscribe(cr => {
        window.location.reload();
      });
   }
}
