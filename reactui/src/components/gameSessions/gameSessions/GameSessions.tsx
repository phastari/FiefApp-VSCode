import React, { Fragment } from 'react';
import useGameSessionsService from '../../../common/services/useGameSessionsService/useGameSessionsService';



const GameSessions: React.FC = () => {
    const service = useGameSessionsService();
    
    return (
        <Fragment>
            {service.status === 'loading' && <div>Loading...</div>}

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
