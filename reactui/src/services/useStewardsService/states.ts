interface StewardsInit {
    status: 'init';
}

interface StewardsLoading {
    status: 'loading';
}

interface StewardsLoaded<T> {
    status: 'loaded';
    payload: T;
}

interface StewardsError {
    status: 'error';
    error: Error;
}

export type StewardsService<T> =
| StewardsInit
| StewardsLoading
| StewardsLoaded<T>
| StewardsError;
