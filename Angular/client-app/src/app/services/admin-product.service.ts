import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Product } from '../models/product';
import { PaginationList } from '../models/paginaion-list.model';
import { map } from 'rxjs';
import { GetAllProductQuery } from '../models/Queries/get-all-product-query';

@Injectable({
  providedIn: 'root'
})
export class AdminProductService {
  private baseUrl: string = environment.apiUrl + '/admin/product/';
  constructor(private httpClient: HttpClient) { }

  getAll(query : GetAllProductQuery) {
    return this.httpClient.get<PaginationList<Product>>(
      this.baseUrl,
      { params: query.toParams() }
    ).pipe(map(response => {
      response.list.forEach(element => {
        element._quantity = 1;
        element._mainImageUrl = element.images?.length ? element.images.find(img => img.isMain)!.imageUrl : "/productPlaceholder.png";
      });
      return response;
    }));
  }

  add(product: Product) {
    return this.httpClient.post<Product>(this.baseUrl, product);
  }
  delete(id: string) {
    return this.httpClient.delete(this.baseUrl + id);
  }
  getById(id: string) {
    return this.httpClient.get<Product>(this.baseUrl + id);
  }
  update(product: Product) {
    return this.httpClient.put<Product>(this.baseUrl + product.id, product);
  }
}
