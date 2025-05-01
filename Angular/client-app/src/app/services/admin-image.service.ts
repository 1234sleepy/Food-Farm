import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { PaginationList } from '../models/paginaion-list.model';
import { Order } from '../models/order';
import { GetAllOrderQuery } from '../models/Queries/get-all-order-query';
import { map } from 'rxjs';
import { Imagee } from '../models/image';

@Injectable({
  providedIn: 'root'
})
export class AdminImageService {
  private baseUrl: string = environment.apiUrl + '/admin/image/';
  constructor(private httpClient: HttpClient) { }

  
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
