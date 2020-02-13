export interface ISteward {
    stewardId: string;
    name: string;
    age: number;
    skill: number;
    loyalty: number;
    resources: number;
    industryId: string | null;
    developmentId: string | null;
    fiefId: string | null;
    marketId: string | null;
    portId: string | null;
    shipyardId: string | null;
}
