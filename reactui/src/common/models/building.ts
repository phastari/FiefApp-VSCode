import { IBuilder } from "./builder";

export interface IBuilding {
    buildingId: string;
    builder: IBuilder | null;
    type: string;
    amount: number;
    woodworkThisYear: number;
    stoneworkThisYear: number;
    smithsworkThisYear: number;
    woodThisYear: number;
    stoneThisYear: number;
    ironThisYear: number;
    upkeep: number;
    woodwork: number;
    stonework: number;
    smithswork: number;
    wood: number;
    stone: number;
    iron: number;
}
