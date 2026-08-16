
import { Component, inject, TemplateRef, ViewEncapsulation } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbNavModule, NgbOffcanvas } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../../../../product/models/product';
import { Imagee } from '../../../../product/models/image';
import { GetAllProductQuery } from '../../../../product/models/get-all-product-query';
import { ProductStoreService } from '../../../../product/services/storages/product.store.service';
import { AdminImageStoreService } from '../../stores/admin-image.store.service';


@Component({
  selector: 'app-image-tab',
  imports: [NgbNavModule, FormsModule],
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
    private productService: ProductStoreService,
    private adminImageService: AdminImageStoreService,
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
