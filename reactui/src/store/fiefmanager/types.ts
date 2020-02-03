export enum FiefManagerActionTypes {
  SET_GAMESESSION_ID = '@@fiefmanager/SET_GAMESESSION_ID',
  SET_FIEF_ID = '@@fiefmanager/SET_FIEF_ID'
}

export interface FiefManagerState {
  readonly gameSessionId: string;
  readonly fiefId: string;
}
