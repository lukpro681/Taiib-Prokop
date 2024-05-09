import { ProductDTO } from "./productDTO";

export interface OrderPositionDTO {
    id: number;
    orderID: number;
    amount: number;
    price: number;
    products: ProductDTO[];
}