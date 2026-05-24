import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Order } from '../../../cart/models/order';
import { GetAllOrderQuery } from '../../models/get-all-order-query';
import { PaginationList } from '../../../../models/paginationlist';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AdminOrderApiService {
  private baseUrl: string = environment.apiUrl + '/order-service/api/order';
  constructor(private httpClient: HttpClient) {}

  getAll(query: GetAllOrderQuery) {
    return this.httpClient.get<PaginationList<Order>>(this.baseUrl, {
      params: query.toParams(),
    });
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
