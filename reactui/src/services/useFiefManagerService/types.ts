import { IFief } from "../../common/models/fief";
import { IIndustry } from "../../common/models/industry";
import { ISteward } from "../../common/models/steward";

export enum FiefManagerStatuses {
    'INITIAL',
    'INITIALIZING',
    'INITIALIZED',
    'LOADING',
    'LOADED',
    'UPDATE',
    'ERROR'
}

export interface FiefManagerState {
    fiefId: string;
    gameSessionId: string;
    fief: IFief | null;
    status: FiefManagerStatuses;
    errors: string;
    fiefsList: IShortFief[];
    roadsList: IShortRoad[];
    inheritancesList: IShortInheritance[];
    stewards: ISteward[];
    industries: IIndustry[];
}

export const initialFiefManagerState: FiefManagerState = {
    fiefId: '',
    gameSessionId: '',
    fief: null,
    status: FiefManagerStatuses.INITIAL,
    errors: '',
    fiefsList: [],
    roadsList: [],
    inheritancesList: [],
    stewards: [],
    industries: []
}

export interface IShortFief {
    fiefId: string;
    name: string;
}

export interface IShortInheritance {
    inheritanceId: string;
    type: string;
    description: string;
}

export interface IShortRoad {
    roadId: string;
    type: string;
}

export interface IInitializeFiefManager {
    fiefs: IShortFief[];
    roads: IShortRoad[];
    inheritances: IShortInheritance[];
    fiefId: string;
    industries: IIndustry[];
    stewards: ISteward[];
}

export type FiefManagerAction = 
  | { type: FiefManagerActionTypes.FIEFMANAGER_LOAD_FIEF_REQUEST }
  | { type: FiefManagerActionTypes.FIEFMANAGER_LOAD_FIEF_SUCCESS, fief: IFief }
  | { type: FiefManagerActionTypes.FIEFMANAGER_LOAD_FIEF_FAILURE, errors: string }
  | { type: FiefManagerActionTypes.FIEFMANAGER_INITIALIZE, id: string}
  | { type: FiefManagerActionTypes.FIEFMANAGER_REQUEST_INITIALIZE}
  | { type: FiefManagerActionTypes.FIEFMANAGER_INITIALIZE_SUCCESS, init: IInitializeFiefManager}
  | { type: FiefManagerActionTypes.FIEFMANAGER_INITIALIZE_FAILURE, errors: string };

export enum FiefManagerActionTypes {
    FIEFMANAGER_LOAD_FIEF_REQUEST = 'FIEFMANAGER_LOAD_FIEF_REQUEST',
    FIEFMANAGER_LOAD_FIEF_SUCCESS = 'FIEFMANAGER_LOAD_FIEF_SUCCESS',
    FIEFMANAGER_LOAD_FIEF_FAILURE = 'FIEFMANAGER_LOAD_FIEF_FAILURE',
    FIEFMANAGER_INITIALIZE = 'FIEFMANAGER_INITIALIZE',
    FIEFMANAGER_REQUEST_INITIALIZE = 'FIEFMANAGER_REQUEST_INITIALIZE',
    FIEFMANAGER_INITIALIZE_SUCCESS = 'FIEFMANAGER_INITIALIZE_SUCCESS',
    FIEFMANAGER_INITIALIZE_FAILURE = 'FIEFMANAGER_INITIALIZE_FAILURE'
}
