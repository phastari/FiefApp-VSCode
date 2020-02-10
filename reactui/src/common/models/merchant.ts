import { ISoldier } from "./soldier";
import { IPort } from "./port";
import { ICargo } from "./cargo";

export interface IMerchant {
    merchantId: string;
    cargo: ICargo | null;
    port: IPort;
    soldiers: ISoldier[];
    status: string;
    name: string;
    skill: number;
    loyalty: number;
    resources: number;
    age: number;
}
