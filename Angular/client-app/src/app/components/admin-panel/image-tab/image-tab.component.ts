import { CommonModule } from '@angular/common';
import { Component, inject, TemplateRef } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbNavModule, NgbOffcanvas } from '@ng-bootstrap/ng-bootstrap';
import { Imagee } from '../../../models/image';
import { Product } from '../../../models/product';
import { ProductService } from '../../../services/product.service';
import { GetAllProductQuery } from '../../../models/Queries/get-all-product-query';
import { AdminImageService } from '../../../services/admin-image.service';

@Component({
  selector: 'app-image-tab',
  imports: [NgbNavModule, FormsModule, CommonModule],
  templateUrl: './image-tab.component.html',
  styleUrl: './image-tab.component.css'
})
export class ImageTabComponent {
  constructor(
    private productService: ProductService,
    private adminImageService: AdminImageService,
  ) {
    this.query.itemPerPage = 100;
    this.query.page = 1;
    this.query.sort = "id";
    this.getAllProducts();
  }
  products: Product[] = [];
  image: any;
  activeImages: Imagee[] = [];
  imageId = '';
  offcanvasService = inject(NgbOffcanvas);
  productId = '';
  query = new GetAllProductQuery();

  getAllProducts() {
    this.productService.getAll(this.query).subscribe({
      next: (res) => {
        this.products = res.list;
      }
    })
  }
  openImageContextBottom(content: TemplateRef<any>) {
    this.offcanvasService.open(content, { position: 'bottom' });
  }

  getImages() {
    this.getAllProducts();
    this.activeImages = this.products.find(x => x.id == this.productId)?.images as Imagee[];
  }

  addImage() {
    this.adminImageService.add(this.productId, this.image).subscribe({
      next: (res) => {
        window.location.reload();
      }
    })
  }

  removeImage(id: string) {
    this.adminImageService.delete(id).subscribe({
      next: (res) => {
        window.location.reload();
      }
    })
  }

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      const file = input.files[0];
      this.image = file;
    }
  }

}
