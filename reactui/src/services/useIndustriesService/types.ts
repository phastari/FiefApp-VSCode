export interface IIndustry {
    industryId: string;
    name: string;
    industryType: string;
    amountLandclearing: number | undefined;
    amountLandclearingOfFelling: number | undefined;
    amountFelling: number | undefined;
    amountClearUseless: number | undefined;
    isBeingDeveloped: boolean | undefined;
}

export interface IIndustries {
    Industries: IIndustry[]
}