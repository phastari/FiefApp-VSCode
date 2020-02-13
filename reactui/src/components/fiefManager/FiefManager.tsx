import React, { Fragment, useState, useEffect } from 'react';
import SideNav from './sideNav/SideNav';
import { FiefManagerIndex } from './types';
import Information from './information/Information';
import { RouteComponentProps } from '@reach/router';
import Stewards from './stewards/stewards/Stewards';
import useFiefManagerService from '../../services/useFiefManagerService/useFiefManagerService';
import { FiefManagerStatuses, FiefManagerActionTypes } from '../../services/useFiefManagerService/types';
import Loading from '../loading/Loading';

const FiefManager: React.FC<RouteComponentProps> = (_: RouteComponentProps) => {
    const [index, setIndex] = useState(FiefManagerIndex.INFORMATION);
    const service = useFiefManagerService();

    useEffect(() => {
        if (service.state.status === FiefManagerStatuses.INITIAL) {
            service.dispatch({ type: FiefManagerActionTypes.FIEFMANAGER_REQUEST_INITIALIZE });
        }
    })
    
    return (
        <Fragment>
            {service.state.status !== FiefManagerStatuses.LOADED && <Loading />}

            {service.state.status === FiefManagerStatuses.LOADED && index === FiefManagerIndex.INFORMATION && service.state.fief !== null &&
                <Fragment>
                    <SideNav setIndex={setIndex} />
                    <Information 
                        fief={service.state.fief} 
                        fiefsList={service.state.fiefsList}
                        roadsList={service.state.roadsList}
                        inheritancesList={service.state.inheritancesList}/>
                </Fragment>
            }

            {service.state.status === FiefManagerStatuses.LOADED && index === FiefManagerIndex.STEWARDS &&
            <Fragment>
                <SideNav setIndex={setIndex} />
                <Stewards 
                    gameSessionId={service.state.gameSessionId}
                    stewards={service.state.stewards}
                    industries={service.state.industries}/>
            </Fragment>}
        </Fragment>
    )
}

export default FiefManager;
