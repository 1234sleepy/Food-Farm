import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';

import { PaginationList } from '../../../../models/paginationlist';
import {
  BehaviorSubject,
  map,
  Subject,
  tap,
  debounceTime,
  switchMap,
  catchError,
  of,
} from 'rxjs';
import { ProductApiService } from '../../../product/services/api/product.api.service';
import { GetAllProductQuery } from '../../../product/models/get-all-product-query';
import { Product } from '../../../product/models/product';
@Injectable({
  providedIn: 'root',
})
export class ProductListStoreService {
  private _searchProducts$ = new Subject<void>();
  private _productList = new BehaviorSubject<PaginationList<Product>>({
    list: [],
    totalCount: 0,
  });

  public productList$ = this._productList.asObservable();

  private readonly _query = new GetAllProductQuery();

  constructor(private readonly api: ProductApiService) {
    this._searchProducts$
      .pipe(
        //debounceTime(500),
        switchMap(() =>
          this.api.getAll(this._query).pipe(
            catchError((error) => {
              console.log(error);
              return of({ list: [], totalCount: 0 });
            }),
          ),
        ),
        tap((response) =>
          response.list.forEach((element) => {
            console.log('ProductApiService');
            this.productPipe(element);
            console.log('ProductApiService');
          }),
        ),
        //cache
      )
      .subscribe((res) => this._productList.next(res));
    this._searchProducts$.next();
    console.log(132);
  }

  get query() {
    return this._query;
  }
  get page() {
    return this._query.page;
  }
  set page(value: number) {
    this._query.page = value;
    this._searchProducts$.next();
  }

  search() {
    this._searchProducts$.next();
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
