import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Data } from '@angular/router';
import { Observable } from 'rxjs';

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
  createOrder(custID: string, prodID: string, quantity: number, orderDate: Date, shipDate: Date, shipMode: string): Observable<number> {
    const body = "";
    const params = new HttpParams()
      .append('custID', custID)
      .append('prodID', prodID)
      .append('quantity', quantity)
      .append('orderDate', orderDate.toJSON())
      .append('shipDate', shipDate.toJSON())
      .append('shipMode', shipMode)

    return this.
    _http.post<number>(this.baseUrl + '/add-order', body, { 'params': params });
  }
  deleteOrder(orderID: number): Observable<string> {
    const params = new HttpParams()
      .append('orderID', orderID);
    return this._http.delete<string>(this.baseUrl + '/delete-order', { 'params': params });
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
