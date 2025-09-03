import { CommonModule } from '@angular/common';
import { Component, ViewEncapsulation } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
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
import { Comment } from '../../../models/comment';
import { NgbRatingModule } from '@ng-bootstrap/ng-bootstrap';
import { CommentService } from '../../../services/comment.service';
import { ActivatedRoute } from '@angular/router';
import { NgxIntlTelInputModule } from 'ngx-intl-tel-input';
import { SearchCountryField, CountryISO, PhoneNumberFormat } from 'ngx-intl-tel-input';
import { GetCommentsByIdQuery } from '../../../models/Queries/get-comments-by-id-query';
@Component({
  selector: 'app-comments-tab',
  imports: [CKEditorModule, FormsModule, CommonModule, NgbRatingModule, NgxIntlTelInputModule, ReactiveFormsModule ],
  templateUrl: './comments-tab.component.html',
  styleUrl: './comments-tab.component.css',
  standalone: true,
  encapsulation: ViewEncapsulation.None,
})
export class CommentsTabComponent {
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
  comment = {text : "", rating: 0} as Comment;

  productComments: Comment[] = [];
  query: GetCommentsByIdQuery = new GetCommentsByIdQuery();
  isLastPage: boolean = false;
  totalLoaded: number = 0;

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


  constructor(private commentService: CommentService,private route: ActivatedRoute) {
    this.comment.productId = this.route.snapshot.params['id'];
    this.query.productId = this.comment.productId;
    this.query.page = 1;
    this.query.itemPerPage = 3;

    this.getComments("");
  }

  addComment() {
    this.comment.phone = this.phoneForm.value.phone?.e164Number
    this.commentService.add(this.comment).subscribe({
      next: (response) => {
        console.log('Comment added successfully:', response);
        this.comment = {rating: 0} as Comment;
        this.phoneForm.reset();
        this.comment.text = '';
      }
    })
  }

  getComments(sort: "" | "DATE_DESC" | "DATE_ASC" | "RATING_DESC" | "RATING_ASC") {
    this.query.sort = sort;

    this.commentService.getByProductId(this.query).subscribe({
      next: (response) => {
        this.productComments = [...this.productComments, ...response.list];

        this.totalLoaded += this.query.itemPerPage;
        this.query.page++;
        if(this.totalLoaded >= response.totalCount) {
          this.isLastPage = true;
        }
      }
    });
  }
}
