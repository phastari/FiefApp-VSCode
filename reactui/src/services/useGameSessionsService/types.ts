export interface IGameSession {
    gameSessionId: string;
    name: string;
    created: Date;
    lastUsed: Date;
}

export interface IGameSessions {
    gameSessions: IGameSession[]
}

export enum GameSessionsStatuses {
    'INITILIZING',
    'LOADING',
    'LOADED',
    'UPDATE',
    'ERROR'
}