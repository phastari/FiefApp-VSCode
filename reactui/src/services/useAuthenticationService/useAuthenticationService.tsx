import React, { Dispatch, createContext, PropsWithChildren } from 'react';
import { AuthenticationState, initialAuthenticationState } from './states';
import { AuthenticationAction, AuthenticationActionTypes } from './types';
import { authenticationReducer } from './reducers';
import { getLocalStorageValue, isTokenValid, getUsernameFromToken } from '../../common/jwt/jwtToken';
import { setToken, TOKEN_KEY } from '../../common/api/apiClient';
import { logout } from './actions';

type AuthenticationContextProps = {
    state: AuthenticationState;
    dispatch: Dispatch<AuthenticationAction>;
};

const AuthenticationContext = createContext<AuthenticationContextProps>({
    state: initialAuthenticationState,
    dispatch: () => initialAuthenticationState,
});

export const AuthenticationProvider: React.FC<PropsWithChildren<{}>> = (props) => {
  const [state, dispatch] = React.useReducer(authenticationReducer, initialAuthenticationState);
  React.useEffect(() => {
    const token = getLocalStorageValue(TOKEN_KEY);

    if (!token) return;

    if (isTokenValid(token)) {
      setToken(token);
      let username = getUsernameFromToken(token) as string;
      dispatch({ type: AuthenticationActionTypes.AUTHENTICATION_LOGIN_SUCCESS, token: token, username: username });
    } else {
      dispatch({ type: AuthenticationActionTypes.AUTHENTICATION_LOGIN_FAILURE, errors: 'Invalid token!' });
      logout();
    }
  }, []);

  return <AuthenticationContext.Provider value={{ state, dispatch }} {...props} />;
}

export default function useAuthenticationService() {
  return React.useContext(AuthenticationContext);
}
