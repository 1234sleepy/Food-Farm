import {
  Component,
  inject,
  TemplateRef,
  ViewEncapsulation,
} from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import {
  NgbCollapseModule,
  NgbDropdownModule,
  NgbNavModule,
  NgbOffcanvas,
  NgbPaginationModule,
} from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AdminOrderStoreService } from '../../stores/admin-order.store.service';
import { GetAllOrderQuery } from '../../../models/get-all-order-query';
import { Order } from '../../../../cart/models/order';
import { Product } from '../../../../product/models/product';
import { OrderItem } from '../../../../cart/models/orderItem';
import { AdminOrderItemStoreService } from '../../stores/admin-orderitem.store.service';

@Component({
  selector: 'app-order-tab',
  imports: [
    NgbNavModule,
    FormsModule,
    CommonModule,
    NgbCollapseModule,
    NgbDropdownModule,
    NgbPaginationModule,
  ],
  templateUrl: './order-tab.component.html',
  styleUrl: './order-tab.component.css',
  encapsulation: ViewEncapsulation.None,
})
export class OrderTabComponent {
  constructor(
    public readonly adminOrderService: AdminOrderStoreService,
    public readonly adminOrderItemService: AdminOrderItemStoreService,
    private toastr: ToastrService,
  ) {}
  offcanvasService = inject(NgbOffcanvas);

  active = 'product';
  order = {} as Order;
  orderItem = {} as OrderItem;
  activeOrder = {} as Order;
  newProduct = {} as Product;

  deleteOrder(id: string) {
    this.adminOrderService.delete(id);
  }

  updateOrder(order: Order) {
    this.adminOrderService.update(order);
  }

  editOrder(order: Order) {
    if (order.status.name.toLowerCase() != 'completed') {
      if (order.disabled == true) {
        order.disabled = false;
      } else if (order.disabled == false) {
        this.updateOrder(order);
      }
    } else {
      this.toastr.error('You cannot edit completed orders');
    }
  }

  deleteItemOrder(prodId: string, ordId: string, order: Order) {
    this.adminOrderItemService.delete(prodId, ordId).subscribe({
      next: (res) => {
        order.items = order.items.filter((x) => x.productId != prodId);
      },
    });
  }

  createOrderItem(orderId: string) {
    if (
      this.activeOrder.items.find(
        (x) => x.productId == this.orderItem.productId,
      )
    ) {
      this.toastr.error(
        'Product is already in order (You can change quantity by deleting and adding again)',
      );
    } else {
      if (
        this.orderItem.orderId != null &&
        this.orderItem.productId != null &&
        this.orderItem.quantity != 0
      ) {
        this.adminOrderItemService.add(this.orderItem).subscribe({
          next: (res) => {
            this.newProduct = {} as Product;
            this.order = this.adminOrderService.getOrderById(orderId);
            this.order.items.push(res);
          },
        });
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
      },
    });
  }
}
