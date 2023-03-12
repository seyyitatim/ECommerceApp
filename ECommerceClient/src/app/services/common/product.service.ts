import { Injectable } from '@angular/core';
import { CreateProduct } from 'src/app/contracts/create_product';
import {
  AlertifyService,
  MessageType,
  Position,
} from '../admin/alertify.service';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor(
    private httpClientService: HttpClientService,
    private alertifyService: AlertifyService
  ) {}

  create(product: CreateProduct, succesCallBack?: any) {
    this.httpClientService
      .post({ controller: 'products' }, product)
      .subscribe((data) => {
        succesCallBack();
        alert('dasda');
      });
  }
}
