import axios from "../../common/api/apiClient";
import { IFief } from "../../common/models/fief";
import { AxiosError } from "axios";
import { ISteward } from "../../common/models/steward";

export const createFief = async (gameSessionId: string) => {
    try {
        let response = await axios.post<IFief>('/fief/create', { gameSessionId: gameSessionId });
        return response.data;
    } catch (err) {
        if (err && err.response) {
            const axiosError = err as AxiosError;
            return axiosError.response?.data;
        }

        throw err;
    }
}

export const deleteFief = async (fiefId: string) => {
    try {
        let response = await axios.delete<boolean>('/fief/delete', { params: fiefId });
        return response.data;
    } catch (err) {
        if (err && err.response) {
            const axiosError = err as AxiosError;
            return axiosError.response?.data;
        }

        throw err;
    }
}

export const createSteward = async (gameSessionId: string) => {
    try {
        let response = await axios.post<ISteward>('/steward/create', { gameSessionId: gameSessionId });
        return response.data;
    } catch (err) {
        if (err && err.response) {
            const axiosError = err as AxiosError;
            return axiosError.response?.data;
        }

        throw err;
    }
}
