import React, { Fragment } from 'react';
import useGameSessionsService from '../../../services/useGameSessionsService/useGameSessionsService';
import Loading from '../../loading/Loading';
import { RouteComponentProps } from '@reach/router';
import { Button } from 'reactstrap';
import { createGameSession, deleteGameSession } from './actions';
import GameSession from '../gameSession/GameSession';
import { GameSessionsStatuses } from '../../../services/useGameSessionsService/types';

const GameSessions: React.FC<RouteComponentProps> = (_: RouteComponentProps) => {
    const service = useGameSessionsService();

    const handleCreate = async () => {
        let session = await createGameSession();

        if (session && service.status === GameSessionsStatuses.LOADED) {
            service.sessions.push(session);
            service.setStatus(GameSessionsStatuses.UPDATE);
        } else {
            console.log(session);
        }
    }

    const handleDelete = async (id: string) => {
        let result = await deleteGameSession(id);

        if (result && service.status === GameSessionsStatuses.LOADED) {
            for (var i = 0; i < service.sessions.length; i++) {
                if (service.sessions[i].gameSessionId === id) {
                    service.sessions.splice(i, 1);
                    service.setStatus(GameSessionsStatuses.UPDATE);
                    break;
                }
            }
        }
    }
    
    return (
        <Fragment>
            {service.status === GameSessionsStatuses.LOADING && <Loading />}

            {service.status === GameSessionsStatuses.ERROR && (
                <div>{service.errors}</div>
            )}

            {service.status === GameSessionsStatuses.LOADED && 
            service.sessions.map(session => (
                <GameSession
                    key={session.gameSessionId}
                    gameSessionId = {session.gameSessionId}
                    name = {session.name}
                    created = {session.created}
                    lastUsed = {session.lastUsed} 
                    handleDelete = {() => handleDelete(session.gameSessionId)}/>
            ))}
            <Button onClick={() => {handleCreate()}}>skapa ny session</Button>
        </Fragment>
    );
};

export default GameSessions;
