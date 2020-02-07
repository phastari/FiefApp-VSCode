import { apiClient } from "../../common/api/apiClient";
import { setLocalStorage } from "../../common/jwt/jwtToken";
import { TOKEN_KEY, setToken } from "../../common/api/authenticationApi";

export type AuthenticationAction =
  | {
      type: 'LOGIN_REQUEST';
    }
  | {
      type: 'LOGIN_SUCCESS';
      username: string;
      token: string;
    }
  | { type: 'LOGIN_FAILURE'; }
  | { type: 'LOGOUT_REQUEST'; };

interface User {
    username: string;
    token: string;
    errors?: string;
}

export const handleUserResponse = (user: User) => {
    setLocalStorage(TOKEN_KEY, user.token);
    setToken(user.token);
    return user;
}

export const getCurrentUser = async () => {
    return apiClient.get<User>('/currentuser');
}

export const login = async (username: string, password: string) => {
    const user = await apiClient.post<User>('/user/login', {
        username: username, password: password
    });
    return handleUserResponse(user.data);
}

export const register = async (user: { username: string; password: string; confirmPassword: string; }) => {
    return apiClient.post<User>('/register', user);
}

export const logout = () => {
    localStorage.removeItem(TOKEN_KEY);
    setToken(null);
}
