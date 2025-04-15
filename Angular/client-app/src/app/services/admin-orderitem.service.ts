import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { PaginationList } from '../models/paginaion-list.model';
import { Order } from '../models/order';
import { OrderItem } from '../models/orderItem';

@Injectable({
  providedIn: 'root'
})
export class AdminOrderItemService {
  private baseUrl: string = environment.apiUrl + '/order-item/';
  constructor(private httpClient: HttpClient) { }

    add(ord: OrderItem)
    {
        return this.httpClient.post<OrderItem>(this.baseUrl, ord);
    }

    delete(prodid: string, orderId: string) {
      return this.httpClient.delete(this.baseUrl + prodid +"+"+ orderId);
    }
}
