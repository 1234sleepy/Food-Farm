import { CommonModule } from '@angular/common';
import { Component, inject, ViewEncapsulation } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {
  NgbCollapseModule,
  NgbNavModule,
  NgbOffcanvas,
  NgbPaginationModule,
} from '@ng-bootstrap/ng-bootstrap';
import { GetAllProductQuery } from '../../../../product/models/get-all-product-query';
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
import { Label } from '../../../../product/models/label';
import { NgSelectModule } from '@ng-select/ng-select';

import { ProductStoreService } from '../../../../product/services/storages/product.store.service';
import { LabelsStoreService } from '../../../../product/services/storages/labels.store.service';
import { Product } from '../../../../product/models/product';
import { AdminProductStoreService } from '../../stores/admin-product.store.service';

@Component({
  selector: 'app-product-tab',
  imports: [
    CKEditorModule,
    NgbNavModule,
    FormsModule,
    CommonModule,
    NgbCollapseModule,
    NgbPaginationModule,
    NgSelectModule,
  ],
  templateUrl: './product-tab.component.html',
  styleUrl: './product-tab.component.css',
  encapsulation: ViewEncapsulation.None,
})
export class ProductTabComponent {
  constructor(
    public readonly adminProductService: AdminProductStoreService,
    private productService: ProductStoreService,
    private router: Router,
    private labelsService: LabelsStoreService,
  ) {
    this.labelsService.getAll().subscribe({
      next: (res) => {
        this.labels = res;
      },
    });

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
      ImageInline,
    ],

    resourceType: 'Images',

    //licenseKey: '<YOUR_LICENSE_KEY>',
    // mention: {
    //     Mention configuration
    // }
  };
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
    this.adminProductService
      .add(this.newProduct)
      .subscribe(() => (this.newProduct = { labels: [] } as any as Product));
  }

  labelsSelection(label: Label) {
    if (this.newProduct.labels?.indexOf(label)) {
      this.newProduct.labels?.push(label);
    } else {
      this.newProduct.labels?.splice(
        this.newProduct.labels?.indexOf(label) - 1,
        1,
      );
    }
    console.log(this.newProduct.labels);
  }

  updateProduct(product: Product) {
    this.adminProductService.update(product);
    // this.adminProductService.update(product).subscribe({
    //   next: (res) => {
    //     this.products = this.products.map((p) => (p.id == res.id ? res : p));
    //   },
    // });
  }

  deleteProduct(id: string) {
    this.adminProductService.delete(id);
    // this.adminProductService.delete(id).subscribe({
    //   next: (res) => {
    //     this.products = this.products.filter((p) => p.id !== id);
    //   },
    // });
  }

  // getAllProducts() {
  //   this.productService.getAll(this.query).subscribe({
  //     next: (res) => {
  //       this.products = res.list;
  //       this.totalCount = res.totalCount;
  //     },
  //   });
  // }

  editProduct(product: Product) {
    if (product.disabled == true) {
      product.disabled = false;
    } else if (product.disabled == false) {
      product.disabled = true;
      this.updateProduct(product);
    }
  }
}
