import { FiefManagerState, FiefManagerAction, FiefManagerActionTypes, FiefManagerStatuses } from "./types";

export function fiefManagerReducer(state: FiefManagerState, action: FiefManagerAction): FiefManagerState {
    switch (action.type) {
        case FiefManagerActionTypes.FIEFMANAGER_LOAD_FIEF_REQUEST: {
            return { ...state, status: FiefManagerStatuses.LOADING }
        }
        case FiefManagerActionTypes.FIEFMANAGER_LOAD_FIEF_SUCCESS: {
            return { ...state, status: FiefManagerStatuses.LOADED, fief: action.fief, fiefs: [...state.fiefs, action.fief], fiefId: action.fief.fiefId };
        }
        case FiefManagerActionTypes.FIEFMANAGER_LOAD_FIEF_FAILURE: {
            return { ...state, status: FiefManagerStatuses.ERROR, errors: action.errors };
        }
        case FiefManagerActionTypes.FIEFMANAGER_REQUEST_INITIALIZE: {
            return { ...state, status: FiefManagerStatuses.INITIALIZING };
        }
        case FiefManagerActionTypes.FIEFMANAGER_INITIALIZE_SUCCESS: {
            return { 
                ...state, 
                status: FiefManagerStatuses.INITIALIZED, 
                fiefsList: action.init.fiefs, 
                roadsList: action.init.roads, 
                inheritancesList: action.init.inheritances, 
                fiefId: action.init.fiefId, 
                stewards: action.init.stewards, 
                industries: action.init.industries }
        }
        case FiefManagerActionTypes.FIEFMANAGER_INITIALIZE_FAILURE: {
            return { ...state, status: FiefManagerStatuses.ERROR, errors: action.errors }
        }
        default:
        return state;
    }
}
