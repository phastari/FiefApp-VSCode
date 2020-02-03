import { NavMenuState, NavMenuActionTypes } from './types';
import { Reducer } from 'redux';

export const initialNavMenuState: NavMenuState = {
  isOpen: false,
  isAuthenticated: false
};

const reducer: Reducer<NavMenuState> = (
  state = initialNavMenuState,
  action
) => {
  switch (action.type) {
    case NavMenuActionTypes.LOGOUT_REQUEST: {
      return { ...state };
    }
    case NavMenuActionTypes.LOGOUT_SUCCESS: {
      return { ...state, isAuthenticated: false };
    }
    case NavMenuActionTypes.LOGOUT_FAILURE: {
      return { ...state };
    }
    case NavMenuActionTypes.LOGIN_SUCCESS: {
      return { ...state, isAuthenticated: true };
    }

    default: {
      return state;
    }
  }
};

export { reducer as navReducer };
