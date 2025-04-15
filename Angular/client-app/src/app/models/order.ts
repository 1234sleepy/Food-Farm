import { OrderItem } from "./orderItem";

export interface Order{
    id: string;
    name: string;
    description: string | null;
    phone: string;
    email: string | null;
    createdAt: Date;
    items: OrderItem[];
    totalPrice: number;
    totalDiscount: number;
    disabled: boolean;
    priceWithDiscount: number;
}