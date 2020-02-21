import React, { Fragment, useEffect } from 'react';
import './App.css';
import './styles.scss';
import GameSessions from '../components/gameSessions/gameSessions/GameSessions';
import useAuthenticationService, { AuthenticationProvider } from '../services/useAuthenticationService/useAuthenticationService';
import { getCurrentUser } from '../services/useAuthenticationService/actions';
import { Router } from '@reach/router';
import Home from '../components/home/Home';
import TopNavBar from '../components/topNavBar/TopNavBar';
import { AuthenticationActionTypes } from '../services/useAuthenticationService/types';
import { FiefManagerProvider } from '../services/useFiefManagerService/useFiefManagerService';
import FiefManager from '../components/fiefManager/FiefManager';

const App = () => {
  const {
    state: { username, token, isAuthenticated, authenticating },
    dispatch,
  } = useAuthenticationService();

  useEffect(() => {
    let ignore = false;

    const fetchUser = async () => {
      if (!authenticating) {
        try {
          const payload = await getCurrentUser();
          if (!ignore) {
            dispatch({ type: AuthenticationActionTypes.AUTHENTICATION_LOGIN_SUCCESS, username: payload.data.username, token: payload.data.token });
          }
        } catch (error) {
          console.log(error);
        }
      }
    }

    if (!username && !token && isAuthenticated) {
      fetchUser();
    }

    return () => {
      ignore = true;
    };
  }, [dispatch, isAuthenticated, username, token, authenticating]);

  if (!username && !token && isAuthenticated) {
    return null;
  }

  return (
    <Fragment>
      <TopNavBar />
      <Router>
        <Home default path='/'/>
        <GameSessions path='gamesessions' />
        <FiefManager path='fiefmanager' />
      </Router>
    </Fragment>
  );
}

export default () => (
  <AuthenticationProvider>
    <FiefManagerProvider>
    <App />
    </FiefManagerProvider>
  </AuthenticationProvider>
)
