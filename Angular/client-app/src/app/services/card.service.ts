import { Injectable, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { CartObject } from '../models/cartObject';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class CardService{
  private cart = new BehaviorSubject<CartObject[]>([]);
  cart$ = this.cart.asObservable();

  constructor(private toastr: ToastrService) { 
    const cart = localStorage.getItem("cart");
    if(cart){
      this.cart.next(JSON.parse(cart));
    }
  }

  addCart(product: CartObject){
    if(this.cart.getValue().find(x => x.product.id === product.product.id)){
      this.toastr.error("Product already in cart (You can change quantity in cart)");
    }else{
      this.cart.next([...this.cart.getValue(), product]);
    }

    localStorage.setItem("cart", JSON.stringify(this.cart.getValue()));
  }

  deleteCart(product: CartObject){
    const cart = this.cart.getValue().filter(x => x.product.id !== product.product.id);
    this.cart.next(cart);
    localStorage.setItem("cart", JSON.stringify(cart));
  }

  clearCart(){
    this.cart.next([]);
    localStorage.removeItem("cart");
  }

}
