import { action } from 'typesafe-actions';
import {
  AuthenticationActionTypes,
  AuthenticatedUser,
  UserAuthentication,
  SignupUser
} from './types';

export const loginRequest = (user: UserAuthentication) =>
  action(AuthenticationActionTypes.AUTHENTICATION_LOGIN_REQUEST, user);

export const loginSuccess = (user: AuthenticatedUser) =>
  action(AuthenticationActionTypes.AUTHENTICATION_LOGIN_SUCCESS, user);

export const loginError = (message: string) =>
  action(AuthenticationActionTypes.AUTHENTICATION_LOGIN_FAILURE, message);

export const logout = () =>
  action(AuthenticationActionTypes.AUTHENTICATION_LOGOUT);

export const logoutOk = () =>
  action(AuthenticationActionTypes.AUTHENTICATION_LOGOUT_OK);

export const signupRequest = (user: SignupUser) =>
  action(AuthenticationActionTypes.SIGNUP_REQUEST, user);

export const signupSuccess = (user: AuthenticatedUser) =>
  action(AuthenticationActionTypes.SIGNUP_SUCCESS, user);

export const signupFailure = (message: string) =>
  action(AuthenticationActionTypes.SIGNUP_FAILURE, message);
