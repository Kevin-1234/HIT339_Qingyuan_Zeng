import { AddItem } from "./addItem";

export interface ShoppingCart {

 shoppingCardId: number;
  userEmail: string;
  items: Array<AddItem>;
  
}
