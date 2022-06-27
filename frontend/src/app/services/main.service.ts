import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MainService {
  readonly baseUrl: string = "https://localhost:5001";
    constructor(private _http: HttpClient) { }


    getAllOrders(): Observable<Order[]> {
      return this._http.get<Order[]>(this.baseUrl + '/orders');
    }
    getAllCustomers(): Observable<Customer[]> {
      return this._http.get<Customer[]>(this.baseUrl + '/customers');
    }
    getAllProducts(): Observable<Product[]> {
      return this._http.get<Product[]>(this.baseUrl + '/products');
    }
    createOrder(orderID: number, custID: string, prodID: string, orderDate: Date, quantity: number, shipDate: Date, shipMode :string): Observable<number> {
      const body = "";
      const params = new HttpParams()
        .append('orderID', orderID)
        .append('custID', custID)
        .append('prodID', prodID)
        .append('orderDate',orderDate.toDateString())
        .append('quantity', quantity)
        .append('shipDate', shipDate.toDateString())
        .append('shipMode', shipMode)

      return this._http.post<number>(this.baseUrl + '/create-order', body, { 'params': params });
    }
}
export interface Order {
  orderID: number;
  orderDate: Date;
  quantity: number;
  shipDate: Date;
  custID: string;
  prodID: string;
  shipMode: string;
}
export interface Customer {
  custID: string;
  fullName: string;
  country: string;
  city: string;
  state: string;
  postCode: number;
  segID: number;
  region: string;
}
export interface Product {
  prodID: string;
  description: string;
  unitPrice: number;
  catID: number
}
