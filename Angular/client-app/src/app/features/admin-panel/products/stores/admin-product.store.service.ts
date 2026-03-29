import { Injectable } from '@angular/core';

import { Product } from '../../../product/models/product';
import { AdminProductApiService } from '../api/admin-product.api.service';
import {
  BehaviorSubject,
  catchError,
  debounceTime,
  of,
  Subject,
  switchMap,
  tap,
} from 'rxjs';
import { PaginationList } from '../../../../models/paginationlist';
import { ProductApiService } from '../../../product/services/api/product.api.service';
import { GetAllProductQuery } from '../../../product/models/get-all-product-query';
import { ProductStoreService } from '../../../product/services/storages/product.store.service';

@Injectable({
  providedIn: 'root',
})
export class AdminProductStoreService extends ProductStoreService {
  constructor(
    private readonly adminApi: AdminProductApiService,
    api: ProductApiService,
  ) {
    super(api);
  }

  add(product: Product) {
    return this.adminApi.add(product).pipe(
      tap((response) => {
        const newList = { ...this._productList.value };
        newList.list.push(response);
        newList.totalCount++;
        this._productList.next(newList);
      }),
    );
  }

  delete(id: string) {
    return this.adminApi.delete(id).pipe(
      tap((response) => {
        const newList = { ...this._productList.value };
        newList.list.filter((p) => p.id == id);
        newList.totalCount--;
        this._productList.next(newList);
      }),
    );
  }

  update(product: Product) {
    return this.adminApi.update(product).pipe(
      tap((response) => {
        const newList = { ...this._productList.value };
        newList.list.map((p) => (p.id == product.id ? product : p));
        this._productList.next(newList);
      }),
    );
  }

  updateCharacteristic(productId: string, characteristic: string) {
    return this.adminApi.updateCharacteristic(productId, characteristic);
  }
}
