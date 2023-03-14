import { Component, OnInit, ViewChild } from '@angular/core';
import { CreateProduct } from 'src/app/contracts/create_product';
import { HttpClientService } from 'src/app/services/common/http-client.service';
import { ProductService } from 'src/app/services/common/product.service';
import { ListComponent } from './list/list.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})
export class ProductsComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}

  @ViewChild(ListComponent) listComponent: ListComponent;

  createdProduct(createdProduct: CreateProduct) {
    this.listComponent.getProducts();
  }
}
