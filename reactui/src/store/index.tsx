import { AuthenticationState } from './authentication/types';
import { History } from 'history';
import { combineReducers } from 'redux';
import { authenticationReducer } from './authentication/reducer';
import { connectRouter, RouterState } from 'connected-react-router';
import { all, fork } from 'redux-saga/effects';
import { NavMenuState } from './navmenu/types';
import { navReducer } from './navmenu/reducer';
import navSaga from './navmenu/sagas';
import { GameSessionsState } from './gamesessions/types';
import { gameSessionsReducer } from './gamesessions/reducer';
import authenticationSaga from './authentication/sagas';
import { FiefManagerState } from './fiefmanager/types';
import { fiefManagerReducer } from './fiefmanager/reducer';
import gameSessionsSaga from './gamesessions/sagas';
import { InformationState } from './information/types';
import { informationReducer } from './information/reducer';
import informationSaga from './information/sagas';

export interface ApplicationState {
  auth: AuthenticationState;
  nav: NavMenuState;
  gs: GameSessionsState;
  fm: FiefManagerState;
  info: InformationState;
  router: RouterState;
}

export const createRootReducer = (history: History) =>
  combineReducers({
    auth: authenticationReducer,
    nav: navReducer,
    gs: gameSessionsReducer,
    fm: fiefManagerReducer,
    info: informationReducer,
    router: connectRouter(history)
  });

export function* rootSaga() {
  yield all([
    fork(authenticationSaga),
    fork(navSaga),
    fork(gameSessionsSaga),
    fork(informationSaga)
  ]);
}
