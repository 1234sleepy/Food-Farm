import { Product } from "../../product/models/product";

export interface OrderItem {
    orderId: string;
    productId: string;
    product: Product;
    quantity: number;
}
