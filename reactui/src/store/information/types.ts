import { Fief } from '../../common/models/Fief';
import { ApiResponse } from '../miscellaneous/types';

export interface FetchedFief extends ApiResponse {
  fief: Fief;
}

export interface FetchFiefRequest {
  Id: string;
}

export enum InformationActionTypes {
  FETCH_FIEF_REQUEST = '@@information/FETCH_FIEF_REQUEST',
  FETCH_FIEF_SUCCESS = '@@information/FETCH_FIEF_SUCCESS',
  FETCH_FIEF_FAILURE = '@@information/FETCH_FIEF_FAILURE',
  SAVE_INFORMATION_COMMAND = '@@information/SAVE_INFORMATION_COMMAND'
}

export interface InformationState {
  readonly fiefId: string;
  readonly gameSessionId: string;
  readonly loading: boolean;
  readonly fief: Fief;
  readonly errors?: string;
}
