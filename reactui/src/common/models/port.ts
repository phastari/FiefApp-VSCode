import { IMerchant } from "./merchant";
import { IBoat } from "./boat";
import { ISoldier } from "./soldier";
import { IShipyard } from "./shipyard";
import { ISteward } from "./steward";

export interface IPort {
    portId: string;
    steward: ISteward | null;
    shipyard: IShipyard | null;
    boats: IBoat[];
    merchants: IMerchant[];
    soldiers: ISoldier[];
    name: string;
    developmentLevel: number;
    merchandise: number;
    incomeSilver: number;
    taxes: number;
    bailiffs: number;
    crime: number;
    isBeingDeveloped: boolean;
}
