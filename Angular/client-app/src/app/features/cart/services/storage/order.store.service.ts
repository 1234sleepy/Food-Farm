import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Order } from '../../models/order';
import { OrderCreateModel } from '../../models/orderCreateModel';
import { OrderApiService } from '../api/order.api.service';

@Injectable({
  providedIn: 'root'
})
export class OrderStoreService {
  private baseUrl: string = environment.apiUrl + '/order/';
  constructor(private readonly api: OrderApiService) { }

   add(order: OrderCreateModel) {
      return this.api.add(order);
    }

    getByPhone(phone: string) {
      return this.api.getByPhone(phone);
    }
}
