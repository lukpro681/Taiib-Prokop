// product.service.ts

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductDTO } from '../models/productDTO';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private apiUrl = 'https://localhost:7206/api/products';

  constructor(private http: HttpClient) { }

  getProducts(): Observable<ProductDTO[]> {
    return this.http.get<ProductDTO[]>(`${this.apiUrl}`);
  }
}
