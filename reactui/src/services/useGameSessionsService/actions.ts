import { IGameSessions } from "../../services/useGameSessionsService/types"
import { AxiosError } from "axios";
import axios from "../../common/api/apiClient";


export const getGameSessions = async () => {
    try {
        const response = await axios.get<IGameSessions>('/gamesession/getgamesessions');
        return response.data;
    } catch (err) {
        if (err && err.response) {
            const axiosError = err as AxiosError
            return axiosError.response?.data;
        }

        throw err;
    }
};
