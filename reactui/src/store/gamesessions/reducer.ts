import { GameSessionsState, GameSessionsActionTypes } from './types';
import { Reducer } from 'redux';

export const initialGameSessionsState: GameSessionsState = {
  data: [],
  errors: undefined,
  loading: false
};

const reducer: Reducer<GameSessionsState> = (
  state = initialGameSessionsState,
  action
) => {
  switch (action.type) {
    case GameSessionsActionTypes.FETCH_GAMESESSIONS_REQUEST: {
      return { ...state, loading: true, errors: '' };
    }
    case GameSessionsActionTypes.FETCH_GAMESESSIONS_SUCCESS: {
      return {
        ...state,
        loading: false,
        data: action.payload
      };
    }
    case GameSessionsActionTypes.FETCH_GAMESESSIONS_FAILURE: {
      return {
        ...state,
        loading: false,
        errors: action.payload
      };
    }
    case GameSessionsActionTypes.CREATE_GAMESESSION_COMMAND: {
      return { ...state, loading: true, errors: '' };
    }
    case GameSessionsActionTypes.CREATE_GAMESESSION_SUCCESS: {
      return { ...state, loading: false };
    }
    case GameSessionsActionTypes.CREATE_GAMESESSION_FAILURE: {
      return { ...state, loading: false, errors: action.payload };
    }
    case GameSessionsActionTypes.DELETE_GAMESESSION_COMMAND: {
      return { ...state, loading: true, errors: '' };
    }
    case GameSessionsActionTypes.DELETE_GAMESESSION_SUCCESS: {
      return { ...state, loading: false };
    }
    case GameSessionsActionTypes.DELETE_GAMESESSION_FAILURE: {
      return { ...state, loading: false, errors: action.payload };
    }
    default: {
      return state;
    }
  }
};

export { reducer as gameSessionsReducer };
