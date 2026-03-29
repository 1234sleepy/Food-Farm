import { Component, inject, TemplateRef, ViewEncapsulation } from '@angular/core';
import { Order } from '../../../cart/models/order';
import { GetAllOrderQuery } from '../../models/get-all-order-query';
import { ToastrService } from 'ngx-toastr';
import { OrderItem } from '../../../cart/models/orderItem';
import { NgbCollapseModule, NgbDropdownModule, NgbNavModule, NgbOffcanvas, NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AdminOrderItemStoreService } from '../../services/stores/admin-orderitem.store.service';
import { AdminOrderStoreService } from '../../services/stores/admin-order.store.service';
import { Product } from '../../../product/models/product';

@Component({
  selector: 'app-order-tab',
  imports: [NgbNavModule, FormsModule, CommonModule, NgbCollapseModule, NgbDropdownModule, NgbPaginationModule],
  templateUrl: './order-tab.component.html',
  styleUrl: './order-tab.component.css',
  encapsulation: ViewEncapsulation.None
})
export class OrderTabComponent {
  constructor(private adminOrderService: AdminOrderStoreService,
    private adminOrderItemService: AdminOrderItemStoreService,
    private toastr: ToastrService) {
    this.query.itemPerPage = 5;
    this.query.page = 1;
    this.query.sort = "id";
    this.getAllOrders();
  }
  offcanvasService = inject(NgbOffcanvas);
  query = new GetAllOrderQuery();
  orders: Order[] = [];
  totalCount = 0;
  active = 'product';
  order = {} as Order;
  orderItem = {} as OrderItem;
  activeOrder = {} as Order;
  newProduct = {} as Product;

  getAllOrders() {
    this.adminOrderService.getAll(this.query).subscribe({
      next: (res) => {
        this.orders = res.list;
        this.totalCount = res.totalCount;
      }
    })
  }

  deleteOrder(id: string) {
    this.adminOrderService.delete(id).subscribe({
      next: (res) => {
        this.orders = this.orders.filter(o =>o.id != id);
      }
    })
  }

  updateOrder(order: Order) {
    this.adminOrderService.update(order).subscribe({
      next: (res) => {
        res.disabled = true;
        this.orders = this.orders.map(p =>p.id == res.id ? res : p);
      }
    })
  }

  editOrder(order: Order) {
    if (order.status.name.toLowerCase() != 'completed') {
      if (order.disabled == true) {
        order.disabled = false;
      }
      else if (order.disabled == false) {
        this.updateOrder(order);
      }
    } else {
      this.toastr.error("You cannot edit completed orders");
    }

  }

  deleteItemOrder(prodId: string, ordId: string, order: Order) {
    this.adminOrderItemService.delete(prodId, ordId).subscribe({
      next: (res) => {
        order.items = order.items.filter(x => x.productId != prodId);
      }
    })

  }

  createOrderItem(orderId: string) {
    if (this.activeOrder.items.find(x => x.productId == this.orderItem.productId)) {
      this.toastr.error("Product is already in order (You can change quantity by deleting and adding again)");
    } else {
      if (this.orderItem.orderId != null && this.orderItem.productId != null && this.orderItem.quantity != 0) {

        this.adminOrderItemService.add(this.orderItem).subscribe({
          next: (res) => {
            this.newProduct = {} as Product;
            this.order = this.orders.find(o => o.id == this.orderItem.orderId) || {} as Order;
            this.order.items.push(res);
          }
        })
      }
    }
  }

  openContextBottom(content: TemplateRef<any>, order: Order) {
    this.activeOrder = order;
    this.orderItem = {} as OrderItem;
    this.orderItem.orderId = order.id;
    this.offcanvasService.open(content, { position: 'bottom' });
  }
  changeOrderStatus(order: Order, nwStatusId: string) {
    order.statusId = nwStatusId;
    this.adminOrderService.update(order).subscribe({
      next: (res) => {
        order.status = res.status;
      }
    })
  }
}
