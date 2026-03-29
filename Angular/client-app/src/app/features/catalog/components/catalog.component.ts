import { Component, OnInit, ViewChild } from '@angular/core';

import { CommonModule } from '@angular/common';
import { CartObject } from '../../cart/models/cartObject';
import { FormsModule } from '@angular/forms';
import { Imagee } from '../../product/models/image';
import { GetAllProductQuery } from '../../product/models/get-all-product-query';

import { PaginationList } from '../../../models/paginationlist';
import {
  NgbCarousel,
  NgbCarouselConfig,
  NgbCarouselModule,
  NgbPaginationModule,
  NgbRatingModule,
  NgbSlideEvent,
  NgbSlideEventSource,
} from '@ng-bootstrap/ng-bootstrap';
import { inject, signal, TemplateRef, WritableSignal } from '@angular/core';
import {
  NgbOffcanvas,
  OffcanvasDismissReasons,
} from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';
import { ProductStoreService } from '../../product/services/storages/product.store.service';
import { CardStoreService } from '../../cart/services/storage/card.store.service';
import { Product } from '../../product/models/product';
import { ProductListStoreService } from '../services/store/product-list.store.service';

@Component({
  selector: 'app-catalog',
  imports: [
    CommonModule,
    FormsModule,
    NgbCarouselModule,
    NgbPaginationModule,
    NgbRatingModule,
  ],
  templateUrl: './catalog.component.html',
  styleUrl: './catalog.component.css',
})
export class CatalogComponent {
  paused = false;
  unpauseOnArrow = false;
  pauseOnIndicator = false;
  pauseOnHover = true;
  pauseOnFocus = true;

  constructor(
    public readonly productsStore: ProductListStoreService,
    private cardService: CardStoreService,
    private router: Router,
  ) {}

  changeUrl(id: string) {
    this.router.navigate([`/product/${id}`], {
      queryParams: { tab: 'description' },
    });
  }

  add(product: Product) {
    this.cardService.addCart({
      quantity: product._quantity,
      product: product,
    } as CartObject);
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
      (slideEvent.source === NgbSlideEventSource.ARROW_LEFT ||
        slideEvent.source === NgbSlideEventSource.ARROW_RIGHT)
    ) {
      this.togglePaused();
    }
    if (
      this.pauseOnIndicator &&
      !slideEvent.paused &&
      slideEvent.source === NgbSlideEventSource.INDICATOR
    ) {
      this.togglePaused();
    }
  }
}
