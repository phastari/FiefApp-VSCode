import { AuthenticationState } from "./states";
import { AuthenticationAction } from "./actions";

export function authenticationReducer(state: AuthenticationState, action: AuthenticationAction): AuthenticationState {
    switch (action.type) {
        case 'LOGIN_REQUEST': {
            return { ...state, isAuthenticated: false, authenticating: true}
        }
        case 'LOGIN_SUCCESS': {
        return { ...state, isAuthenticated: true, authenticating: false, username: action.username, token: action.token };
        }
        case 'LOGIN_FAILURE': {
        return { ...state, isAuthenticated: true, username: null, token: null, authenticating: false };
        }
        case 'LOGOUT_REQUEST': {
            return { ...state, isAuthenticated: false, username: null, token: null, authenticating: false}
        }
        default:
        return state;
    }
}
