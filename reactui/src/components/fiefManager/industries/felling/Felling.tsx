import React, { Fragment } from 'react';
import { Row, Col, Button } from 'reactstrap';
import { IIndustry } from '../../../../services/useIndustriesService/types';

const Felling: React.FC<IIndustry> = (props) => {
    return (
        <Fragment>
            <Row>
                <Col>{ props.name }</Col>
                <Col>
                    <Button size='sm'>tabort</Button>
                </Col>
                <Col>{ props.amountLandclearing }</Col>
                <Col>{ props.amountLandclearingOfFelling }</Col>
                <Col>{ props.amountFelling }</Col>
                <Col>{ props.amountClearUseless }</Col>
                <Col>
                    {props.isBeingDeveloped && <div>Utvecklas</div>}
                </Col>
            </Row>
        </Fragment>
    )
}

export default Felling;
