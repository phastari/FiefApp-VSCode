import axios from "../../common/api/apiClient"
import { IFief } from "../../common/models/fief"
import { IInitializeFiefManager } from "./types";

export const getFief = async (id: string) => {
    return await axios.get<IFief>('/fief/get', { params: id});
}

export const initializeFiefManager = async (gameSessionId: string) => {
    return await axios.get<IInitializeFiefManager>('/fief/init', { params: gameSessionId })
}
