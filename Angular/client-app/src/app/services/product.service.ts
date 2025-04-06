import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Product } from '../models/product';
import { GetAllProductQuery } from '../models/Queries/get-all-product-query';
import { PaginationList } from '../models/paginaion-list.model';
import { map } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private baseUrl: string = environment.apiUrl + '/product/';
  constructor(  private httpClient: HttpClient) { }

  getAll(query : GetAllProductQuery) {
    return this.httpClient.get<PaginationList<Product>>(
      this.baseUrl,
      { params: query.toParams() }
    ).pipe(map(response => {
      response.list.forEach(element => {
        element._quantity = 1;
        element._mainImageUrl = element.images?.length ? element.images.find(img => img.isMain)!.imageUrl : "/productPlaceholder.png";
        if(element.images?.length === 0) {
          element.images = [{imageUrl: element._mainImageUrl, isMain: true}as any] ;
        }
      });
      return response;
    }));
  }

    getById(id: string) {
      return this.httpClient.get<Product>(this.baseUrl + id);
    }
}
