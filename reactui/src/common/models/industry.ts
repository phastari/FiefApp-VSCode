import { ISoldier } from "./soldier";
import { ISteward } from "./steward";

export interface IIndustry {
    industryId: string;
    steward: ISteward | null;
    name: string;
    industryType: string;

    // Felling
    amountLandclearing?: number;
    amountLandclearingOfFelling?: number;
    amountFelling?: number;
    amountClearUseless?: number;
    isBeingDeveloped?: boolean;

    // Income
    needSteward?: boolean;
    showInIncomes?: boolean;
    silver?: number;
    base?: number;
    luxury?: number;
    wood?: number;
    springModifier?: number;
    summerModifier?: number;
    fallModifier?: number;
    winterModifier?: number;

    // Tax
    numberOfBailiffs?: number;

    // Mine
    soldiers?: ISoldier[];
    type?: string;
    iron?: number;
    yearsLeft?: number;
    guards?: number;
    firstYear?: boolean;
    displayName?: string;
    silverProduction?: number;
    ironProduction?: number;
    luxuryProduction?: number;
    crime?: number;
    populationModifier?: number;

    // Quarry
    stone?: number;

    // Subsidiary
    quality?: number;
    developmentLevel?: number;
    daysworkThisYear?: number;
    incomeFactor?: number;
    incomeInSilver?: number;
    incomeInBase?: number;
    incomeInLuxury?: number;
    daysworkBuild?: number;
    daysworkUpkeep?: number;
}
