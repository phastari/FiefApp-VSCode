import React, { Fragment, useEffect } from 'react';
import useFiefManagerService from '../../../services/useFiefManagerService/useFiefManagerService';
import { FiefManagerStatuses, FiefManagerActionTypes } from '../../../services/useFiefManagerService/types';
import Loading from '../../loading/Loading';
import { Row, Col } from 'reactstrap';
import { RouteComponentProps } from '@reach/router';

const Information: React.FC<RouteComponentProps> = (_: RouteComponentProps) => {
    const service = useFiefManagerService();

    useEffect(() => {
        if (service.state.status === FiefManagerStatuses.INITILIZING && service.state.fiefId === '' && service.state.gameSessionId !== '') {
            service.dispatch({ type: FiefManagerActionTypes.FIEFMANAGER_LOAD_FIEF_REQUEST, id: service.state.gameSessionId });
        }
    }, [service])

    return (
        <Fragment>
            {service.state.status === FiefManagerStatuses.LOADING && <Loading />}

            {service.state.status === FiefManagerStatuses.ERROR && (
                <div>{service.state.errors}</div>
            )}

            {service.state.status === FiefManagerStatuses.LOADED && service.state.fief !== null && (
                <Fragment>
                    <Row>
                        <Col>Förläning:</Col>
                        <Col>{service.state.fief.name}</Col>
                        <Col>Näring</Col>
                        <Col>Kvalitet</Col>
                    </Row>
                    <Row>
                        <Col>Typ:</Col>
                        <Col>{service.state.fief.inheritance}</Col>
                        <Col>Jordbruk</Col>
                        <Col>{service.state.fief.agriculturalQuality}</Col>
                    </Row>
                    <Row>
                        <Col>Vägar:</Col>
                        <Col>{service.state.fief.road}</Col>
                        <Col>Djurhållning</Col>
                        <Col>{service.state.fief.animalHusbandryQuality}</Col>
                    </Row>
                </Fragment>
            )}
        </Fragment>
    )
}

export default Information;