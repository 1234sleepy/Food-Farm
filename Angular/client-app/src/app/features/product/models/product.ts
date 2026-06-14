import { CharacteristicModel } from './characteristicModel';
import { Imagee } from './image';
import { Label } from './label';

export interface Product {
  id: string;
  name: string;
  description: string;
  price: number;
  discountPrice: number | null;
  quantitySold: number;
  quantityLimit: number;
  images: Imagee[] | null;
  totalCommentsQuantity: number;
  totalRating: number;
  labels: Label[] | null;
  isVisible: boolean;
  quantity: number;
  _quantity: number;
  _mainImageUrl: string;
  createdAt: string;
  characteristics: CharacteristicModel[];
  _rating: number;
  _isDiscounted: boolean;
  _priceWithDiscount: number;
}
