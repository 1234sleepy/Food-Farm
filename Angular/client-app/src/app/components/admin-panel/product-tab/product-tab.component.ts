import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbCollapseModule, NgbNavModule, NgbOffcanvas, NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { Product } from '../../../models/product';
import { GetAllProductQuery } from '../../../models/Queries/get-all-product-query';
import { AdminProductService } from '../../../services/admin-product.service';
import { ProductService } from '../../../services/product.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-tab',
  imports: [NgbNavModule, FormsModule, CommonModule, NgbCollapseModule, NgbPaginationModule],
  templateUrl: './product-tab.component.html',
  styleUrl: './product-tab.component.css'
})
export class ProductTabComponent {
  constructor(private adminProductService: AdminProductService,
    private productService: ProductService,

  ) {
    this.query.itemPerPage = 10;
    this.query.page = 1;
    this.query.sort = "id";
    this.getAllProducts();
  }


  query = new GetAllProductQuery();
  products: Product[] = [];
  totalCount = 0;

  offcanvasService = inject(NgbOffcanvas);

  active = 'product';
  createProductControlisCollapsed = true;
  newProduct = {} as Product;
  createProductResult = '';


  createProduct() {
    this.adminProductService.add(this.newProduct).subscribe({
      next: (res) => {
        this.newProduct = {} as Product;
        this.products.push(res);
      }
    })
  }

  updateProduct(product: Product) {
    this.adminProductService.update(product).subscribe({
      next: (res) => {
        this.products = this.products.map(p => p.id == res.id ? res : p);
      }
    })
  }



  deleteProduct(id: string) {
    this.adminProductService.delete(id).subscribe({
      next: (res) => {
        this.products = this.products.filter(p => p.id !== id);
      }
    })
  }

  getAllProducts() {
    this.productService.getAll(this.query).subscribe({
      next: (res) => {
        this.products = res.list;
        this.totalCount = res.totalCount;
      }
    })
  }

  editProduct(product: Product) {
    if (product.disabled == true) {
      product.disabled = false;

    }
    else if (product.disabled == false) {
      product.disabled = true;
      this.updateProduct(product);
    }
  }
}
