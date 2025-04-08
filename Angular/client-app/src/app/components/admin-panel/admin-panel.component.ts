import { Component } from '@angular/core';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgbCollapseModule } from '@ng-bootstrap/ng-bootstrap';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { AdminProductService } from '../../services/admin-product.service';
import { GetAllProductQuery } from '../../models/Queries/get-all-product-query';
import { AdminOrderService } from '../../services/admin-order.service';
import { Order } from '../../models/order';
import { OrderService } from '../../services/order.service';

@Component({
  selector: 'app-admin-panel',
  imports: [NgbNavModule,FormsModule, CommonModule, NgbCollapseModule], 
  templateUrl: './admin-panel.component.html',
  styleUrl: './admin-panel.component.css'
})
export class AdminPanelComponent {
  constructor(    private adminProductService: AdminProductService, private productService: ProductService, private adminOrderService: AdminOrderService, private orderService: OrderService) { 
    this.query.itemPerPage = 100;
    this.query.page = 1;
    this.query.sort = "id";
    this.getAllProducts();

    this.getAllOrders();
  }
  query = new GetAllProductQuery();
  products : Product[] = [];
  orders : Order[] = [];
	active = 'product';
  
  createProductControlisCollapsed = true;


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





    getAllOrders(){
      this.adminOrderService.getAll(this.query).subscribe({
        next: (res) => {
          console.log(res);
          this.orders = res.list;
        }
      })
    }

    deleteOrder(id: string){
      this.adminOrderService.delete(id).subscribe({
        next: (res) => {
          console.log(res);
          window.location.reload();
        }
      })
    }

    updateOrder(order: Order){
      this.adminOrderService.update(order).subscribe({
        next: (res) => {
          console.log(res);
          
        }
      })
    }

    editOrder(order : Order){
      if(order.disabled == true)
      {
        order.disabled = false;

      }
      else if(order.disabled == false)
        {
          order.disabled = true;
                this.updateOrder(order);
        }
      console.log(order)
    }
    
}