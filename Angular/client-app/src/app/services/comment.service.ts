import { Injectable } from "@angular/core";
import { environment } from "../environments/environment";
import { HttpClient } from "@angular/common/http";
import { Comment } from "../models/comment";
import { GetCommentsByIdQuery } from "../models/Queries/get-comments-by-id-query";
import { PaginationList } from "../models/paginaion-list.model";

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  private baseUrl: string = environment.apiUrl + '/comment/';
  constructor(private httpClient: HttpClient) { }

  add(comment: Comment) {
    return this.httpClient.post<Comment>(this.baseUrl, comment);
  }

  getByProductId(query: GetCommentsByIdQuery) {
    return this.httpClient.get<PaginationList<Comment>>(this.baseUrl,
       { params: query.toParams() });
  }
}
