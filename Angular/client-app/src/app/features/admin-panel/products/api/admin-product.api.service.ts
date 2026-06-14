import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { PaginationList } from '../../../../models/paginationlist';
import { map } from 'rxjs';
import { GetAllProductQuery } from '../../../product/models/get-all-product-query';
import { Product } from '../../../product/models/product';

@Injectable({
  providedIn: 'root',
})
export class AdminProductApiService {
  private baseUrl: string =
    environment.apiUrl + '/product-service/api/product/';
  constructor(private httpClient: HttpClient) {}

  add(product: Product) {
    return this.httpClient.post<Product>(this.baseUrl, product);
  }
  delete(id: string) {
    return this.httpClient.delete(this.baseUrl + id);
  }

  update(product: Product) {
    return this.httpClient.put<Product>(this.baseUrl + product.id, product);
  }

  updateCharacteristic(productId: string, characteristic: string) {
    return this.httpClient.put(
      this.baseUrl + 'updateCharacteristic/' + productId,
      { JSON: characteristic },
    );
  }
}
