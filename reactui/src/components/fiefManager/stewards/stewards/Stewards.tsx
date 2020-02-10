import React, { Fragment } from 'react';
import Steward from '../steward/Steward';
import useStewardsService from '../../../../services/useStewardsService/useStewardsService';
import Loading from '../../../loading/Loading';

const Stewards: React.FC = () => {
    const service = useStewardsService();

    return (
        <Fragment>
            {service.status === 'loading' && <Loading />}

            {service.status === 'error' && (
                <div>Error!</div>
            )}

            {service.status === 'loaded' && service.payload.map((steward) => {
                return (
                    <Steward
                        stewardId={steward.stewardId}
                        name={steward.name}
                        age={steward.age}
                        skill={steward.skill}
                        loyalty={steward.loyalty}
                        resources={steward.resources}
                        assignmentId={steward.assignmentId}
                    />
                )
            })}
        </Fragment>
    )
}

export default Stewards;
