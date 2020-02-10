import { ISoldier } from "./soldier";

export interface IRoad {
    roadId: string;
    soldiers: ISoldier[];
    name: string;
    type: string;
    upgradeBaseCost: number;
    upgradeStoneCost: number;
    modificationFactor: number;
}
