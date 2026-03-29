import { Injectable } from '@angular/core';
import { AdminImageApiService } from '../api/admin-image.api.service';

@Injectable({
  providedIn: 'root'
})
export class AdminImageStoreService {
  constructor(private readonly api: AdminImageApiService) { }


    delete(id: string) {
      return this.api.delete(id);
    }
    getById(id: string) {
      return this.api.getById(id);
    }

    setMain(id: string) {
        return this.api.getById(id);
    }

    add(id: string, image: any) {
      return this.api.add(id, image);
    }
}
