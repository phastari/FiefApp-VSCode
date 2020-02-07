export interface AuthenticationState {
    readonly authenticating: boolean;
    readonly isAuthenticated: boolean;
    readonly username: string | null;
    readonly token: string | null;
    readonly errors: string | null;
}

export const initialAuthenticationState: AuthenticationState = {
    authenticating: false,
    isAuthenticated: false,
    username: null,
    token: null,
    errors: null
}
