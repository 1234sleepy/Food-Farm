import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { Label } from '../models/label';
import { PaginationList } from '../models/paginaion-list.model';
import { List } from 'ckeditor5';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class LabelsService {
  private baseUrl: string = environment.apiUrl + '/label/';
  constructor(private httpClient: HttpClient) { }

  getAll(){
    return this.httpClient.get<Label[]>(this.baseUrl+"all");
  }

  add(name: string, color: string){
    return this.httpClient.post<Label>(this.baseUrl, { name, color });
  }

  addToProduct(productId: string, labelId: string){
    return this.httpClient.post(this.baseUrl + `add-label-to-product/`, {productId, labelId});
  }

  removeFromProduct(productId: string, labelId: string){
    return this.httpClient.delete(this.baseUrl + `remove-label-from-product/`+ productId+ "+"+ labelId);
  }

}
