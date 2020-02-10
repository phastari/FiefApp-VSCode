import React, { Fragment } from 'react';
import useFiefManagerService from '../../../services/useFiefManagerService/useFiefManagerService';
import { FiefManagerStatuses } from '../../../services/useFiefManagerService/types';
import Loading from '../../loading/Loading';
import { Row, Col } from 'reactstrap';
import { RouteComponentProps } from '@reach/router';

const Information: React.FC<RouteComponentProps> = (_: RouteComponentProps) => {
    const service = useFiefManagerService();

    return (
        <Fragment>
            {service.status === FiefManagerStatuses.LOADING && <Loading />}

            {service.status === FiefManagerStatuses.ERROR && (
                <div>{service.errors}</div>
            )}

            {service.status === FiefManagerStatuses.LOADED && service.fief !== undefined && (
                <Fragment>
                    <Row>
                        <Col>Förläning:</Col>
                        <Col>{service.fief.name}</Col>
                        <Col>Näring</Col>
                        <Col>Kvalitet</Col>
                    </Row>
                    <Row>
                        <Col>Typ:</Col>
                        <Col>{service.fief.inheritance.type}</Col>
                        <Col>Jordbruk</Col>
                        <Col>{service.fief.agriculturalQuality}</Col>
                    </Row>
                    <Row>
                        <Col>Vägar:</Col>
                        <Col>{service.fief.road.type}</Col>
                        <Col>Djurhållning</Col>
                        <Col>{service.fief.animalHusbandryQuality}</Col>
                    </Row>
                </Fragment>
            )}
        </Fragment>
    )
}

export default Information;