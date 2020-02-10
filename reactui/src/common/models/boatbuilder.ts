import { IShipyard } from "./shipyard";

export interface IBoatbuilder {
    boatbuilderId: string;
    assignedToId: string;
    shipyard: IShipyard;
    name: string;
    resources: number;
    skill: number;
    loyalty: number;
    age: number;
}
