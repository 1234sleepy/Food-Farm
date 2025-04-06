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
    // You can initialize any data here if needed
  }

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
        this.createProductResult = 'Id: ' + res.id + '\nName: ' + res.name + '\nDescription: ' + res.description + '\nPrice: ' + res.price + '\nDiscount Price: ' + res.discountPrice + '\n' + 'Product was successfully created!';
      }
    })

  }

    updProduct = {} as Product;
    updateProductResult = '';
  
    updateProduct(){
      this.adminProductService.update(this.updProduct).subscribe({
        next: (res) => {
          console.log(res);
          this.updProduct = {} as Product; 
          this.updateProductResult = 'Id: ' + res.id + '\nName: ' + res.name + '\nDescription: ' + res.description + '\nPrice: ' + res.price + '\nDiscount Price: ' + res.discountPrice + '\n' + 'Product was successfully updated!';
        }
      })
    }

    deleteId = '';
    deleteProductResult = '';
  
    deleteProduct(){
      this.adminProductService.delete(this.deleteId).subscribe({
        next: (res) => {
          console.log(res);
          this.deleteProductResult = 'Product was successfully deleted!';
        }
      })
    }

    
    productId = '';
    getProductResult = '';
  
    getProduct(){
      this.productService.getById(this.productId).subscribe({
        next: (res) => {
          console.log(res);
          this.getProductResult = JSON.stringify(res, null, 2);
        }
      })
    }

    query = new GetAllProductQuery();
    getAllProductsResult = '';
  
    getAllProducts(){
      this.productService.getAll(this.query).subscribe({
        next: (res) => {
          console.log(res);
          this.getAllProductsResult = JSON.stringify(res, null, 2);
        }
      })
    }
    
}