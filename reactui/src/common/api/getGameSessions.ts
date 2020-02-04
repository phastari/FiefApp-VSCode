import { apiClient } from "./apiClient"
import { IGameSessions } from "../types/gamesession"
import { AxiosError } from "axios";
import { ServerError } from "../types/servererror";


export const getGameSessions = async () => {
    try {
        const response = await apiClient.get<IGameSessions>('/gamesession/getgamesessions');
        return response.data;
    } catch (err) {
        if (err && err.response) {
            const axiosError = err as AxiosError<ServerError>
            return axiosError.response?.data;
        }

        throw err;
    }
};
