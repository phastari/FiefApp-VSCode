import { action } from 'typesafe-actions';
import { FiefManagerActionTypes } from './types';

export const setGameSessionId = (id: string) =>
  action(FiefManagerActionTypes.SET_GAMESESSION_ID, id);

export const setFiefId = (id: string) =>
  action(FiefManagerActionTypes.SET_FIEF_ID, id);
