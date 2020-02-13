import React, { Fragment } from 'react';
import { Row, Col, Button } from 'reactstrap';
import { ISteward } from '../../../../common/models/steward';

const Steward: React.FC<ISteward> = (props) => {
    return (
        <Fragment>
            <Row>
                <Col>{ props.name }</Col>
                <Col>{ props.age }</Col>
                <Col>{ props.skill }</Col>
                <Col>{ props.loyalty }</Col>
                <Col>{ props.resources }</Col>
                <Col>
                    <Button size='sm'>tabort</Button>
                </Col>
            </Row>
        </Fragment>
    )
}

export default Steward;
