import { Component, OnInit, ViewChild } from '@angular/core';
import { AdminProductService } from '../../services/admin-product.service';
import { Product } from '../../models/product';
import { CommonModule } from '@angular/common';
import { CardService } from '../../services/card.service';
import { CartObject } from '../../models/cartObject';
import { FormsModule } from '@angular/forms';
import { Image } from '../../models/image';
import { GetAllProductQuery } from '../../models/Queries/get-all-product-query';
import { PaginationList } from '../../models/paginaion-list.model';
import { NgbCarousel, NgbCarouselConfig, NgbCarouselModule, NgbSlideEvent, NgbSlideEventSource } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-catalog',
  imports: [CommonModule, FormsModule, NgbCarouselModule],
  templateUrl: './catalog.component.html',
  styleUrl: './catalog.component.css'
})
export class CatalogComponent implements OnInit {
  query = new GetAllProductQuery();
  pagination = { totalCount: 0, list: [] } as PaginationList<Product>;

  paused = false;
	unpauseOnArrow = false;
	pauseOnIndicator = false;
	pauseOnHover = true;
	pauseOnFocus = true;

  constructor(
    private adminProductService: AdminProductService,
    private cardService: CardService
  ) {
   }

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

}
