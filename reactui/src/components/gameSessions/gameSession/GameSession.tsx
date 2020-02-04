import React, { Fragment } from 'react';
import { Row, Col, Button } from 'reactstrap';
import { IGameSession } from '../../../common/types/gamesession';

const GameSession: React.FC<IGameSession> = (props) => {
    return (
        <Fragment>
            <Row>
                <Col>{ props.name }</Col>
                <Col>
                    <Button size='sm'>tabort</Button>
                </Col>
            </Row>
        </Fragment>
    )
}

export default GameSession;
