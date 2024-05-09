import { BasketPositionDTO } from "./basketPositionDTO";
import { OrderDTO } from "./orderDTO";

export enum TypeEnum
{
    Admin,
    Casual
}

export interface UserDTO {
    iD: number;
    login: string;
    password: string;
    type: TypeEnum;
    isActive: boolean;
    basketPositions: BasketPositionDTO[];
    orders: OrderDTO[];
}