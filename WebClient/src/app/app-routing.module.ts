import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// Import komponentów, które będą używane w nawigacji
import { ProductsComponent } from './products/products.component';
import { OrdersComponent } from './orders/orders.component';
import { AllOrdersComponent } from './all-orders/all-orders.component';
import { BasketComponent } from './basket/basket.component';

// Zdefiniuj ścieżki dla każdej podstrony
const routes: Routes = [
  { path: 'products', component: ProductsComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'orders/all', component: AllOrdersComponent },
  { path: 'basket', component: BasketComponent },
  // Dodaj dodatkowe ścieżki, jeśli to konieczne
  { path: '', redirectTo: '/products', pathMatch: 'full' }, // Domyślna ścieżka
  { path: '**', redirectTo: '/products', pathMatch: 'full' } // Obsługa nieznanych ścieżek
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
