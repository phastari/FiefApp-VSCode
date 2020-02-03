import { all, fork, put, takeEvery, call } from 'redux-saga/effects';
import { AuthenticationActionTypes } from './types';
import {
  loginError,
  loginSuccess,
  logoutOk,
  signupFailure,
  signupSuccess
} from './actions';
import { callApi } from '../../common/utils/api';
import { history } from '../..';

const API_ENDPOINT =
  process.env.REACT_APP_API_ENDPOINT || 'http://localhost:5000';

function* handleAuthenticationLogin(action: any) {
  try {
    const res = yield call(
      callApi,
      'post',
      API_ENDPOINT,
      '/user/login',
      action.payload
    );

    if (res.error) {
      yield put(loginError(res.error));
    } else {
      localStorage.setItem('fief_token', res.token);
      history.goBack();
      yield put(loginSuccess(res));
    }
  } catch (err) {
    if (err instanceof Error && err.stack) {
      yield put(loginError(err.stack));
    } else {
      yield put(loginError('An unknown error occured.'));
    }
  }
}

function* handleLogout() {
  localStorage.removeItem('fief_token');
  yield put(logoutOk());
}

function* handleSignup(action: any) {
  try {
    const res = yield call(
      callApi,
      'post',
      API_ENDPOINT,
      '/user/create',
      action.payload
    );

    if (res.errors) {
      yield put(signupFailure(res.error));
    } else {
      localStorage.setItem('fief_token', res.token);
      history.push('/');
      yield put(signupSuccess(res));
    }
  } catch (err) {
    if (err instanceof Error && err.stack) {
      yield put(signupFailure(err.stack));
    } else {
      yield put(signupFailure('An unknown error occured.'));
    }
  }
}

function* watchAuthenticationLoginRequest() {
  yield takeEvery(
    AuthenticationActionTypes.AUTHENTICATION_LOGIN_REQUEST,
    handleAuthenticationLogin
  );
}

function* watchAuthenticationLogout() {
  yield takeEvery(
    AuthenticationActionTypes.AUTHENTICATION_LOGOUT,
    handleLogout
  );
}

function* watchSignupRequest() {
  yield takeEvery(AuthenticationActionTypes.SIGNUP_REQUEST, handleSignup);
}

function* authenticationSaga() {
  yield all([
    fork(watchAuthenticationLoginRequest),
    fork(watchAuthenticationLogout),
    fork(watchSignupRequest)
  ]);
}

export default authenticationSaga;
