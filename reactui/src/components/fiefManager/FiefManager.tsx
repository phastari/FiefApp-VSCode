import React, { Fragment, useState, useEffect } from 'react';
import SideNav from './sideNav/SideNav';
import { FiefManagerIndex } from './types';
import Information from './information/Information';
import { RouteComponentProps } from '@reach/router';
import Stewards from './stewards/stewards/Stewards';
import useFiefManagerService from '../../services/useFiefManagerService/useFiefManagerService';
import { FiefManagerStatuses, FiefManagerActionTypes } from '../../services/useFiefManagerService/types';
import Loading from '../loading/Loading';
import { createFief, createSteward, deleteFief } from './actions';
import './fiefmanager.scss';

const FiefManager: React.FC<RouteComponentProps> = (_: RouteComponentProps) => {
    const [index, setIndex] = useState(FiefManagerIndex.INFORMATION);
    const [reload, setReload] = useState(0);
    const service = useFiefManagerService();

    const handleSelectionChange = async (fiefId: string) => {
        service.state.fiefId = fiefId;
        service.dispatch({ type: FiefManagerActionTypes.FIEFMANAGER_LOAD_FIEF_REQUEST });
    }

    const handleInformationUpdate = async () => {
        //updateInformation()
    }

    const handleAddFief = async () => {
        let response = await createFief(service.state.gameSessionId);

        if (response !== null) {
            service.state.fief = response;
            service.state.fiefId = response.fiefId;
            service.state.fiefsList.push({ fiefId: response.fiefId, name: response.name });
            setReload(reload + 1);
        }
    }

    const handleDeleteFief = async () => {
        if (service.state.fief !== null) {
            deleteFief(service.state.fiefId);
            let index = service.state.fiefsList.map(x => {
                return x.fiefId;
            }).indexOf(service.state.fiefId);
            service.state.fiefsList.splice(index, 1);
            let len = service.state.fiefsList.length;
            if (len === index) {
                service.state.fiefId = service.state.fiefsList[len - 1].fiefId;
            } else if (index === 0) {
                service.state.fiefId = service.state.fiefsList[0].fiefId;
            } else {
                service.state.fiefId = service.state.fiefsList[index].fiefId;
            }
            service.dispatch({ type: FiefManagerActionTypes.FIEFMANAGER_LOAD_FIEF_REQUEST });
        }
    }

    const handleAddSteward = async () => {
        let response = await createSteward(service.state.gameSessionId);

        if (response !== null) {
            service.state.stewards.push(response);
            setReload(reload + 1);
        }
    }

    useEffect(() => {
        if (service.state.status === FiefManagerStatuses.INITIAL) {
            service.dispatch({ type: FiefManagerActionTypes.FIEFMANAGER_REQUEST_INITIALIZE });
        }
    }, [service, reload])
    
    return (
        <div className='fiefmanager-container'>
            {service.state.status !== FiefManagerStatuses.LOADED && <Loading />}

            {service.state.status === FiefManagerStatuses.LOADED && index === FiefManagerIndex.INFORMATION && service.state.fief !== null &&
                <Fragment>
                    <SideNav setIndex={setIndex} />
                    <Information 
                        handleSelectionChange={handleSelectionChange}
                        handleAddFief={handleAddFief}
                        handleDeleteFief={handleDeleteFief}
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
                    handleAddSteward={handleAddSteward}
                    gameSessionId={service.state.gameSessionId}
                    stewards={service.state.stewards}
                    industries={service.state.industries}/>
            </Fragment>}
        </div>
    )
}

export default FiefManager;
