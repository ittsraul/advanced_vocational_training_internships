export class items{
   id: number | undefined;
   name: string;
   price: number;
   description?: string;
   image?: string;
   categoryId?: number;
   categoryName?: string;
  constructor(
    id: number | undefined, 
    name: string, 
    price: number, 
    description?: string, 
    image?: string, 
    categoryId?: number, 
    categoryName?: string
) {
    this.id = id
    this.name = name
    this.price = price
    this.description = description
    this.image = image
    this.categoryId = categoryId
    this.categoryName = categoryName
  }}