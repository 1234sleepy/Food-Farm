import { Component, OnInit, ViewEncapsulation, ChangeDetectionStrategy } from '@angular/core';

import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CartObject } from '../models/cartObject';
import { Order } from '../models/order';
import { OrderCreateModel } from '../models/orderCreateModel';
import { NgbCarousel, NgbCarouselModule, NgbSlideEvent, NgbSlideEventSource } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import "intl-tel-input/styles";
import { CardStoreService } from '../services/storage/card.store.service';
import { OrderStoreService } from '../services/storage/order.store.service';
import { RichTextAreaComponent } from '../../../core/shared/forms/rich-text-area/rich-text-area.component';
import IntlTelInput from '@intl-tel-input/angular';
@Component({
  selector: 'app-cart',
  imports: [ IntlTelInput, FormsModule, NgbCarouselModule, ReactiveFormsModule, RichTextAreaComponent],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css',
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: true,
})
export class CartComponent implements OnInit{
  cartObjects: CartObject[] = [];
  order = {description : ""} as OrderCreateModel;
  tmp = {} as CartObject;
  loadUtils = () => import("intl-tel-input/utils");
  totalPrice: number = 0;
  paused = false;
	unpauseOnArrow = false;
	pauseOnIndicator = false;
	pauseOnHover = true;
	pauseOnFocus = true;

	phoneForm = new FormGroup({
		phone: new FormControl(undefined as any, [Validators.required])
	});


  constructor(private cardService: CardStoreService, private orderService: OrderStoreService, private toastr: ToastrService) {}
  ngOnInit(): void {
    this.cardService.cart$.subscribe(obj => {
      this.cartObjects = obj;
    });


    this.changeTotalPrice();
  }

  numberChanged(phone: string){
    this.phoneForm.value.phone = phone;
  }


  delete(obj: CartObject){
    this.cardService.deleteCart(obj);
    this.changeTotalPrice();
  }

  createOrder(){
    this.order.items = this.cartObjects.map(obj => {
      return{
        ProductId: obj.product.id,
        Quantity: obj.quantity
      }
    });
    this.order.phone = this.phoneForm.value.phone?.e164Number;
    this.orderService.add(this.order).subscribe({
      next: (res) => {
        this.cardService.clearCart();
        this.toastr.success('Order created successfully');
      },error: (err) => {
        this.toastr.error('Error creating order');
      }
    })
    this.order = {} as OrderCreateModel;
    this.totalPrice= 0;
  }

  changeQuantity(q: CartObject)
  {

    this.cardService.changeQuantity(q);

    this.changeTotalPrice();
  }

  changeTotalPrice() {
    this.totalPrice= 0;
    this.cartObjects.forEach(obj => {
      this.totalPrice += obj.product.price * obj.quantity;
    });
  }

	// togglePaused() {
	// 	if (this.paused) {
	// 		this.carousel.cycle();
	// 	} else {
	// 		this.carousel.pause();
	// 	}
	// 	this.paused = !this.paused;
	// }

	// onSlide(slideEvent: NgbSlideEvent) {
	// 	if (
	// 		this.unpauseOnArrow &&
	// 		slideEvent.paused &&
	// 		(slideEvent.source === NgbSlideEventSource.ARROW_LEFT || slideEvent.source === NgbSlideEventSource.ARROW_RIGHT)
	// 	) {
	// 		this.togglePaused();
	// 	}
	// 	if (this.pauseOnIndicator && !slideEvent.paused && slideEvent.source === NgbSlideEventSource.INDICATOR) {
	// 		this.togglePaused();
	// 	}
	// }

}
