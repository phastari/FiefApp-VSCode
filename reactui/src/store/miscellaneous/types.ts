export type ApiResponse = Record<string, any>;

export const API_ENDPOINT =
  process.env.REACT_APP_API_ENDPOINT || 'http://localhost:5000';
