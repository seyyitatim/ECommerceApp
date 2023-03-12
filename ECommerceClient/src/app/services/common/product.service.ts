import { HttpErrorResponse } from '@angular/common/http';
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

  create(product: CreateProduct, succesCallBack?: any, errorCallBack?: any) {
    this.httpClientService.post({ controller: 'products' }, product).subscribe(
      (data) => {
        console.log('başarılı eklendi');
        succesCallBack();
        alert('dasda');
      },
      (errorResponse: HttpErrorResponse) => {
        const _error: Array<{ key: string; value: Array<string> }> =
          errorResponse.error;
        let message = '';
        _error.forEach((v, index) => {
          v.value.forEach((_v, index) => {
            message += `${_v}<br>`;
          });
        });

        errorCallBack(message);
      }
    );
  }
}
