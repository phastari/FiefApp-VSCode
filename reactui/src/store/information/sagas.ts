import { all, fork, put, takeEvery, call } from 'redux-saga/effects';
import { callApi } from '../../common/utils/api';
import { InformationActionTypes } from './types';
import { API_ENDPOINT } from '../miscellaneous/types';
import { fetchFiefFailed, fetchFiefSuccess } from './actions';

function* handleFetchFiefRequest(action: any) {
  try {
    const res = yield call(
      callApi,
      'post',
      API_ENDPOINT,
      '/fief/get',
      action.payload
    );

    if (res.error) {
      yield put(fetchFiefFailed(res.error));
    } else {
      yield put(fetchFiefSuccess(res));
    }
  } catch (err) {
    if (err instanceof Error && err.stack) {
      yield put(fetchFiefFailed(err.stack));
    } else {
      yield put(fetchFiefFailed('An unknown error occured.'));
    }
  }
}

function* watchFetchFiefRequest() {
  yield takeEvery(
    InformationActionTypes.FETCH_FIEF_REQUEST,
    handleFetchFiefRequest
  );
}

function* informationSaga() {
  yield all([fork(watchFetchFiefRequest)]);
}

export default informationSaga;
