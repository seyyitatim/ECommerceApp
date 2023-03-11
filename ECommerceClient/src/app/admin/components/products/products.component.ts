import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/contracts/product';
import { HttpClientService } from 'src/app/services/common/http-client.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})
export class ProductsComponent implements OnInit {
  constructor(private httpClientService: HttpClientService) {}

  ngOnInit(): void {
    this.httpClientService
      .get<Product[]>({
        controller: 'products',
      })
      .subscribe((data) => console.log(data));
  }
}
