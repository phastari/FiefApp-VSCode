import React, { Fragment } from 'react';
import { Row, Col, Button } from 'reactstrap';
import { IIndustry } from '../../../../services/useIndustriesService/types';
import Felling from '../felling/Felling';

const Industry: React.FC<IIndustry> = (props) => {
    return (
        <Fragment>
            <Row>
                <Col>{ props.name }</Col>
                <Col>
                    <Button size='sm'>tabort</Button>
                </Col>
                <Col>
                {props.type === 'Felling' && 
                    <Felling
                        industryId={props.industryId}
                        name={props.name}
                        type={props.type}
                        amountLandclearing={props.amountLandclearing}
                        amountLandclearingOfFelling={props.amountLandclearingOfFelling}
                        amountFelling={props.amountFelling}
                        amountClearUseless={props.amountClearUseless}
                        isBeingDeveloped={props.isBeingDeveloped} />
                }
                </Col>
            </Row>
        </Fragment>
    )
}

export default Industry;
