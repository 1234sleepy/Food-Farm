import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Product } from '../../../../product/models/product';
import { RichTextAreaComponent } from '../../../../../core/shared/forms/rich-text-area/rich-text-area.component';
import { NgbActiveModal, NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { LabelsStoreService } from '../../../../product/services/storages/labels.store.service';

@Component({
  selector: 'app-product-form',
  imports: [
    RichTextAreaComponent,
    NgbNavModule,
    FormsModule,
    CommonModule,
    NgSelectModule,
  ],
  templateUrl: './product-form.component.html',
  styleUrl: './product-form.component.css',
})
export class ProductFormComponent implements OnInit {
  constructor(
    public readonly labelsService: LabelsStoreService,
    private readonly modal: NgbActiveModal,
  ) {}

  ngOnInit(): void {
    this.newProduct = { ...this.newProduct };
  }

  @Input() newProduct = {} as Product;
  @Output() clickResult = new EventEmitter<Product>();
  resultButtonClick() {
    this.newProduct.labels = [];
    this.clickResult.emit({ ...this.newProduct });
    this.modal.close(this.newProduct);
  }
}
