import { Injectable } from "@angular/core";
import { environment } from "../../../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { Comment } from "../../models/comment";
import { GetCommentsByIdQuery } from "../../models/get-comments-by-id-query";

import { PaginationList } from '../../../../models/paginationlist';
import { CommentApiService } from "../api/comment.api.service";

@Injectable({
  providedIn: 'root'
})
export class CommentStoreService {
  constructor(private readonly api: CommentApiService) { }

  add(comment: Comment) {
    return this.api.add(comment);
  }

  getByProductId(query: GetCommentsByIdQuery) {
    return this.api.getByProductId(query);
  }
}
