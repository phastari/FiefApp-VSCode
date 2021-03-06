import { useState, useEffect } from "react";
import { GameSessionsStatuses } from "./types";
import axios from "../../common/api/apiClient";
import { IGameSession, IGameSessions } from "../../common/models/gamesession";

const useGameSessionsService = () => {
    const [status, setStatus] = useState<GameSessionsStatuses>(GameSessionsStatuses.INITILIZING);
    const [sessions, setSessions] = useState<IGameSession[]>([]);
    const [errors, setErrors] = useState('');

    useEffect(() => {
        if (status === GameSessionsStatuses.UPDATE) {
            setStatus(GameSessionsStatuses.LOADED);
        } else if (status !== GameSessionsStatuses.LOADED) {
            axios.get<IGameSessions>('/gamesession/getgamesessions')
            .then(response => {
                setStatus(GameSessionsStatuses.LOADED);
                setSessions(response.data.gameSessions);
                setErrors('')
            })
            .catch(error => {
                setStatus(GameSessionsStatuses.ERROR);
                setSessions([]);
                setErrors(error.data);
            });
        }
    }, [status, errors]);

    return {status, setStatus, sessions, errors, setErrors};
}

export default useGameSessionsService;