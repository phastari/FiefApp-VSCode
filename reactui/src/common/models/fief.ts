import { IMarket } from "./market";
import { ILivingcondition } from "./livingcondition";
import { IPort } from "./port";
import { IRoad } from "./road";
import { IInheritance } from "./inheritance";
import { IVillage } from "./village";
import { IBuilding } from "./building";
import { IBoat } from "./boat";
import { IResident } from "./resident";
import { ISoldier } from "./soldier";
import { IEmployee } from "./employee";
import { IBuilder } from "./builder";
import { ISteward } from "./steward";
import { IIndustry } from "./industry";

export interface IFief {
    fiefId: string;
    name: string;
    acres: number;
    farmlandAcres: number;
    pastureAcres: number;
    woodlandAcres: number;
    fellingAcres: number;
    unusableAcres: number;
    animalHusbandryQuality: number;
    agriculturalQuality: number;
    fishingQuality: number;
    oreQuality: number;
    animalHusbandryDevelopmentLevel: number;
    agriculturalDevelopmentLevel: number;
    fishingDevelopmentLevel: number;
    woodlandDevelopmentLevel: number;
    oreDevelopmentLevel: number;
    educationDevelopmentLevel: number;
    healthcareDevelopmentLevel: number;
    militaryDevelopmentLevel: number;
    seafaringDevelopmentLevel: number;
    market: IMarket;
    // assigned
    steward?: ISteward;
    port: IPort | null;
    livingcondition: ILivingcondition;
    road: IRoad;
    inheritance: IInheritance;
    villages: IVillage[];
    industries: IIndustry[];
    buildings: IBuilding[];
    boats: IBoat[];
    residents: IResident[];
    soldiers: ISoldier[];
    employees: IEmployee[];
    builders: IBuilder[];
}

export interface IFiefs {
    fiefs: IFief[];
}
