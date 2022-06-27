import { Component, OnInit } from '@angular/core';
import { MainService, Order, Customer, Product  } from 'src/app/services/main.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
shipMode: string[] = ["Second Class", "Standard Class", "First Class", "Overnight Express"];
orders: Order[] = []
customers: Customer[] = [];
products: Product[] = [];
createCustID: string = "";
createProdID: string = "";
createOrderDate: Date = new Date(2022, 6, 27);
createShipDate: Date = new Date(2022, 6, 27);
createQuantity: number = 1;
createShipMode: string = this.shipMode[0];


constructor(private _main: MainService) { }

  ngOnInit(): void {
    this.fetchData();

  }
  onChange(event: any) {

  }
  shippingChange(event: any) {
    console.log(event);

  }
  deleteOrder(orderID: number) {
    this._main.deleteOrder(orderID).subscribe(data => data,
      () => {
        this._main.getAllOrders().subscribe( null, () => {
        });
      });
  }

  createOrder() {
    this._main.createOrder(this.createCustID, this.createProdID, this.createQuantity, this.createOrderDate, this.createShipDate, this.createShipMode).subscribe(null, null, () => {
      this.fetchData();
    });
  }
  fetchData() {
    this._main.getAllOrders().subscribe(data => this.orders = data);
    this._main.getAllCustomers().subscribe(data => this.customers = data, null, () => {
      this.createCustID = this.customers[0].custID;
    });
    this._main.getAllProducts().subscribe(data => this.products = data, null, () => {
      this.createProdID = this.products[0].prodID;
    });

  }
}
