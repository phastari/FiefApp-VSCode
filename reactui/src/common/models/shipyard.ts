import { IBoatbuilder } from "./boatbuilder";
import { IBoat } from "./boat";
import { ISteward } from "./steward";

export interface IShipyard {
    shipyardId: string;
    steward: ISteward | null;
    boatbuilders: IBoatbuilder[];
    boats: IBoat[];
    name: string;
    isBeingDeveloped: boolean;
    incomeSilver: number;
    smallDocks: number;
    mediumDocks: number;
    largeDocks: number;
    populationModifier: number;
}
