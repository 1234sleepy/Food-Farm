import { Component, OnInit } from '@angular/core';
import { AdminProductService } from '../../services/admin-product.service';
import { Product } from '../../models/product';
import { CommonModule } from '@angular/common';
import { CardService } from '../../services/card.service';
import { CartObject } from '../../models/cartObject';
import { FormsModule } from '@angular/forms';
import { Image } from '../../models/image';
import { GetAllProductQuery } from '../../models/Queries/get-all-product-query';
import { PaginationList } from '../../models/paginaion-list.model';

@Component({
  selector: 'app-catalog',
  imports: [CommonModule, FormsModule],
  templateUrl: './catalog.component.html',
  styleUrl: './catalog.component.css'
})
export class CatalogComponent implements OnInit {
  query = new GetAllProductQuery();
  pagination = { totalCount: 0, list: [] } as PaginationList<Product>;
  constructor(
    private adminProductService: AdminProductService,
    private cardService: CardService
  ) { }

  ngOnInit(): void {
    this.load("");
  }

  load(sort: "" | "id" | "name" | "price") {
    this.query.sort = sort;
    this.adminProductService.getAll(this.query).subscribe(
      (response) => this.pagination = response
    );
  }

  add(product: Product) {
    const cartObj = {
      quantity: product._quantity,
      product: product
    } as CartObject;
    this.cardService.addCart(cartObj);
  }

}
