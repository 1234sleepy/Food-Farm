import { Routes } from '@angular/router';
import { MainComponent } from './features/main/components/main.component';
import { CatalogComponent } from './features/catalog/components/catalog.component';
import { CartComponent } from './features/cart/components/cart.component';
import { AdminPanelComponent } from './features/admin-panel/components/admin-panel.component';
import { authGuard } from './guards/auth.guard';
import { ProductComponent } from './features/product/components/product.component';
import { CharacteristicsTabComponent } from './features/admin-panel/components/characteristics-tab/characteristics-tab.component';
import { LabelsTabComponent } from './features/admin-panel/components/labels-tab/labels-tab.component';
import { LoginComponent } from './features/auth/components/login/login.component';
import { ImageTabComponent } from './features/admin-panel/components/image-tab/image-tab.component';


export const routes: Routes = [
    {path: '', pathMatch: 'full', redirectTo: 'main'},
    {path: 'main', component: MainComponent},
    {path: 'catalog', component: CatalogComponent},
    {path: 'cart', component: CartComponent},
    {path: 'admin', redirectTo: 'admin/product'},
    {path: 'admin/:tab', component: AdminPanelComponent, canActivate: [authGuard]},
    {path: 'login', component: LoginComponent},
    {path: 'product/:id', component: ProductComponent} ,
    {path: 'admin/product/characteristics/:id', component: CharacteristicsTabComponent, canActivate: [authGuard]},
    {path: 'admin/product/labels/:id', component: LabelsTabComponent, canActivate: [authGuard]},
    {path: 'admin/image/:id', component: ImageTabComponent, canActivate: [authGuard]},
];
