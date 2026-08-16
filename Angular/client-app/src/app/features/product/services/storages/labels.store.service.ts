import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';

import { LabelsApiService } from '../api/labels.api.service';
import {
  BehaviorSubject,
  catchError,
  debounce,
  debounceTime,
  of,
  Subject,
  switchMap,
  tap,
} from 'rxjs';
import { Label } from '../../models/label';

@Injectable({
  providedIn: 'root',
})
export class LabelsStoreService {
  private _searchLabels$ = new Subject<void>();

  private _lablesList = new BehaviorSubject<Label[]>([]);

  public labelList$ = this._lablesList.asObservable();

  constructor(private readonly api: LabelsApiService) {
    this._searchLabels$.pipe(
      debounceTime(500),
      switchMap(() => this.api.getAll().pipe(catchError(() => of([])))),
    );
  }
  search() {
    this._searchLabels$.next();
  }

  add(name: string, color: string) {
    return this.api.add(name, color).pipe(
      tap((response) => {
        const newList = { ...this._lablesList.value };
        newList.push(response);
        this._lablesList.next(newList);
      }),
    );
  }

  addToProduct(productId: string, labelId: string) {
    return this.api.addToProduct(productId, labelId);
  }

  removeFromProduct(productId: string, labelId: string) {
    return this.api.removeFromProduct(productId, labelId);
  }
}
