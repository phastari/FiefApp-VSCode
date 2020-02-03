import React from 'react';
import './App.css';
import { Route } from 'react-router-dom';
import Layout from './Layout';
import HomePage from '../pages/HomePage';
import FiefManagerPage from '../pages/FiefManagerPage';
import Login from './authentication/Login';
import GameSessionsPage from '../pages/GameSessionsPage';
import Signup from './authentication/Signup';

export default () => (
  <Layout>
    <Route exact path='/' component={HomePage} />
    <Route path='/gamesessions' component={GameSessionsPage} />
    <Route path='/fiefmanager' component={FiefManagerPage} />
    <Route path='/login' component={Login} />
    <Route path='/signup' component={Signup} />
  </Layout>
);
