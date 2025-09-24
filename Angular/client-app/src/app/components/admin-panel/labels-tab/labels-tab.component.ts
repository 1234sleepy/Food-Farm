import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LabelsService } from '../../../services/labels.service';
import { Label } from '../../../models/label';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-labels-tab',
  imports: [CommonModule, FormsModule],
  templateUrl: './labels-tab.component.html',
  styleUrl: './labels-tab.component.css'
})
export class LabelsTabComponent {
  id: string = '';
  labels = [] as Label[];
    constructor(private labelService: LabelsService, private route: ActivatedRoute, private router: Router) {
    this.id = this.route.snapshot.params['id'];
    this.labelService.getAll().subscribe({
      next: (labels) => {
        this.labels = labels;
      }
    });
  }

  addToProduct(labelId: string){
    this.labelService.addToProduct(this.id, labelId).subscribe({})
  }
}
