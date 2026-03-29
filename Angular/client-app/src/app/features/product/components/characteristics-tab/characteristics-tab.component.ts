import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ProductStoreService } from '../../services/storages/product.store.service';
import { CharacteristicModel } from '../../models/characteristicModel';

@Component({
  selector: 'app-characteristics-tab',
  imports: [CommonModule, FormsModule],
  templateUrl: './characteristics-tab.component.html',
  styleUrl: './characteristics-tab.component.css'
})
export class CharacteristicsTabComponent {
  characteristic: CharacteristicModel[] = [];
  id: string = '';

constructor(private productService: ProductStoreService, private route: ActivatedRoute) {
    this.id = this.route.snapshot.params['id'];
    this.productService.getById(this.id).subscribe({
      next: (product) => {
        this.characteristic = product.characteristics ?? [];
        console.log(product.characteristics);
      }
    });
  }
}
