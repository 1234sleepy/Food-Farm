import { Component, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LabelsService } from '../../../services/labels.service';
import { Label } from '../../../models/label';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ProductService } from '../../../services/product.service';
import { Product } from '../../../models/product';

@Component({
  selector: 'app-labels-tab',
  imports: [CommonModule, FormsModule],
  templateUrl: './labels-tab.component.html',
  styleUrl: './labels-tab.component.css',
  encapsulation: ViewEncapsulation.None
})
export class LabelsTabComponent {
  id: string = '';
  labels : Label[] = [];
  usedLabels : Label[] = [];
  product = {} as Product;

  constructor(private labelService: LabelsService, private route: ActivatedRoute, private router: Router, private productService: ProductService) {
    this.id = this.route.snapshot.params['id'];

    this.labelService.getAll().subscribe({
      next: (labels) => {
        this.labels = labels;
      }
    });
    this.productService.getById(this.id).subscribe({
      next: (res) => {  
        this.product = res;

        if(this.product.labels != null)
        {
          this.usedLabels = this.product.labels;
        }
      
        this.usedLabels.forEach(element => {
             this.labels = this.labels.filter(f => f.id != element.id);
        });
      
        console.log(this.labels);
        console.log(this.usedLabels);
      }
    })
  }

  addToProduct(labelId: string){
    this.labelService.addToProduct(this.id, labelId).subscribe({
      next:(res) => {
        window.location.reload();
      }
    })
  }

  removeFromProduct(labelId: string){    
    this.labelService.removeFromProduct(this.id, labelId).subscribe({
      next:(res) => {
        window.location.reload();
      }
    })
  }

  back() {
    this.router.navigate(['admin/product']);
  }
}
