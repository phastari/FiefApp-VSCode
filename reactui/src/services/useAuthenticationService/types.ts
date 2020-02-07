export type AuthenticationAction =
  | { type: AuthenticationActionTypes.AUTHENTICATION_LOGIN_REQUEST }
  | { type: AuthenticationActionTypes.AUTHENTICATION_LOGIN_SUCCESS, username: string, token: string }
  | { type: AuthenticationActionTypes.AUTHENTICATION_LOGIN_FAILURE, errors: string }
  | { type: AuthenticationActionTypes.LOGOUT_REQUEST };

export enum AuthenticationActionTypes {
    AUTHENTICATION_LOGIN_REQUEST = 'AUTHENTICATION_LOGIN_REQUEST',
    AUTHENTICATION_LOGIN_SUCCESS = 'AUTHENTICATION_LOGIN_SUCCESS',
    AUTHENTICATION_LOGIN_FAILURE = 'AUTHENTICATION_LOGIN_FAILURE',
    LOGOUT_REQUEST = 'LOGOUT_REQUEST'
}

export interface IAuthenticatedUser {
    username: string;
    token: string;
    errors?: string;
}

export interface IAuthenticationUser {
    username: string;
    password: string;
  }
