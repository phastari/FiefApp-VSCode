import { ApiResponse } from '../miscellaneous/types';

export interface AuthenticatedUser extends ApiResponse {
  username: string;
  token: string;
}

export interface UserAuthentication {
  username: string;
  password: string;
}

export interface SignupUser {
  userName: string;
  password: string;
  passwordConfirmation: string;
}

export enum AuthenticationActionTypes {
  AUTHENTICATION_LOGIN_REQUEST = '@@authentication/AUTHENTICATION_LOGIN_REQUEST',
  AUTHENTICATION_LOGIN_SUCCESS = '@@authentication/AUTHENTICATION_LOGIN_SUCCESS',
  AUTHENTICATION_LOGIN_FAILURE = '@@authentication/AUTHENTICATION_LOGIN_FAILURE',
  AUTHENTICATION_LOGOUT = '@@authentication/AUTHENTICATION_LOGOUT',
  AUTHENTICATION_LOGOUT_OK = '@@authentication/AUTHENTICATION_LOGOUT_OK',
  SIGNUP_REQUEST = '@@authentication/SIGNUP_REQUEST',
  SIGNUP_SUCCESS = '@@authentication/SIGNUP_SUCCESS',
  SIGNUP_FAILURE = '@@authentication/SIGNUP_FAILURE'
}

export interface AuthenticationState {
  readonly loading: boolean;
  readonly username: string;
  readonly token: string;
  readonly errors?: string;
  readonly isAuthenticated: boolean;
}
