import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { PaginationList } from '../models/paginaion-list.model';
import { Order } from '../models/order';

@Injectable({
  providedIn: 'root'
})
export class AdminOrderService {
  private baseUrl: string = environment.apiUrl + '/admin/order/';
  constructor(private httpClient: HttpClient) { }

    getAll(page: number, itemPerPage: number, sort : ""|"id"|"age"|"name") {
      const params = new HttpParams().set('page',page).append("itemperpage", itemPerPage).append('sort',sort);
      return this.httpClient.get<PaginationList<Order>>(
        this.baseUrl,
        {params}
      );
    }
  
    delete(id: string) {
      return this.httpClient.delete(this.baseUrl + id);
    }
    getById(id: string) {
      return this.httpClient.get<Order>(this.baseUrl + id);
    }
    update(order: Order) {
      return this.httpClient.put<Order>(this.baseUrl + order.id, order);
    }
}
