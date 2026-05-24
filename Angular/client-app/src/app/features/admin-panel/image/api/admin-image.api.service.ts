import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';

import { PaginationList } from '../../../../models/paginationlist';
import { Order } from '../../../cart/models/order';
import { GetAllOrderQuery } from '../../models/get-all-order-query';
import { map } from 'rxjs';
import { Imagee } from '../../../product/models/image';

@Injectable({
  providedIn: 'root',
})
export class AdminImageApiService {
  private baseUrl: string = environment.apiUrl + '/product-service/api/image/';
  constructor(private httpClient: HttpClient) {}

  delete(id: string) {
    return this.httpClient.delete(this.baseUrl + id);
  }
  getById(id: string) {
    return this.httpClient.get<Imagee>(this.baseUrl + id);
  }

  setMain(id: string) {
    return this.httpClient.put<Imagee>(this.baseUrl + id, {});
  }

  add(id: string, image: any) {
    const formData = new FormData();
    formData.append('file', image);
    return this.httpClient.post<Imagee>(this.baseUrl + id, formData);
  }
}
