export interface IGameSession {
    gameSessionId: string;
    name: string;
    created: Date;
    lastUsed: Date;
}

export interface IGameSessions {
    gameSessions: IGameSession[]
}
