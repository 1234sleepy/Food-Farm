import { HttpParams } from "@angular/common/http";
import { PaginationQuery } from "./pagination-query";

export class GetCommentsByIdQuery extends PaginationQuery {
    productId: string = "";
    sort: "" | "DATE_DESC" | "DATE_ASC" | "RATING_DESC" | "RATING_ASC" = "";

    override toParams(): HttpParams {
        return super.toParams()
            .set('productId', this.productId)
            .set('sort', this.sort);
    }
}