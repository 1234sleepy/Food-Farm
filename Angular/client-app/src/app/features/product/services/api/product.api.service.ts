import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Product } from '../../models/product';
import { GetAllProductQuery } from '../../models/get-all-product-query';
import { PaginationList } from '../../../../models/paginationlist';
import { map } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ProductApiService {
  private baseUrl: string = environment.apiUrl + '/product/';
  constructor(  private httpClient: HttpClient) { }

  getAll(query : GetAllProductQuery) {
    return this.httpClient.get<PaginationList<Product>>(
      this.baseUrl,
      { params: query.toParams() }
    );
  }

    getById(id: string) {
      return this.httpClient.get<Product>(this.baseUrl + id);
    }
}
