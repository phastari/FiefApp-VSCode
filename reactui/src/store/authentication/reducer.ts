import { AuthenticationState, AuthenticationActionTypes } from './types';
import { Reducer } from 'redux';

export const initialAuthenticationState: AuthenticationState = {
  username: '',
  token: '',
  errors: undefined,
  loading: false,
  isAuthenticated: false
};

const reducer: Reducer<AuthenticationState> = (
  state = initialAuthenticationState,
  action
) => {
  switch (action.type) {
    case AuthenticationActionTypes.AUTHENTICATION_LOGIN_REQUEST: {
      return { ...state, loading: true };
    }
    case AuthenticationActionTypes.AUTHENTICATION_LOGIN_SUCCESS: {
      return {
        ...state,
        isAuthenticated: true,
        loading: false,
        username: action.payload.username,
        token: action.payload.token
      };
    }
    case AuthenticationActionTypes.AUTHENTICATION_LOGIN_FAILURE: {
      return {
        ...state,
        loading: false,
        isAuthenticated: false,
        username: '',
        token: '',
        errors: action.payload
      };
    }
    case AuthenticationActionTypes.AUTHENTICATION_LOGOUT: {
      return {
        ...state,
        loading: false,
        isAuthenticated: false,
        username: '',
        token: ''
      };
    }
    case AuthenticationActionTypes.SIGNUP_REQUEST: {
      return {
        ...state,
        loading: true
      };
    }
    case AuthenticationActionTypes.SIGNUP_SUCCESS: {
      return {
        ...state,
        isAuthenticated: true,
        loading: false,
        username: action.payload.username,
        token: action.payload.token
      };
    }
    case AuthenticationActionTypes.SIGNUP_FAILURE: {
      return {
        ...state,
        loading: false,
        isAuthenticated: false,
        username: '',
        token: '',
        errors: action.payload
      };
    }
    default: {
      return state;
    }
  }
};

export { reducer as authenticationReducer };
