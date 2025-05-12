import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { PaginationList } from '../models/paginaion-list.model';
import { Order } from '../models/order';
import { GetAllOrderQuery } from '../models/Queries/get-all-order-query';
import { map } from 'rxjs';
import { ProductService } from './product.service';

@Injectable({
  providedIn: 'root'
})
export class AdminOrderService {
  private baseUrl: string = environment.apiUrl + '/admin/order/';
  constructor(private httpClient: HttpClient, private productService: ProductService) { }

    getAll(query: GetAllOrderQuery) {
      return this.httpClient.get<PaginationList<Order>>(
        this.baseUrl,
        { params: query.toParams() }).pipe(map(response => {
              response.list.forEach(element => {
                element.disabled = true;
                element.priceWithDiscount = element.totalPrice - element.totalDiscount;
                element.productsList = [];
                element.items.forEach(item => {
                  this.productService.getById(item.productId).subscribe({
                    next: (res) => {
                      element.productsList.push(res);
                    }
                  });
                });
              });
              return response;
            }));
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
