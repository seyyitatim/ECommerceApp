import { Component, EventEmitter, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent } from 'src/app/base/base.component';
import { ListProduct } from 'src/app/contracts/list_product';
import { ProductService } from 'src/app/services/common/product.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
})
export class ListComponent extends BaseComponent implements OnInit {
  products: ListProduct[];
  pageCount: number;
  currencyPage: number = 0;
  constructor(
    spinner: NgxSpinnerService,
    private productService: ProductService
  ) {
    super(spinner);
  }

  async ngOnInit() {
    await this.getProducts();
  }

  async getProducts(page: number = 0) {
    const data = await this.productService.list(
      page,
      5,
      () => {},
      () => {}
    );
    this.currencyPage = page;
    this.products = data.products;
    this.pageCount = data.pageCount;
  }
  async after() {
    if (this.currencyPage + 1 >= this.pageCount) return;
    this.currencyPage += 1;
    await this.getProducts(this.currencyPage);
  }
  async before() {
    if (this.currencyPage - 1 < 0) return;
    this.currencyPage -= 1;
    await this.getProducts(this.currencyPage);
  }
  async delete(id: string) {
    await this.productService.delete(id);
    this.getProducts(this.currencyPage);
  }
}
