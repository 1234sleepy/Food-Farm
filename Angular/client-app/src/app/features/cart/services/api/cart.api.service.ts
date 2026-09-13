import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { CartObject } from '../../models/cartObject';


@Injectable({
  providedIn: 'root',
})
export class OrderApiService {
  private baseUrl: string = environment.apiUrl + '/cart-service/api/cart/add-product-to-cart';
  constructor(private httpClient: HttpClient) {}

  add(cartO: CartObject) {
    return this.httpClient.post<CartObject>(this.baseUrl, cartO);
  }

}
