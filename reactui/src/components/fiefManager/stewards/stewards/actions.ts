import { AxiosError } from "axios";
import { ISteward } from "../../../../common/models/steward";
import axios from "../../../../common/api/apiClient";

export const createSteward = async (gameSessionId: string) => {
    try {
        return await axios.post<ISteward>('/steward/create', { gameSessionId: gameSessionId });
    } catch (err) {
        if (err && err.response) {
            const axiosError = err as AxiosError;
            return axiosError.response?.data;
        }

        throw err;
    }
}