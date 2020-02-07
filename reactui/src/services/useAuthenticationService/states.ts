export interface AuthenticationState {
    authenticating: boolean;
    isAuthenticated: boolean;
    username: string | null;
    token: string | null;
}

export const initialAuthenticationState: AuthenticationState = {
    authenticating: false,
    isAuthenticated: false,
    username: null,
    token: null
}
