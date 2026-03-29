import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Product } from '../../models/product';
import { GetAllProductQuery } from '../../models/get-all-product-query';

import { PaginationList } from '../../../../models/paginationlist';
import { map, tap } from 'rxjs';
import { ProductApiService } from '../api/product.api.service';
@Injectable({
  providedIn: 'root',
})
export class ProductStoreService {
  constructor(private readonly api: ProductApiService) {}

  getAll(query: GetAllProductQuery) {
    return this.api.getAll(query).pipe(
      tap((response) =>
        response.list.forEach((element) => {
          this.productPipe(element);
        }),
      ),
    );
  }

  getById(id: string) {
    return this.api.getById(id).pipe(
      map((product) => {
        return this.productPipe(product);
      }),
    );
  }

  private productPipe(product: Product) {
    product._quantity = 1;
    product.disabled = true;
    product._mainImageUrl = product.images?.length
      ? product.images.find((img) => img.isMain)!.imageUrl
      : '/productPlaceholder.png';
    if (product.images?.length === 0) {
      product.images = [
        { imageUrl: product._mainImageUrl, isMain: true } as any,
      ];
    }
    product.characteristics = JSON.parse(
      (product.characteristics as any) ?? '[]',
    );
    product._rating = product.totalRating / product.totalCommentsQuantity || 0;
    product._isDiscounted = !!product.discountPrice;
    product._priceWithDiscount = product.price - (product.discountPrice || 0);

    return product;
  }
}
