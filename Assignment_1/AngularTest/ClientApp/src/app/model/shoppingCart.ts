import { Item } from "./item";

export interface ShoppingCart
{

  
  shoppingCartId: number;
  userEmail: string;
  items: Item[];

}
