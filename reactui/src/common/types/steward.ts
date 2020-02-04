export interface ISteward {
    stewardId: string;
    name: string;
    age: number;
    skill: number;
    loyalty: number;
    resources: number;
    assignmentId: string;
}

export interface IStewards {
    stewards: ISteward[];
}