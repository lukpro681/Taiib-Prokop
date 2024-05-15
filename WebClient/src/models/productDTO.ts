import { BasketPositionDTO } from "./basketPositionDTO";
import { OrderPositionDTO } from "./orderPositionDTO";

export interface ProductDTO {
    id: number;
    name: string;
    price: number;
    image: string;
    isActive: boolean;
    basketPositions: BasketPositionDTO[] | null;
    orderPositions: OrderPositionDTO[] | null;
}