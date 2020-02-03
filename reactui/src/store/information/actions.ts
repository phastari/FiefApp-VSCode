import { action } from 'typesafe-actions';
import { InformationActionTypes, FetchFiefRequest, FetchedFief } from './types';

export const fetchFiefRequest = (idObj: FetchFiefRequest) =>
  action(InformationActionTypes.FETCH_FIEF_REQUEST, idObj);

export const fetchFiefSuccess = (fief: FetchedFief) =>
  action(InformationActionTypes.FETCH_FIEF_SUCCESS, fief);

export const fetchFiefFailed = (message: string) =>
  action(InformationActionTypes.FETCH_FIEF_FAILURE, message);
