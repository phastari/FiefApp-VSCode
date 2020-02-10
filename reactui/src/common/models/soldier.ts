import { IMerchant } from "./merchant";
import { IBoat } from "./boat";
import { IMarket } from "./market";
import { IPort } from "./port";
import { IRoad } from "./road";
import { IIndustry } from "../../services/useIndustriesService/types";

export interface ISoldier {
    soldierId: string;
    name: string;
    skill: number;
    resources: number;
    loyalty: number;
    age: number;
    merchant?: IMerchant;
    boat?: IBoat;
    market?: IMarket;
    port?: IPort;
    road?: IRoad;
    mine?: IIndustry;
    quarry?: IIndustry;
    isResident: boolean;
    amount: number;
    type: string;
    displayName: string;
    silverCost: number;
    baseCost: number;
    accommodation: boolean;
}
