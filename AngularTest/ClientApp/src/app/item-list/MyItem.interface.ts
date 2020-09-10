
//initialize an interface to be used as a data type for the whole application
export interface MyItem {

  Id: number;
  SellRent: number;
  Name: string;
  Type: string;
  Price: number;
  // '?' define optional field
  Image?: string;
}
