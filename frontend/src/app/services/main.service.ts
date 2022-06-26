import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MainService {
  readonly baseUrl: string = "https://localhost:5001";
    constructor(private _http: HttpClient) { }

}
