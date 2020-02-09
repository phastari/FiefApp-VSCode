import React, { Fragment } from 'react';
import { Row, Col, Button } from 'reactstrap';

interface PropsFromState {
    gameSessionId: string;
    name: string;
    created: Date;
    lastUsed: Date;
}

type AllProps = PropsFromState & { handleDelete: any };

const GameSession: React.FC<AllProps> = (props) => {
    return (
        <Fragment>
            <Row>
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
