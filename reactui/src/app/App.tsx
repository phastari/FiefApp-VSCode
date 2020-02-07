import React, { Fragment, useEffect } from 'react';
import './App.css';
import GameSessions from '../components/gameSessions/gameSessions/GameSessions';
import useAuthenticationService, { AuthenticationProvider } from '../services/useAuthenticationService/useAuthenticationService';
import { getCurrentUser } from '../services/useAuthenticationService/actions';
import { Router } from '@reach/router';
import Home from '../components/home/Home';
import TopNavBar from '../components/topNavBar/TopNavBar';

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
            dispatch({ type: 'LOGIN_SUCCESS', username: payload.data.username, token: payload.data.token });
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
      </Router>
    </Fragment>
  );
}

export default () => (
  <AuthenticationProvider>
    <App />
  </AuthenticationProvider>
)
