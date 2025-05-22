import { Product } from "./product";

export interface OrderItem {
    orderId: string;
    productId: string;
    product: Product;
    quantity: number;
}