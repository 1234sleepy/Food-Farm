import { Component, ViewEncapsulation } from '@angular/core';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { ProductTabComponent } from "../products/components/product-tab/product-tab.component";
import { OrderTabComponent } from "./order-tab/order-tab.component";
import { AuthStoreService } from '../../auth/services/stores/auth.store.service';

@Component({
  selector: 'app-admin-panel',
  imports: [NgbNavModule, FormsModule, CommonModule, ProductTabComponent, OrderTabComponent],
  templateUrl: './admin-panel.component.html',
  styleUrl: './admin-panel.component.css',
  encapsulation: ViewEncapsulation.None
})
export class AdminPanelComponent {
  constructor(
    private authService: AuthStoreService,
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
    this.authService.logout().subscribe({
      next: (res) => {
        this.router.navigateByUrl('');
      }
    })
  }

  homePage() {
    this.router.navigateByUrl('');
  }
}
