import React, { Dispatch, createContext, PropsWithChildren } from 'react';
import { AuthenticationState, initialAuthenticationState } from './states';
import { AuthenticationAction, logout } from './actions';
import { authenticationReducer } from './reducers';
import { getLocalStorageValue, isTokenValid } from '../../common/jwt/jwtToken';
import { setToken, TOKEN_KEY } from '../../common/api/authenticationApi';

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
      dispatch({ type: 'LOGIN_SUCCESS', token: token, username: token.username });
    } else {
      dispatch({ type: 'LOGIN_FAILURE' });
      logout();
    }
  }, []);

  return <AuthenticationContext.Provider value={{ state, dispatch }} {...props} />;
}

export default function useAuthenticationService() {
  return React.useContext(AuthenticationContext);
}
