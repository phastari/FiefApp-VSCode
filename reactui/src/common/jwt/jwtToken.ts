import jwtDecode from 'jwt-decode';

export function getLocalStorageValue(key: string) {
  const value = localStorage.getItem(key);
  if (!value) return null;
  try {
    return JSON.parse(value);
  } catch (error) {
    return null;
  }
}

export function setLocalStorage(key: string, value: string) {
  localStorage.setItem(key, JSON.stringify(value));
}
  
type JWTPayload = {
    id: string;
    username: string;
    exp: number;
};

export function isTokenValid(token: string) {
    try {
        const decoded_jwt: JWTPayload = jwtDecode(token);
        const current_time = Date.now().valueOf() / 1000;
        return decoded_jwt.exp > current_time;
    } catch (error) {
        return false;
    }
}

export const getUsernameFromToken = (token: string) => {
  try {
    const decoded_jwt: JWTPayload = jwtDecode(token);
    const current_time = Date.now().valueOf() / 1000;
    if (decoded_jwt.exp > current_time) {
      return decoded_jwt.username;
    } else {
      return null;
    }
  } catch (error) {
      return null;
  }
}