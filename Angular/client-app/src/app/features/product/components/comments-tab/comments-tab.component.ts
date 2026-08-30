import { CommonModule } from '@angular/common';
import { Component, ViewEncapsulation, ChangeDetectionStrategy } from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

import { NgbRatingModule } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute } from '@angular/router';
import IntlTelInput from "@intl-tel-input/angular";
import "intl-tel-input/styles";

import { CommentStoreService } from '../../services/storages/comment.store.service';
import { GetCommentsByIdQuery } from '../../models/get-comments-by-id-query';
import { Comment } from '../../../product/models/comment';
import { RichTextAreaComponent } from '../../../../core/shared/forms/rich-text-area/rich-text-area.component';
@Component({
  selector: 'app-comments-tab',
  imports: [
    FormsModule,
    CommonModule,
    NgbRatingModule,
    IntlTelInput,
    ReactiveFormsModule,
    RichTextAreaComponent,
  ],
  templateUrl: './comments-tab.component.html',
  styleUrl: './comments-tab.component.css',
  changeDetection: ChangeDetectionStrategy.Eager,
  standalone: true,
})
export class CommentsTabComponent {
  comment = { text: '', rating: 0 } as Comment;

  productComments: Comment[] = [];
  query: GetCommentsByIdQuery = new GetCommentsByIdQuery();
  isLastPage: boolean = false;
  totalLoaded: number = 0;

  separateDialCode = false;
  loadUtils = () => import("intl-tel-input/utils");

  // SearchCountryField = SearchCountryField;
  // CountryISO = CountryISO;
  // PhoneNumberFormat = PhoneNumberFormat;
  // preferredCountries: CountryISO[] = [
  //   CountryISO.UnitedStates,
  //   CountryISO.UnitedKingdom,
  // ];

  phoneForm = new FormGroup({
    phone: new FormControl(undefined as any, [Validators.required]),
  });

  // changePreferredCountries() {
  //   this.preferredCountries = [CountryISO.India, CountryISO.Canada];
  // }

  constructor(
    private commentService: CommentStoreService,
    private route: ActivatedRoute,
  ) {
    this.comment.productId = this.route.snapshot.params['id'];
    this.query.productId = this.comment.productId;
    this.query.page = 1;
    this.query.itemPerPage = 3;

    this.getComments('');
  }

  numberChanged(phone: string){
    this.phoneForm.value.phone = phone;
  }

  addComment() {
    this.comment.phone = this.phoneForm.value.phone?.e164Number;
    this.commentService.add(this.comment).subscribe({
      next: (response) => {
        console.log('Comment added successfully:', response);
        this.comment = { rating: 0 } as Comment;
        this.phoneForm.reset();
        this.comment.text = '';
      },
    });
  }

  getComments(
    sort: '' | 'DATE_DESC' | 'DATE_ASC' | 'RATING_DESC' | 'RATING_ASC',
  ) {
    this.query.sort = sort;

    this.commentService.getByProductId(this.query).subscribe({
      next: (response) => {
        this.productComments = [...this.productComments, ...response.list];

        this.totalLoaded += this.query.itemPerPage;
        this.query.page++;
        if (this.totalLoaded >= response.totalCount) {
          this.isLastPage = true;
        }
      },
    });
  }
}
