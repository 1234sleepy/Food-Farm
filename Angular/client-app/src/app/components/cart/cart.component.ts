import { Component, OnInit } from '@angular/core';
import { CardService } from '../../services/card.service';
import { Product } from '../../models/product';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CartObject } from '../../models/cartObject';
import { Order } from '../../models/order';
import { OrderCreateModel } from '../../models/orderCreateModel';
import { OrderService } from '../../services/order.service';
import { NgbCarousel, NgbCarouselModule, NgbSlideEvent, NgbSlideEventSource } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-cart',
  imports: [CommonModule, FormsModule, NgbCarouselModule],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent implements OnInit{
  cartObjects: CartObject[] = [];
  order = {} as OrderCreateModel;

  constructor(private cardService: CardService, private orderService: OrderService) {}
  ngOnInit(): void {
    this.cardService.cart$.subscribe(obj => {
      this.cartObjects = obj;
    });
  }

  delete(obj: CartObject){ 
    this.cardService.deleteCart(obj);
  }

  createOrder(){
    this.order.items = this.cartObjects.map(obj => {
      return{
        ProductId: obj.product.id,
        Quantity: obj.quantity
      }
    });
    this.orderService.add(this.order).subscribe({
      next: (res) => {
        console.log(res);
        this.cardService.clearCart();
      }
    })
  }

}
