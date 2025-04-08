import { Component } from '@angular/core';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgbCollapseModule } from '@ng-bootstrap/ng-bootstrap';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { AdminProductService } from '../../services/admin-product.service';
import { GetAllProductQuery } from '../../models/Queries/get-all-product-query';

@Component({
  selector: 'app-admin-panel',
  imports: [NgbNavModule,FormsModule, CommonModule, NgbCollapseModule], 
  templateUrl: './admin-panel.component.html',
  styleUrl: './admin-panel.component.css'
})
export class AdminPanelComponent {
  constructor(    private adminProductService: AdminProductService, private productService: ProductService) { 
    this.query.itemPerPage = 100;
    this.query.page = 1;
    this.query.sort = "id";
    this.getAllProducts();
  }
  query = new GetAllProductQuery();
  products : Product[] = [];
	active = 'product';
  createProductControlisCollapsed = true;
  updateProductisCollapsed = true;
  deleteProductisCollapsed = true;
  getProductisCollapsed = true;
  getAllProductsisCollapsed = true;

  newProduct = {} as Product;
  createProductResult = '';

  createProduct(){
    this.adminProductService.add(this.newProduct).subscribe({
      next: (res) => {
        console.log(res);
        this.newProduct = {} as Product;
        window.location.reload();
      }
    })

  }

    updProduct = {} as Product;
    updateProductResult = '';
  
    updateProduct(product: Product){
      this.adminProductService.update(product).subscribe({
        next: (res) => {
          console.log(res);
          
        }
      })
    }

    deleteProduct(id: string){
      this.adminProductService.delete(id).subscribe({
        next: (res) => {
          console.log(res);
          window.location.reload();
        }
      })
    }

    getAllProducts(){
      this.productService.getAll(this.query).subscribe({
        next: (res) => {
          console.log(res);
          this.products = res.list;
        }
      })
    }

    editProduct(product : Product){
      if(product.disabled == true)
      {
              product.disabled = false;

      }
      else if(product.disabled == false)
        {
                product.disabled = true;
                this.updateProduct(product);
        }
      console.log(product)
    }
    
}