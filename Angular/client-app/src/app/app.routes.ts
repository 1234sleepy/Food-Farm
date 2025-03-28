import { Routes } from '@angular/router';
import { MainComponent } from './components/main/main.component';
import { CatalogComponent } from './components/catalog/catalog.component';
import { CartComponent } from './components/cart/cart.component';
import { AdminPanelComponent } from './components/admin-panel/admin-panel.component';

export const routes: Routes = [
    {path: '', pathMatch: 'full', redirectTo: 'main'},
    {path: 'main', component: MainComponent},
    {path: 'catalog', component: CatalogComponent},
    {path: 'cart', component: CartComponent},
    {path: 'admin', component: AdminPanelComponent}
];
