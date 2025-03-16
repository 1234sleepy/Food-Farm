import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Order } from '../models/order';
import { OrderCreateModel } from '../models/orderCreateModel';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private baseUrl: string = environment.apiUrl + '/order/';
  constructor(private httpClient: HttpClient) { }

   add(order: OrderCreateModel) {
      return this.httpClient.post<Order>(this.baseUrl, order);
    }

    getByPhone(phone: string) {
      return this.httpClient.get<Order>(this.baseUrl + phone);
    }
}
