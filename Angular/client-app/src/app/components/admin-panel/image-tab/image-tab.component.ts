import { CommonModule } from '@angular/common';
import { Component, inject, TemplateRef, ViewEncapsulation } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbNavModule, NgbOffcanvas } from '@ng-bootstrap/ng-bootstrap';
import { Imagee } from '../../../models/image';
import { Product } from '../../../models/product';
import { ProductService } from '../../../services/product.service';
import { GetAllProductQuery } from '../../../models/Queries/get-all-product-query';
import { AdminImageService } from '../../../services/admin-image.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-image-tab',
  imports: [NgbNavModule, FormsModule, CommonModule],
  templateUrl: './image-tab.component.html',
  styleUrl: './image-tab.component.css',
  encapsulation: ViewEncapsulation.None
})
export class ImageTabComponent {

  product = {} as Product;
  image: any;
  activeImages: Imagee[] = [];
  imageId = '';
  offcanvasService = inject(NgbOffcanvas);
  productId = '';
  query = new GetAllProductQuery();

  constructor(
    private productService: ProductService,
    private adminImageService: AdminImageService,
    private route: ActivatedRoute,
    private router: Router
  ) {
      this.productId = this.route.snapshot.params['id'];
      this.query.itemPerPage = 100;
      this.query.page = 1;
      this.query.sort = "id";


      this.productService.getById(this.productId).subscribe({
      next: (res) => {
          this.product = res;
          this.activeImages = this.product.images || [];  
      }
    })
  }

  openImageContextBottom(content: TemplateRef<any>) {
    this.offcanvasService.open(content, { position: 'bottom' });
  }

  addImage() {
    this.adminImageService.add(this.productId, this.image).subscribe({
      next: (res) => {
        this.activeImages.push(res);
      }
    })
  }

  removeImage(id: string) {
    this.adminImageService.delete(id).subscribe({
      next: (res) => {
        this.activeImages = this.activeImages.filter(image => image.id !== id);
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

  back() {
    this.router.navigate(['admin/product']);
  }

}
