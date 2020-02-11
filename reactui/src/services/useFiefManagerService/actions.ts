import axios from "../../common/api/apiClient"
import { IFief } from "../../common/models/fief"

export const getFief = async (id: string) => {
    console.log('action');
    let response = await axios.get<IFief>('/fief/get', { params: id});
    console.log(response);
    return response;
}

export const changeFiefId = (id: string) => {
    
}