export interface IGameSession {
    gameSessionId: string;
    name: string;
}

export interface IGameSessions {
    gameSessions: IGameSession[]
}