import React, { Fragment } from 'react';
import { Row, Col, Button } from 'reactstrap';
import './gamesession.css';

interface PropsFromState {
    gameSessionId: string;
    name: string;
    created: Date;
    lastUsed: Date;
}

type AllProps = PropsFromState & { handleDelete: any, selectSession: any };

const GameSession: React.FC<AllProps> = (props) => {
    return (
        <Fragment>
            <Row id='gamesessionrow' onClick={() => props.selectSession()}>
                <Col>{ props.name }</Col>
                <Col>{ props.created }</Col>
                <Col>{ props.lastUsed }</Col>
                <Col>
                    <Button size='sm' onClick={() => props.handleDelete()}>tabort</Button>
                </Col>
            </Row>
        </Fragment>
    )
}

export default GameSession;
