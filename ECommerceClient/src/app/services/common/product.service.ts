import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateProduct } from 'src/app/contracts/create_product';
import { ListProduct } from 'src/app/contracts/list_product';
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

  create(
    product: CreateProduct,
    succesCallBack?: () => void,
    errorCallBack?: (errorMessage: string) => void
  ) {
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

  async list(
    page: number = 0,
    size: number = 5,
    succesCallBack?: () => void,
    errorCallBack?: (errorMessage: string) => void
  ): Promise<{ pageCount: number; products: ListProduct[] }> {
    const promisedData: Promise<{
      pageCount: number;
      products: ListProduct[];
    }> = this.httpClientService
      .get<{ pageCount: number; products: ListProduct[] }>({
        controller: 'products',
        queryString: `page=${page}&size=${size}`,
      })
      .toPromise();

    promisedData
      .then((d) => succesCallBack())
      .catch((errorResponse: HttpErrorResponse) =>
        errorCallBack(errorResponse.message)
      );

    return await promisedData;
  }
}
