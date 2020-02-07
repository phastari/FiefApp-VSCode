import { setLocalStorage } from "../../common/jwt/jwtToken";
import axios, { TOKEN_KEY, setToken } from "../../common/api/authenticationApi";
import { IAuthenticatedUser, IAuthenticationUser } from "./types";

export const handleUserResponse = (user: IAuthenticatedUser) => {
    setLocalStorage(TOKEN_KEY, user.token);
    setToken(user.token);
    return user;
}

export const getCurrentUser = async () => {
    return axios.get<IAuthenticatedUser>('/currentuser');
}

export const login = async (user: IAuthenticationUser) => {
    const response = await axios.post<IAuthenticatedUser>('/user/login', user);
    return handleUserResponse(response.data);
}

export const register = async (user: IAuthenticationUser) => {
    return axios.post<IAuthenticatedUser>('/register', user);
}

export const logout = () => {
    localStorage.removeItem(TOKEN_KEY);
    setToken(null);
}
