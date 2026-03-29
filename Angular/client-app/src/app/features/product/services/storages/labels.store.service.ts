import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { List } from 'ckeditor5';
import { LabelsApiService } from '../api/labels.api.service';

@Injectable({
  providedIn: 'root'
})
export class LabelsStoreService {
  constructor(private readonly api: LabelsApiService) { }

  getAll(){
    return this.api.getAll();
  }

  add(name: string, color: string){
    return this.api.add(name, color);
  }

  addToProduct(productId: string, labelId: string){
    return this.api.addToProduct(productId, labelId);
  }

  removeFromProduct(productId: string, labelId: string){
    return this.api.removeFromProduct(productId, labelId);
  }

}
