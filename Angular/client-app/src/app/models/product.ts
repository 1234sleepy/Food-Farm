import { Image } from "./image";
import { Label } from "./label";

export interface Product {
    id: string
    name: string;
    description: string;
    price: number;
    discountPrice: number | null;
    quantitySold: number;
    quantityLimit: number;
    images : Image[] | null; 
    totalCommentsQuantity: number;
    totalRating: number;
    labels: Label[] | null;
    isVisible: boolean;
    _quantity: number;
    _mainImageUrl: string;
}