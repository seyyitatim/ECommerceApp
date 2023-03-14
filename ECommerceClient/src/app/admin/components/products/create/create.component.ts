import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CreateProduct } from 'src/app/contracts/create_product';
import {
  AlertifyService,
  MessageType,
  Position,
} from 'src/app/services/admin/alertify.service';
import { ProductService } from 'src/app/services/common/product.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
})
export class CreateComponent implements OnInit {
  constructor(
    private productService: ProductService,
    private alertify: AlertifyService
  ) {}
  ngOnInit(): void {}

  @Output() createdProduct: EventEmitter<CreateProduct> = new EventEmitter();

  create(
    name: HTMLInputElement,
    stock: HTMLInputElement,
    price: HTMLInputElement
  ) {
    const product = new CreateProduct();
    product.name = name.value;
    product.stock = parseInt(stock.value);
    product.price = parseFloat(price.value);

    this.productService.create(
      product,
      () => {
        this.alertify.message('Ürün başarılı bir şekilde eklendi', {
          messageType: MessageType.Success,
        });
        this.createdProduct.emit(product);
      },
      (errorMessage) => {
        this.alertify.message(errorMessage, { messageType: MessageType.Error });
      }
    );
  }
}
