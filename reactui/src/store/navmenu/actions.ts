import { action } from 'typesafe-actions';
import { NavMenuActionTypes } from './types';

export const logoutRequest = () => action(NavMenuActionTypes.LOGOUT_REQUEST);

export const logoutSuccess = () => action(NavMenuActionTypes.LOGOUT_SUCCESS);

export const logoutError = () => action(NavMenuActionTypes.LOGOUT_FAILURE);

export const loginSuccess = () => action(NavMenuActionTypes.LOGIN_SUCCESS);
