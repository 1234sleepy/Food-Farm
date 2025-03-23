import { HttpParams } from "@angular/common/http";

export class PaginationQuery {
    page: number = 1;
    itemPerPage: number = 12;

    toParams() {
        return new HttpParams()
            .set('page', this.page)
            .set("itemPerPage", this.itemPerPage);
    }
}