import { Component, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { CommonModule, Location } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgbCarousel, NgbCarouselModule, NgbNavModule, NgbRatingModule, NgbSlideEvent, NgbSlideEventSource } from '@ng-bootstrap/ng-bootstrap';
import { CartObject } from '../../cart/models/cartObject';
import { DescriptionTabComponent } from './description-tab/description-tab.component';
import { CommentsTabComponent } from './comments-tab/comments-tab.component';
import { CharacteristicsTabComponent } from './characteristics-tab/characteristics-tab.component';
import { ProductStoreService } from '../services/storages/product.store.service';
import { CardStoreService } from '../../cart/services/storage/card.store.service';
import { Product } from '../models/product';


@Component({
  selector: 'app-product',
  imports: [CommonModule, FormsModule, NgbCarouselModule, NgbNavModule, DescriptionTabComponent, CommentsTabComponent, CharacteristicsTabComponent, CommentsTabComponent, NgbRatingModule],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent {
  constructor(private activatedRoute: ActivatedRoute,private productService: ProductStoreService,private cardService: CardStoreService,private router : Router, private location: Location) {}

  product = {} as Product;

  active : string = "description";

  maxQuantity = Array(5).fill(this.product.quantityLimit).map((x,i)=>i);

  paused = false;
	unpauseOnArrow = false;
	pauseOnIndicator = false;
	pauseOnHover = true;
	pauseOnFocus = true;

ngOnInit() {
  const id = this.activatedRoute.snapshot.paramMap.get('id') ?? '';
  this.maxQuantity.shift();
  this.productService.getById(id).subscribe(res => {
    this.product = res;
  });
}


	@ViewChild('carousel', { static: true }) carousel!: NgbCarousel;

	togglePaused() {
		if (this.paused) {
			this.carousel.cycle();
		} else {
			this.carousel.pause();
		}
		this.paused = !this.paused;
	}

  onSlide(slideEvent: NgbSlideEvent) {
    if (
      this.unpauseOnArrow &&
      slideEvent.paused &&
      (slideEvent.source === NgbSlideEventSource.ARROW_LEFT || slideEvent.source === NgbSlideEventSource.ARROW_RIGHT)
    ) {
      this.togglePaused();
    }
    if (this.pauseOnIndicator && !slideEvent.paused && slideEvent.source === NgbSlideEventSource.INDICATOR) {
      this.togglePaused();
    }
  }

    add(product: Product) {
      const cartObj = {
        quantity: product._quantity,
        product: product
      } as CartObject;
      this.cardService.addCart(cartObj);
    }

  changeUrl() {
    this.location.go("product/" + this.product.id + "?tab=" + this.active);
  }

}
