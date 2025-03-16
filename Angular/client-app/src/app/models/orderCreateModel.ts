import { CartObject } from "./cartObject";
import { ItemModel } from "./itemModel";

export interface OrderCreateModel {
    name: string;
    phone: string;
    items: ItemModel[];
    description: string;
    email: string;
}