interface GameSessionsInit {
    status: 'init';
}

interface GameSessionsLoading {
    status: 'loading';
}

interface GameSessionsLoaded<T> {
    status: 'loaded';
    payload: T;
}

interface GameSessionsError {
    status: 'error';
    error: Error;
}

export type GameSessionsService<T> =
| GameSessionsInit
| GameSessionsLoading
| GameSessionsLoaded<T>
| GameSessionsError;
