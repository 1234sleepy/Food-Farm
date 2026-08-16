import { CommonModule } from '@angular/common';
import { Component, inject, ViewEncapsulation, ChangeDetectionStrategy } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {
  NgbCollapseModule,
  NgbModal,
  NgbNavModule,
  NgbOffcanvas,
  NgbPaginationModule,
} from '@ng-bootstrap/ng-bootstrap';
import { GetAllProductQuery } from '../../../../product/models/get-all-product-query';
import { ActivatedRoute, Router } from '@angular/router';
import { Label } from '../../../../product/models/label';
import { NgSelectModule } from '@ng-select/ng-select';

import { ProductStoreService } from '../../../../product/services/storages/product.store.service';
import { LabelsStoreService } from '../../../../product/services/storages/labels.store.service';
import { Product } from '../../../../product/models/product';
import { AdminProductStoreService } from '../../stores/admin-product.store.service';
import { RichTextAreaComponent } from '../../../../../core/shared/forms/rich-text-area/rich-text-area.component';
import { ProductFormComponent } from '../product-form/product-form.component';

@Component({
  standalone: true,
  selector: 'app-product-tab',
  imports: [
    NgbNavModule,
    FormsModule,
    CommonModule,
    NgbCollapseModule,
    NgbPaginationModule,
    NgSelectModule,
  ],
  templateUrl: './product-tab.component.html',
  changeDetection: ChangeDetectionStrategy.Eager,
  styleUrl: './product-tab.component.css',
})
export class ProductTabComponent {
  constructor(
    public readonly adminProductService: AdminProductStoreService,
    private router: Router,
    public readonly labelsService: LabelsStoreService,
    private readonly modal: NgbModal,
  ) {}

  active = 'product';
  createProductControlisCollapsed = true;

  createProductResult = '';

  changeToCharacteristicsUrl(id: string) {
    this.router.navigate([`admin/product/characteristics/${id}`]);
  }

  changeToLabelsUrl(id: string) {
    this.router.navigate([`admin/product/labels/${id}`]);
  }

  openProductForm() {
    this.modal.open(ProductFormComponent).result.then((product) => {});
  }

  createProduct() {
    this.modal.open(ProductFormComponent).result.then((product) => {
      this.adminProductService.add(product).subscribe();
    });
  }

  // labelsSelection(label: Label) {
  //   if (this.newProduct.labels?.indexOf(label)) {
  //     this.newProduct.labels?.push(label);
  //   } else {
  //     this.newProduct.labels?.splice(
  //       this.newProduct.labels?.indexOf(label) - 1,
  //       1,
  //     );
  //   }
  //   console.log(this.newProduct.labels);
  // }

  updateProduct(product: Product) {
    const formModal = this.modal.open(ProductFormComponent);

    formModal.componentInstance.newProduct = product;
    console.log(formModal.componentInstance.newProduct);
    formModal.result.then((newProduct) => {
      this.adminProductService.update(newProduct).subscribe();
    });
  }

  deleteProduct(id: string) {
    this.adminProductService.delete(id).subscribe();
  }

  // editProduct(product: Product) {
  //   if (product.disabled == true) {
  //     product.disabled = false;
  //   } else if (product.disabled == false) {
  //     product.disabled = true;
  //     this.updateProduct(product);
  //   }
  // }
}
