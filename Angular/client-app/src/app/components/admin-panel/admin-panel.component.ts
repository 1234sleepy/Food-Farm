import { Component, inject, TemplateRef } from '@angular/core';
import { NgbDropdownModule, NgbNavModule, NgbOffcanvas } from '@ng-bootstrap/ng-bootstrap';
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
import { ActivatedRoute, Route, Router } from '@angular/router';
import { ProductTabComponent } from "./product-tab/product-tab.component";
import { OrderTabComponent } from "./order-tab/order-tab.component";

@Component({
  selector: 'app-admin-panel',
  imports: [NgbNavModule, FormsModule, CommonModule, ProductTabComponent, OrderTabComponent],
  templateUrl: './admin-panel.component.html',
  styleUrl: './admin-panel.component.css'
})
export class AdminPanelComponent {
  constructor(
    private accountService: AccountService,
    private router: Router,
    private readonly activatedRoute: ActivatedRoute,
  ) {}
  active : string = "";
  
  ngOnInit(): void {
    this.active = this.activatedRoute.snapshot.params['tab'];
  }

  changeUrl() {
    this.router.navigate([`/admin/${this.active}`]);
  }

  logout() {
    this.accountService.logout().subscribe({
      next: (res) => {
        this.router.navigateByUrl('');
      }
    })
  }

  homePage() {
    this.router.navigateByUrl('');
  }

}