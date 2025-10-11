import { CommonModule } from '@angular/common';
import { Component, inject, ViewEncapsulation } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbCollapseModule, NgbNavModule, NgbOffcanvas, NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { Product } from '../../../models/product';
import { GetAllProductQuery } from '../../../models/Queries/get-all-product-query';
import { AdminProductService } from '../../../services/admin-product.service';
import { ProductService } from '../../../services/product.service';
import { ActivatedRoute, Router } from '@angular/router';

import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
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
import { LabelsService } from '../../../services/labels.service';
import { Label } from '../../../models/label';


@Component({
  selector: 'app-product-tab',
  imports: [CKEditorModule, NgbNavModule, FormsModule, CommonModule, NgbCollapseModule, NgbPaginationModule],
  templateUrl: './product-tab.component.html',
  styleUrl: './product-tab.component.css',
  encapsulation: ViewEncapsulation.None,
})
export class ProductTabComponent {
  constructor(private adminProductService: AdminProductService,
    private productService: ProductService,		private router: Router,
    private labelsService: LabelsService

  ) {
    this.query.itemPerPage = 10;
    this.query.page = 1;
    this.query.sort = "id";
    this.getAllProducts();

    this.labelsService.getAll().subscribe({
      next: (res) => {
        this.labels = res;
      }
    })

    this.newProduct.labels = [];
  }

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

  query = new GetAllProductQuery();
  products: Product[] = [];
  totalCount = 0;

  offcanvasService = inject(NgbOffcanvas);

  active = 'product';
  createProductControlisCollapsed = true;
  newProduct = {} as Product;

  createProductResult = '';


  labels: Label[] = [];

	changeToCharacteristicsUrl(id: string) {
    	this.router.navigate([`admin/product/characteristics/${id}`]);
  }

  changeToLabelsUrl(id: string) {
    	this.router.navigate([`admin/product/labels/${id}`]);
  }



  createProduct() {
    this.adminProductService.add(this.newProduct).subscribe({
      next: (res) => {
        this.newProduct = {} as Product;
        this.products.push(res);
        this.newProduct.labels = [];
      }
    })
  }

  labelsSelection(label : Label){
    
    if(this.newProduct.labels?.indexOf(label))
    {
      this.newProduct.labels?.push(label);
    }
    else
    {
      this.newProduct.labels?.splice(this.newProduct.labels?.indexOf(label)-1,1)
    }
  }

  updateProduct(product: Product) {
    this.adminProductService.update(product).subscribe({
      next: (res) => {
        this.products = this.products.map(p => p.id == res.id ? res : p);
      }
    })
  }



  deleteProduct(id: string) {
    this.adminProductService.delete(id).subscribe({
      next: (res) => {
        this.products = this.products.filter(p => p.id !== id);
      }
    })
  }

  getAllProducts() {
    this.productService.getAll(this.query).subscribe({
      next: (res) => {
        this.products = res.list;
        this.totalCount = res.totalCount;
      }
    })
  }

  editProduct(product: Product) {
    if (product.disabled == true) {
      product.disabled = false;

    }
    else if (product.disabled == false) {
      product.disabled = true;
      this.updateProduct(product);
    }
  }
}
