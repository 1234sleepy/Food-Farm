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
       this.productPipe(element);
      });
      return response;
    }));
  }

    getById(id: string) {
      return this.httpClient.get<Product>(this.baseUrl + id).pipe(map(product => {
        return this.productPipe(product);
      }));
    }

    private productPipe(product : Product) {
        product._quantity = 1;
        product.disabled = true;  
        product._mainImageUrl = product.images?.length ? product.images.find(img => img.isMain)!.imageUrl : "/productPlaceholder.png";
        if(product.images?.length === 0) {
          product.images = [{imageUrl: product._mainImageUrl, isMain: true}as any] ;
        }
        product.characteristics = JSON.parse(product.characteristics as any ?? '[]');
        product._rating = product.totalRating / product.totalCommentsQuantity || 0;
        product._isDiscounted = !!product.discountPrice;
        product._priceWithDiscount = product.price - (product.discountPrice || 0);

        return product;
    }
}
