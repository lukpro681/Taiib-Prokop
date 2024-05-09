import { Component, OnInit } from '@angular/core';
import { ProductService } from '../products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent{
  public id: number = 0;
  public name: string = "";
  public price: number = 0.00;
  public image: string = "";
  public isActive: boolean = false;

  constructor(private productService: ProductService) {
    this.loadData();
  }

  private loadData() : void {
    {
      this.productService.getProducts().subscribe({
        next: (res) => {
          res;
        },
        error: (err) => console.error(err),
        complete: () => console.log('complete')
      });
    }
  }
}