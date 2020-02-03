import { InformationState, InformationActionTypes } from './types';
import { Reducer } from 'redux';
import { Fief } from '../../common/models/Fief';

export const initialInformationState: InformationState = {
  fiefId: '',
  gameSessionId: '',
  fief: {} as Fief,
  errors: undefined,
  loading: false
};

const reducer: Reducer<InformationState> = (
  state = initialInformationState,
  action
) => {
  switch (action.type) {
    case InformationActionTypes.FETCH_FIEF_REQUEST: {
      return { ...state, loading: true };
    }
    case InformationActionTypes.FETCH_FIEF_SUCCESS: {
      return {
        ...state,
        loading: false,
        fief: action.payload
      };
    }
    case InformationActionTypes.FETCH_FIEF_FAILURE: {
      return {
        ...state,
        loading: false,
        errors: action.payload
      };
    }
    default: {
      return state;
    }
  }
};

export { reducer as informationReducer };
