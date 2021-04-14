export interface Lot {
    id: number;
    name: string;
    price: number;
    initialDate?: Date;
    finalDate?: Date;
    quantity: number;
    eventId: number;
}
