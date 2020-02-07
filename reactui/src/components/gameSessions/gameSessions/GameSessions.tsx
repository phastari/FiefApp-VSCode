import React, { Fragment } from 'react';
import useGameSessionsService from '../../../services/useGameSessionsService/useGameSessionsService';
import Loading from '../../loading/Loading';
import { RouteComponentProps } from '@reach/router';

const GameSessions: React.FC<RouteComponentProps> = (_: RouteComponentProps) => {
    const service = useGameSessionsService();
    
    return (
        <Fragment>
            {service.status === 'loading' && <Loading />}

            {service.status === 'error' && (
                <div>Error!</div>
            )}

            {service.status === 'loaded' && 
            service.payload.map(session => (
                <div key={session.gameSessionId}>{session.name}</div>
            ))}
        </Fragment>
    );
};

export default GameSessions;
