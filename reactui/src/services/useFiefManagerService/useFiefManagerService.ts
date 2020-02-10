import { useState, useEffect } from "react";
import axios from "../../common/api/apiClient";
import { IFief } from "../../common/models/fief";
import { FiefManagerStatuses } from "./types";

const useFiefManagerService = () => {
    const [gameSessionId, setGameSessionId] = useState('');
    const [fiefId, setFiefId] = useState('');
    const [fiefs] = useState<IFief[]>([]);
    const [fief, setFief] = useState<IFief | undefined>(undefined);
    const [status, setStatus] = useState<FiefManagerStatuses>(FiefManagerStatuses.INITILIZING);
    const [errors, setErrors] = useState('');

    useEffect(() => {
        if (status === FiefManagerStatuses.INITILIZING) {
            
        } else if (status === FiefManagerStatuses.UPDATE) {
            setStatus(FiefManagerStatuses.LOADED);
        } else if (status !== FiefManagerStatuses.LOADED && fief === undefined) {
            axios.get<IFief>('/fief/get', { params: gameSessionId })
            .then(response => {
                fiefs.push(response.data);
                setFiefId(response.data.fiefId);
                setFief(response.data);
                setErrors('');
                setStatus(FiefManagerStatuses.LOADED);
            })
            .catch(error => {
                setStatus(FiefManagerStatuses.ERROR);
                setErrors(error);
            });
        } else if (status !== FiefManagerStatuses.LOADED && fief !== undefined) {
            let exists = fiefs.filter(o => o.fiefId === fiefId);
            
            if (exists.length > 0) {
                setFief(exists[0]);
                setStatus(FiefManagerStatuses.LOADED);
            } else {
                axios.get<IFief>('/fief/get', { params: fiefId })
                .then(response => {
                    fiefs.push(response.data);
                    setFief(response.data);
                    setErrors('');
                    setStatus(FiefManagerStatuses.LOADED);
                })
                .catch(error => {
                    setStatus(FiefManagerStatuses.ERROR);
                    setErrors(error);
                });
            }
        }
    }, [status, errors, fief, fiefId, fiefs, gameSessionId]);

    return {status, setStatus, fiefs, fief, errors, setErrors, setGameSessionId, setFiefId};
}

export default useFiefManagerService;