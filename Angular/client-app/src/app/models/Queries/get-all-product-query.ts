import { HttpParams } from "@angular/common/http";
import { PaginationQuery } from "./pagination-query";

export class GetAllProductQuery extends PaginationQuery {
    sort: "" | "id" | "name" | "price" | "label"= "";

    minPrice : number = 0;
	maxPrice : number = 0;

    override toParams(): HttpParams {
        return super.toParams()
            .set('sort', this.sort)
            .append('minPrice', this.minPrice)
            .append('maxPrice', this.maxPrice);
    }
}