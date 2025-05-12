import { Component, inject, TemplateRef } from '@angular/core';
import { NgbNavModule, NgbOffcanvas } from '@ng-bootstrap/ng-bootstrap';
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
import { AdminOrderItemService } from '../../services/admin-orderitem.service';
import { OrderItem } from '../../models/orderItem';
import { ToastrService } from 'ngx-toastr';
import { AdminImageService } from '../../services/admin-image.service';
import { Imagee } from '../../models/image';
import { AccountService } from '../../services/account.service';
import { routes } from '../../app.routes';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-admin-panel',
  imports: [NgbNavModule,FormsModule, CommonModule, NgbCollapseModule], 
  templateUrl: './admin-panel.component.html',
  styleUrl: './admin-panel.component.css'
})
export class AdminPanelComponent {
  constructor(    private adminProductService: AdminProductService,
     private productService: ProductService,
      private adminOrderService: AdminOrderService,
       private orderService: OrderService,
      private adminOrderItemService: AdminOrderItemService,
      private toastr: ToastrService,
      private adminImageService: AdminImageService,
      private accountService: AccountService,
      private router: Router
      ) { 
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
  orderItem = {} as OrderItem;
  offcanvasService = inject(NgbOffcanvas);

  image: any;

  activeImages: Imagee[] = [];

  imageId = '';

  activeOrder = {} as Order;

  productId = '';
  
  
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
    


    deleteItemOrder(prodId: string, ordId: string, order: Order){
      this.adminOrderItemService.delete(prodId, ordId).subscribe({
        next: (res) => {
          console.log(res);
          window.location.reload();
        }
      })
 
    }

    createOrderItem(orderId: string){
      console.log(this.activeOrder.items)
      console.log(this.orderItem)
      if(this.activeOrder.items.find(x => x.productId == this.orderItem.productId))
      {
        this.toastr.error("Product is already in order (You can change quantity by deleting and adding again)");
      }else{
        if(this.orderItem.orderId!=null && this.orderItem.productId!=null && this.orderItem.quantity!=0)
          {
    
          this.adminOrderItemService.add(this.orderItem).subscribe({
            next: (res) => {
              console.log(res);
              this.newProduct = {} as Product;
              window.location.reload();
            }
          })
          }
      }
    }

    openContextBottom(content: TemplateRef<any>, order: Order) {
      this.activeOrder = order; 
      this.orderItem = {} as OrderItem;
      this.orderItem.orderId=order.id;
      this.offcanvasService.open(content, { position: 'bottom' });
    }

    openImageContextBottom(content: TemplateRef<any>) {

      this.offcanvasService.open(content, { position: 'bottom' });
    }

    getImages(){
      this.activeImages = this.products.find(x => x.id == this.productId)?.images as Imagee[];
    }
    
    addImage(){
      this.adminImageService.add(this.productId,this.image).subscribe({
        next: (res) => {
          console.log(res);
          window.location.reload();
        }
      })
    }

    removeImage(id: string){
      this.adminImageService.delete(id).subscribe({
        next: (res) => {
          console.log(res);
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

  logout(){
    this.accountService.logout().subscribe({
      next: (res) => {
        console.log(res);
        this.router.navigateByUrl('');
      }
    })
  }

}