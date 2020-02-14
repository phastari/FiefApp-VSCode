import axios from "../../../common/api/apiClient";
import { AxiosError } from "axios";
import { IGameSession } from "../../../common/models/gamesession";

export const createGameSession = async () => {
    try {
        const response = await axios.post<IGameSession>('/gamesession/create');
        return response.data;
    } catch (err) {
        if (err && err.response) {
            const axiosError = err as AxiosError;
            return axiosError.response?.data;
        }

        throw err;
    }
}

export const deleteGameSession = async (gameSessionId: string) => {
    try {
        const response = await axios.post<boolean>('/gamesession/delete', { gameSessionId: gameSessionId });
        return response.data;
    } catch (err) {
        if (err && err.response) {
            const axiosError = err as AxiosError;
            return axiosError.request?.data;
        }
    }
}
