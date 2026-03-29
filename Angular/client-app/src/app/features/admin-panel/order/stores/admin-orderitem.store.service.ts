import { Injectable } from '@angular/core';
import { OrderItem } from '../../../cart/models/orderItem';
import { AdminOrderItemApiService } from '../api/admin-orderitem.api.service';

@Injectable({
  providedIn: 'root',
})
export class AdminOrderItemStoreService {
  constructor(private readonly api: AdminOrderItemApiService) {}

  add(ord: OrderItem) {
    return this.api.add(ord);
  }

  delete(prodid: string, orderId: string) {
    return this.api.delete(prodid, orderId);
  }
}
