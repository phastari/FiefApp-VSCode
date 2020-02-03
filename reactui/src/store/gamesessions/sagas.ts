import { all, fork, put, takeEvery, call } from 'redux-saga/effects';
import { GameSessionsActionTypes } from './types';
import { callApi } from '../../common/utils/api';
import {
  fetchGameSessionsError,
  fetchGameSessionsSuccess,
  createGameSessionFailure,
  createGameSessionSuccess,
  fetchGameSessionsRequest,
  deleteGameSessionFailure,
  deleteGameSessionSuccess
} from './actions';
import { API_ENDPOINT } from '../miscellaneous/types';

function* handleFetchGameSessionsRequest(action: any) {
  try {
    const res = yield call(
      callApi,
      'get',
      API_ENDPOINT,
      '/gamesession/getgamesessions',
      action.payload
    );

    if (res.error) {
      yield put(fetchGameSessionsError(res.error));
    } else {
      yield put(fetchGameSessionsSuccess(res));
    }
  } catch (err) {
    if (err instanceof Error && err.stack) {
      yield put(fetchGameSessionsError(err.stack));
    } else {
      yield put(fetchGameSessionsError('An unknown error occured.'));
    }
  }
}

function* handleCreateGameSessionCommand() {
  try {
    const res = yield call(
      callApi,
      'post',
      API_ENDPOINT,
      '/gamesession/create'
    );

    if (res.error) {
      yield put(createGameSessionFailure(res.error));
    } else {
      yield put(createGameSessionSuccess());
      yield put(fetchGameSessionsRequest());
    }
  } catch (err) {
    if (err instanceof Error && err.stack) {
      yield put(createGameSessionFailure(err.stack));
    } else {
      yield put(createGameSessionFailure('An unknown error occured.'));
    }
  }
}

function* handleDeleteGameSessionCommand(action: any) {
  try {
    const res = yield call(
      callApi,
      'post',
      API_ENDPOINT,
      '/gamesession/delete',
      action.payload
    );

    if (res.error) {
      yield put(deleteGameSessionFailure(res.error));
    } else {
      console.log(res);
      yield put(deleteGameSessionSuccess());
      yield put(fetchGameSessionsRequest());
    }
  } catch (err) {
    if (err instanceof Error && err.stack) {
      yield put(deleteGameSessionFailure(err.stack));
    } else {
      yield put(deleteGameSessionFailure('An unknown error occured.'));
    }
  }
}

function* watchFetchGameSessionsRequest() {
  yield takeEvery(
    GameSessionsActionTypes.FETCH_GAMESESSIONS_REQUEST,
    handleFetchGameSessionsRequest
  );
}

function* watchCreateGameSessionCommand() {
  yield takeEvery(
    GameSessionsActionTypes.CREATE_GAMESESSION_COMMAND,
    handleCreateGameSessionCommand
  );
}

function* watchDeleteGameSessionCommand() {
  yield takeEvery(
    GameSessionsActionTypes.DELETE_GAMESESSION_COMMAND,
    handleDeleteGameSessionCommand
  );
}

function* gameSessionsSaga() {
  yield all([
    fork(watchFetchGameSessionsRequest),
    fork(watchCreateGameSessionCommand),
    fork(watchDeleteGameSessionCommand)
  ]);
}

export default gameSessionsSaga;
