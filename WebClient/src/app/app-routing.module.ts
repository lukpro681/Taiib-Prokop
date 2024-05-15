
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrdersComponent } from './orders/orders.component';
import { BasketComponent } from './basket/basket.component';
import { ProductsComponent } from './products/products.component';
import { AllOrdersComponent } from './all-orders/all-orders.component'; // Import AllOrdersComponent

const routes: Routes = [
  { path: 'orders', component: OrdersComponent },
  { path: 'orders/all', component: AllOrdersComponent }, // This is your all orders route
  { path: 'basket', component: BasketComponent },
  { path: 'products', component: ProductsComponent },
  { path: '', redirectTo: '/products', pathMatch: 'full' }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
