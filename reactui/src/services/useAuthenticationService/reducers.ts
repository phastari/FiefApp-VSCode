import { AuthenticationState } from "./states";
import { AuthenticationAction, AuthenticationActionTypes } from "./types";

export function authenticationReducer(state: AuthenticationState, action: AuthenticationAction): AuthenticationState {
    switch (action.type) {
        case AuthenticationActionTypes.AUTHENTICATION_LOGIN_REQUEST: {
            return { ...state, isAuthenticated: false, authenticating: true}
        }
        case AuthenticationActionTypes.AUTHENTICATION_LOGIN_SUCCESS: {
        return { ...state, isAuthenticated: true, authenticating: false, username: action.username, token: action.token };
        }
        case AuthenticationActionTypes.AUTHENTICATION_LOGIN_FAILURE: {
        return { ...state, isAuthenticated: false, username: null, token: null, authenticating: false, errors: action.errors };
        }
        case AuthenticationActionTypes.LOGOUT_REQUEST: {
            return { ...state, isAuthenticated: false, username: null, token: null, authenticating: false}
        }
        default:
        return state;
    }
}
