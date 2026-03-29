import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CartObject } from '../models/cartObject';
import { Order } from '../models/order';
import { OrderCreateModel } from '../models/orderCreateModel';
import { NgbCarousel, NgbCarouselModule, NgbSlideEvent, NgbSlideEventSource } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { CountryISO, NgxIntlTelInputModule, PhoneNumberFormat, SearchCountryField } from 'ngx-intl-tel-input';
import {
  ClassicEditor,
  Bold,
  Essentials,
  Italic,
  Mention,
  Paragraph,
  Undo,
  List,
  Heading,
  FontFamily,
  FontColor,
  FontBackgroundColor,
  Strikethrough,
  Subscript,
  Superscript,
  Code,
  Link,
  Image,
  BlockQuote,
  CodeBlock,
  TodoList,
  Indent,
  OutdentCodeBlockCommand,
  ImageBlock,
  ImageUpload,
  ImageInsert,
  ImageUploadUI,
  InsertOperation,
  Base64UploadAdapter,
  ImageEditing,
  Context,
  ContextPlugin,
  ResizeObserver,
  ImageResizeEditing,
  ImageResize,
  ImageToolbar,
  ImageInline,
} from 'ckeditor5';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { CardStoreService } from '../services/storage/card.store.service';
import { OrderStoreService } from '../services/storage/order.store.service';
@Component({
  selector: 'app-cart',
  imports: [CKEditorModule,CommonModule, FormsModule,NgbCarouselModule, NgxIntlTelInputModule, ReactiveFormsModule],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css',
  standalone: true,
  encapsulation: ViewEncapsulation.None,
})
export class CartComponent implements OnInit{
  public Editor = ClassicEditor;
  public config = {
    toolbar: [
      'undo',
      'redo',
      '|',
      'heading',
      '|',
      'fontfamily',
      'fontsize',
      'fontColor',
      'fontBackgroundColor',
      '|',
      'bold',
      'italic',
      'strikethrough',
      'subscript',
      'superscript',
      'code',
      '|',
      'link',
      'uploadImage',
      'blockQuote',
      'codeBlock',
      '|',
      'bulletedList',
      'numberedList',
      'todoList',
      'outdent',
      'indent',
    ],
    plugins: [
      Bold,
      Essentials,
      Italic,
      Mention,
      Paragraph,
      Undo,
      List,
      Heading,
      FontFamily,
      FontColor,
      FontBackgroundColor,
      Strikethrough,
      Subscript,
      Superscript,
      Code,
      Link,
      Image,
      BlockQuote,
      CodeBlock,
      TodoList,
      Indent,
      ImageBlock,
      ImageUpload,
      ImageInsert,
      ImageUploadUI,
      Base64UploadAdapter,
      ImageEditing,
      //ContextPlugin,
      //ImageResizeEditing,
      ImageResize,
      ImageInline
    ],

    resourceType: 'Images',

    //licenseKey: '<YOUR_LICENSE_KEY>',
    // mention: {
    //     Mention configuration
    // }
  };

  cartObjects: CartObject[] = [];
  order = {description : ""} as OrderCreateModel;
  tmp = {} as CartObject;

  totalPrice: number = 0;
  paused = false;
	unpauseOnArrow = false;
	pauseOnIndicator = false;
	pauseOnHover = true;
	pauseOnFocus = true;

  separateDialCode = false;
	SearchCountryField = SearchCountryField;
	CountryISO = CountryISO;
  PhoneNumberFormat = PhoneNumberFormat;
	preferredCountries: CountryISO[] = [CountryISO.UnitedStates, CountryISO.UnitedKingdom];
	phoneForm = new FormGroup({
		phone: new FormControl(undefined as any, [Validators.required])
	});

  	changePreferredCountries() {
		this.preferredCountries = [CountryISO.India, CountryISO.Canada];
	}


  constructor(private cardService: CardStoreService, private orderService: OrderStoreService, private toastr: ToastrService) {}
  ngOnInit(): void {
    this.cardService.cart$.subscribe(obj => {
      this.cartObjects = obj;
    });


    this.changeTotalPrice();
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
