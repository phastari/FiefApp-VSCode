import { ISoldier } from "./soldier";
import { IMerchant } from "./merchant";
import { ISteward } from "./steward";

export interface IMarket {
    marketId: string;
    steward: ISteward | null;
    merchants: IMerchant[];
    soldiers: ISoldier[];
    name: string;
    developmentLevel: number;
    merchandise: number;
    incomeSilver: number;
    incomeBase: number;
    taxes: number;
    bailiffs: number;
    crime: number;
    isBeingDeveloped: boolean;
}
