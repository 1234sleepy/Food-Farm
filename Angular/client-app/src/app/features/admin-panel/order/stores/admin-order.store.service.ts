import { Injectable } from '@angular/core';
import { Order } from '../../../cart/models/order';
import { GetAllOrderQuery } from '../../models/get-all-order-query';
import { map } from 'rxjs';
import { AdminOrderApiService } from '../api/admin-order.api.service';

@Injectable({
  providedIn: 'root'
})
export class AdminOrderStoreService {
    constructor(private readonly api: AdminOrderApiService) { }
    getAll(query: GetAllOrderQuery) {
      return this.api.getAll(query).pipe(map(response => {
              response.list.forEach(element => {
                element.disabled = true;
                element.priceWithDiscount = element.totalPrice - element.totalDiscount;
              });
              return response;
            }));
    }

    delete(id: string) {
      return this.api.delete(id);
    }
    getById(id: string) {
      return this.api.getById(id);
    }
    update(order: Order) {
      return this.api.update(order);
    }
}
