import { Product } from "../../product/models/product";

export interface CartObject {
    quantity: number;
    product: Product;
}
