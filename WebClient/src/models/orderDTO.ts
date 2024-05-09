import { OrderPositionDTO } from "./orderPositionDTO";

export interface OrderDTO {
    id: number;
    userID: number;
    date: string;
    orderPositions: OrderPositionDTO[];
}