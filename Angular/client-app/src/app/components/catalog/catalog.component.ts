import { Component, OnInit } from '@angular/core';
import { AdminProductService } from '../../services/admin-product.service';
import { Product } from '../../models/product';
import { CommonModule } from '@angular/common';
import { CardService } from '../../services/card.service';
import { CartObject } from '../../models/cartObject';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-catalog',
  imports: [CommonModule, FormsModule],
  templateUrl: './catalog.component.html',
  styleUrl: './catalog.component.css'
})
export class CatalogComponent implements OnInit{
  page: number = 1;
  totalCount: number = 0;
  itemPerPage: number = 12;
  products: Product[] = [];
  constructor(
    private adminProductService: AdminProductService,
    private cardService: CardService
  ) {  }

  ngOnInit(): void{
    this.load("");
  }

  load(sort: ""|"id" | "name" | "price"){
    this.adminProductService.getAll(this.page, this.itemPerPage, sort).subscribe({
      next: (response) => {
        this.products = response.list;
        this.totalCount = response.totalCount;;
      },
    });
  }

  add(product : Product){
    console.log("add");
    const cartObj = {
      quantity: product.quantity,
      product: product
    } as CartObject;
    this.cardService.addCart(cartObj);
  }

}
