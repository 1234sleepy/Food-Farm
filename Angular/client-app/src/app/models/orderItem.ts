export interface OrderItem {
    orderId: string;
    productId: string;
    quantity: number;
    discount: number | null;
}