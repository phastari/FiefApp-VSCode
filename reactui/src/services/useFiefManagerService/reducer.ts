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
        default:
        return state;
    }
}
