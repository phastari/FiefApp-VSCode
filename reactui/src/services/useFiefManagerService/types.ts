import { IFief } from "../../common/models/fief";

export enum FiefManagerStatuses {
    'INITILIZING',
    'LOADING',
    'LOADED',
    'UPDATE',
    'ERROR'
}

export interface FiefManagerState {
    fiefId: string;
    gameSessionId: string;
    fief: IFief | null;
    fiefs: IFief[];
    status: FiefManagerStatuses;
    errors: string;
}

export const initialFiefManagerState: FiefManagerState = {
    fiefId: '',
    gameSessionId: '',
    fief: null,
    fiefs: [],
    status: FiefManagerStatuses.INITILIZING,
    errors: ''
}

export type FiefManagerAction = 
  | { type: FiefManagerActionTypes.FIEFMANAGER_LOAD_FIEF_REQUEST, id: string }
  | { type: FiefManagerActionTypes.FIEFMANAGER_LOAD_FIEF_SUCCESS, fief: IFief }
  | { type: FiefManagerActionTypes.FIEFMANAGER_LOAD_FIEF_FAILURE, errors: string };

export enum FiefManagerActionTypes {
    FIEFMANAGER_LOAD_FIEF_REQUEST = 'FIEFMANAGER_LOAD_FIEF_REQUEST',
    FIEFMANAGER_LOAD_FIEF_SUCCESS = 'FIEFMANAGER_LOAD_FIEF_SUCCESS',
    FIEFMANAGER_LOAD_FIEF_FAILURE = 'FIEFMANAGER_LOAD_FIEF_FAILURE'
}
