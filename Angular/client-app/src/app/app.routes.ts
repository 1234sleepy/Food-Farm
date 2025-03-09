import { Routes } from '@angular/router';
import { MainComponent } from './components/main/main.component';
import { CatalogComponent } from './components/catalog/catalog.component';

export const routes: Routes = [
    {path: '', pathMatch: 'full', redirectTo: 'main'},
    {path: 'main', component: MainComponent},
    {path: 'catalog', component: CatalogComponent}
];
