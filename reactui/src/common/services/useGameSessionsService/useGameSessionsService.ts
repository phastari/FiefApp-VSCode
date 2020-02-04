import { useState, useEffect } from "react";
import { Service } from "./states";
import { IGameSessions, IGameSession } from "../../types/gamesession";
import { apiClient } from "../../api/apiClient";

const useGameSessionsService = () => {
    const [result, setResult] = useState<Service<IGameSession[]>>({
        status: 'loading'
    });

    useEffect(() => {
        if (result.status !== 'loaded') {
            apiClient.get<IGameSessions>('/gamesession/getgamesessions')
                .then(response => setResult({ status: 'loaded', payload: response.data.gameSessions }))
                .catch(error => setResult({ status: 'error', error }));
        }
    }, [result.status]);

    return result;
}

export default useGameSessionsService;