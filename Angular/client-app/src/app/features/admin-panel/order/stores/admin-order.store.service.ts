import { Injectable } from '@angular/core';
import { Order } from '../../../cart/models/order';
import { GetAllOrderQuery } from '../../models/get-all-order-query';
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
import { AdminOrderApiService } from '../api/admin-order.api.service';
import { PaginationList } from '../../../../models/paginationlist';

@Injectable({
  providedIn: 'root',
})
export class AdminOrderStoreService {
  private _searchOrder$ = new Subject<void>();

  private _orderList = new BehaviorSubject<PaginationList<Order>>({
    list: [],
    totalCount: 0,
  });

  private readonly _query = new GetAllOrderQuery();
  public orderList$ = this._orderList.asObservable();

  constructor(private readonly api: AdminOrderApiService) {
    this._searchOrder$
      .pipe(
        debounceTime(500),
        switchMap(() =>
          this.api
            .getAll(this._query)
            .pipe(catchError(() => of({ list: [], totalCount: 0 }))),
        ),
      )
      .subscribe((res) => this._orderList.next(res));
  }

  get query() {
    return this._query;
  }
  get page() {
    return this._query.page;
  }
  set page(value: number) {
    this._query.page = value;
    this._searchOrder$.next();
  }

  search() {
    this._searchOrder$.next();
  }

  delete(id: string) {
    return this.api.delete(id).pipe(
      tap((response) => {
        const newList = { ...this._orderList.value };
        newList.list.filter((p) => p.id == id);
        newList.totalCount--;
        this._orderList.next(newList);
      }),
    );
  }

  getOrderById(id: string) {
    return this._orderList.value.list.find((o) => o.id == id) || ({} as Order);
  }

  update(order: Order) {
    return this.api.update(order).pipe(
      tap((repsone) => {
        const newList = { ...this._orderList.value };
        newList.list.map((p) => (p.id == order.id ? order : p));
        this._orderList.next(newList);
      }),
    );
  }
}
