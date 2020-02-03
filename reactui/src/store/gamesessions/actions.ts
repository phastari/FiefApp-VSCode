import { action } from 'typesafe-actions';
import { GameSessionsActionTypes, IdObject } from './types';
import { GameSession } from '../../common/models/GameSession';

export const fetchGameSessionsRequest = () =>
  action(GameSessionsActionTypes.FETCH_GAMESESSIONS_REQUEST);

export const fetchGameSessionsSuccess = (data: GameSession[]) =>
  action(GameSessionsActionTypes.FETCH_GAMESESSIONS_SUCCESS, data);

export const fetchGameSessionsError = (message: string) =>
  action(GameSessionsActionTypes.FETCH_GAMESESSIONS_FAILURE, message);

export const createGameSessionCommand = () =>
  action(GameSessionsActionTypes.CREATE_GAMESESSION_COMMAND);

export const createGameSessionSuccess = () =>
  action(GameSessionsActionTypes.CREATE_GAMESESSION_SUCCESS);

export const createGameSessionFailure = (message: string) =>
  action(GameSessionsActionTypes.CREATE_GAMESESSION_FAILURE, message);

export const deleteGameSessionCommand = (id: IdObject) =>
  action(GameSessionsActionTypes.DELETE_GAMESESSION_COMMAND, id);

export const deleteGameSessionSuccess = () =>
  action(GameSessionsActionTypes.DELETE_GAMESESSION_SUCCESS);

export const deleteGameSessionFailure = (message: string) =>
  action(GameSessionsActionTypes.DELETE_GAMESESSION_FAILURE);
