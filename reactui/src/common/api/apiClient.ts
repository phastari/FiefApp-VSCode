import { navigate } from '@reach/router';
import axios from 'axios';

export const TOKEN_KEY = 'token';

axios.defaults.baseURL = 'http://localhost:5000/api';
axios.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    switch (error.response.status) {
      case 401:
        navigate('/register');
        break;
      case 404:
      case 403:
        navigate('/');
        break;
      case 500:
        navigate('/');
        break;
    }
    return Promise.reject(error.response);
  },
);

export function setToken(token: string | null) {
  if (token) {
    axios.defaults.headers.common['Authorization'] = `Token ${token}`;
  } else {
    delete axios.defaults.headers.common['Authorization'];
  }
}

export interface JWTPayload {
  id: string;
  username: string;
  exp: number;
};

export default axios;