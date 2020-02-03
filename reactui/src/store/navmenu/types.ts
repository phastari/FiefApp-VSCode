export interface NavMenuState {
  readonly isOpen: boolean;
  readonly isAuthenticated: boolean;
}

export enum NavMenuActionTypes {
  LOGOUT_REQUEST = '@@nav/LOGOUT_REQUEST',
  LOGOUT_SUCCESS = '@@nav/LOGOUT_SUCCESS',
  LOGOUT_FAILURE = '@@nav/LOGOUT_FAILURE',
  LOGIN_SUCCESS = '@@nav/LOGIN_SUCCESS'
}
