import { useState, useEffect } from "react";
import { GameSessionsService } from "./states";
import { IGameSessions, IGameSession } from "./types";
import { apiClient } from "../../common/api/apiClient";

const useGameSessionsService = () => {
    const [result, setResult] = useState<GameSessionsService<IGameSession[]>>({
        status: 'loading'
    });

    useEffect(() => {
        if (result.status !== 'loaded') {
            setTimeout(function () {
                apiClient.get<IGameSessions>('/gamesession/getgamesessions')
                .then(response => setResult({ status: 'loaded', payload: response.data.gameSessions }))
                .catch(error => setResult({ status: 'error', error }));
            }, 1000);
            
        }
    }, [result.status]);

    return result;
}

export default useGameSessionsService;