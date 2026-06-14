import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Product } from '../../models/product';
import { GetAllProductQuery } from '../../models/get-all-product-query';

import { PaginationList } from '../../../../models/paginationlist';
import {
  BehaviorSubject,
  catchError,
  debounceTime,
  map,
  of,
  Subject,
  switchMap,
  tap,
} from 'rxjs';
import { ProductApiService } from '../api/product.api.service';
@Injectable({
  providedIn: 'root',
})
export class ProductStoreService {
  protected _searchProducts$ = new Subject<void>();

  protected _productList = new BehaviorSubject<PaginationList<Product>>({
    list: [],
    totalCount: 0,
  });

  protected readonly _query = new GetAllProductQuery();

  public productList$ = this._productList.asObservable();

  constructor(private readonly api: ProductApiService) {
    this._searchProducts$
      .pipe(
        debounceTime(500),
        switchMap(() =>
          this.api
            .getAll(this._query)
            .pipe(catchError(() => of({ list: [], totalCount: 0 }))),
        ),
        tap((response) =>
          response.list.forEach((element) => {
            this.productPipe(element);
          }),
        ),
      )
      .subscribe((res) => this._productList.next(res));
    console.log(this._productList);
    this._searchProducts$.next();
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
