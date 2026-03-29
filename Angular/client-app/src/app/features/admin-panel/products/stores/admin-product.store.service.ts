import { Injectable } from '@angular/core';

import { Product } from '../../../product/models/product';
import { AdminProductApiService } from '../api/admin-product.api.service';
import { BehaviorSubject, catchError, debounceTime, of, Subject, switchMap, tap } from 'rxjs';
import { PaginationList } from '../../../../models/paginationlist';
import { ProductApiService } from '../../../product/services/api/product.api.service';
import { GetAllProductQuery } from '../../../product/models/get-all-product-query';

@Injectable({
  providedIn: 'root'
})
export class AdminProductStoreService {
  private _searchProducts$ = new Subject<void>();

  private _productList = new BehaviorSubject<PaginationList<Product>>({
    list: [],
    totalCount: 0,
  });

  private readonly _query = new GetAllProductQuery();

  public productList$ = this._productList.asObservable();
  constructor(private readonly api: ProductApiService, private readonly adminApi: AdminProductApiService) {
    this._searchProducts$
      .pipe(
        debounceTime(500),
        switchMap(() =>
          this.api
            .getAll(this._query)
            .pipe(catchError(() => of({ list: [], totalCount: 0 }))),
        ),
        //cache
      )
      .subscribe((res) => this._productList.next(res));
    this._searchProducts$.next();
  }

  get query(){
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
  //is this correct?
  add(product: Product) {
    return this.adminApi.add(product).pipe(tap(response=>{
      const newList = this._productList;
      newList.value.list.push(response)
      this._productList.next(newList.value);
    }));
  }


  delete(id: string) {
    return this.adminApi.delete(id).pipe(tap(response=>{
      const newList = this._productList;
      newList.value.list.filter(p => p.id == id);
      this._productList.next(newList.value);
    }));
  }

  update(product: Product) {
    return this.adminApi.update(product).pipe(tap(response=>{

      const newList = this._productList;
      newList.value.list.map((p) => (p.id == product.id ? product : p));

      this._productList.next(newList.value);
    }));
  }

  updateCharacteristic(productId: string, characteristic: string) {
    return this.adminApi.updateCharacteristic(productId, characteristic);
  }
}
