import { Component, OnInit } from '@angular/core';
import { MainService, Order, Customer, Product  } from 'src/app/services/main.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
orders: Order[] = []
customers: Customer[] = [];
products: Product[] = [];
  constructor(private _main: MainService) { }

  ngOnInit(): void {
    this._main.getAllOrders().subscribe(data => this.orders = data);
    this._main.getAllCustomers().subscribe(data => this.customers = data);
    this._main.getAllProducts().subscribe(data => this.products = data);

  }
  onClickSubmit(result: any) {
    console.log(result);
  }
}
