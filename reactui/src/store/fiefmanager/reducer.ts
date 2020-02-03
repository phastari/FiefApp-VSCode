import { Reducer } from 'redux';
import { FiefManagerState, FiefManagerActionTypes } from './types';

export const initialFiefState: FiefManagerState = {
  gameSessionId: '',
  fiefId: ''
};

const reducer: Reducer<FiefManagerState> = (
  state = initialFiefState,
  action
) => {
  switch (action.type) {
    case FiefManagerActionTypes.SET_GAMESESSION_ID: {
      return { ...state, gameSessionId: action.payload };
    }
    case FiefManagerActionTypes.SET_FIEF_ID: {
      return { ...state, fiefId: action.payload };
    }
    default: {
      return state;
    }
  }
};

export { reducer as fiefManagerReducer };
