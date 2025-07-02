import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ProductService } from '../../../services/product.service';
import { CharacteristicModel } from '../../../models/CharacteristicModel';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-characteristics-tab',
  imports: [CommonModule, FormsModule],
  templateUrl: './characteristics-tab.component.html',
  styleUrl: './characteristics-tab.component.css'
})
export class CharacteristicsTabComponent {
  characteristic: CharacteristicModel[] = [];
  id: string = '';

constructor(private productService: ProductService, private route: ActivatedRoute) {
    this.id = this.route.snapshot.params['id'];
    this.productService.getById(this.id).subscribe({
      next: (product) => {
        this.characteristic = product.characteristics ?? [];
        console.log(product.characteristics);
      }
    });
  }
}
