interface IndustriesInit {
    status: 'init';
}

interface IndustriesLoading {
    status: 'loading';
}

interface IndustriesLoaded<T> {
    status: 'loaded';
    payload: T;
}

interface IndustriesError {
    status: 'error';
    error: Error;
}

export type IndustriesService<T> =
| IndustriesInit
| IndustriesLoading
| IndustriesLoaded<T>
| IndustriesError;
