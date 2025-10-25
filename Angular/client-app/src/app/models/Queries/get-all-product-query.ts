import { HttpParams } from "@angular/common/http";
import { PaginationQuery } from "./pagination-query";

export class GetAllProductQuery extends PaginationQuery {
    sort: "" | "id" | "name" | "price" | "label"= "";

    override toParams(): HttpParams {
        return super.toParams()
            .set('sort', this.sort);
    }
}