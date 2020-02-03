import { GameSession } from '../../common/models/GameSession';

export enum GameSessionsActionTypes {
  FETCH_GAMESESSIONS_REQUEST = '@@gamesession/FETCH_GAMESESSIONS_REQUEST',
  FETCH_GAMESESSIONS_SUCCESS = '@@gamesession/FETCH_GAMESESSIONS_SUCCESS',
  FETCH_GAMESESSIONS_FAILURE = '@@gamesession/FETCH_GAMESESSIONS_FAILURE',
  CREATE_GAMESESSION_COMMAND = '@@gamesession/CREATE_GAMESESSION_COMMAND',
  CREATE_GAMESESSION_SUCCESS = '@@gamesession/CREATE_GAMESESSION_SUCCESS',
  CREATE_GAMESESSION_FAILURE = '@@gamesession/CREATE_GAMESESSION_FAILURE',
  DELETE_GAMESESSION_COMMAND = '@@gamesession/DELETE_GAMESESSION_COMMAND',
  DELETE_GAMESESSION_SUCCESS = '@@gamesession/DELETE_GAMESESSION_SUCCESS',
  DELETE_GAMESESSION_FAILURE = '@@gamesession/DELETE_GAMESESSION_FAILURE'
}

export interface GameSessionsState {
  readonly loading: boolean;
  readonly data: GameSession[];
  readonly errors?: string;
}

export interface IdObject {
  id: string;
}
