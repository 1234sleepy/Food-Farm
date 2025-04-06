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
import { inject, signal, TemplateRef, WritableSignal } from '@angular/core';
import {NgbOffcanvas, OffcanvasDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { ProductService } from '../../services/product.service';

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
    private productService: ProductService,
    private cardService: CardService
  ) {
   }
   
  private offcanvasService = inject(NgbOffcanvas);
	closeResult: WritableSignal<string> = signal('');

	open(content: TemplateRef<any>) {
		this.offcanvasService.open(content, { ariaLabelledBy: 'offcanvas-basic-title' }).result.then(
			(result) => {
				this.closeResult.set(`Closed with: ${result}`);
			},
			(reason) => {
				this.closeResult.set(`Dismissed ${this.getDismissReason(reason)}`);
			},
		);
	}

	private getDismissReason(reason: any): string {
		switch (reason) {
			case OffcanvasDismissReasons.ESC:
				return 'by pressing ESC';
			case OffcanvasDismissReasons.BACKDROP_CLICK:
				return 'by clicking on the backdrop';
			default:
				return `with: ${reason}`;
		}
	}

  ngOnInit(): void {
    this.setSort("");
    this.load();
  }

  setSort(sort: "" | "id" | "name" | "price"){
    this.query.sort = sort;
  }

  load() {
    this.productService.getAll(this.query).subscribe(
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
