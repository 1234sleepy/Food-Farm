import { Routes } from '@angular/router';
import { MainComponent } from './components/main/main.component';
import { CatalogComponent } from './components/catalog/catalog.component';
import { CartComponent } from './components/cart/cart.component';
import { AdminPanelComponent } from './components/admin-panel/admin-panel.component';
import { LoginComponent } from './login/login.component';
import { authGuard } from './guards/auth.guard';
import { ImageTabComponent } from './components/admin-panel/image-tab/image-tab.component';
import { OrderTabComponent } from './components/admin-panel/order-tab/order-tab.component';
import { ProductService } from './services/product.service';
import { ProductTabComponent } from './components/admin-panel/product-tab/product-tab.component';
import { ProductComponent } from './components/product/product.component';

export const routes: Routes = [
    {path: '', pathMatch: 'full', redirectTo: 'main'},
    {path: 'main', component: MainComponent},
    {path: 'catalog', component: CatalogComponent},
    {path: 'cart', component: CartComponent},
    {path: 'admin', redirectTo: 'admin/product'},
    {path: 'admin/:tab', component: AdminPanelComponent, canActivate: [authGuard]},
    {path: 'login', component: LoginComponent}, 
    {path: 'product/:id', component: ProductComponent}  
];
