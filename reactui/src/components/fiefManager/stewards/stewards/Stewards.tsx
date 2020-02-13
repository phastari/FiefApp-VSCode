import React, { Fragment, FC, useState } from 'react';
import Steward from '../steward/Steward';
import { ISteward } from '../../../../common/models/steward';
import { IIndustry } from '../../../../common/models/industry';
import { Button } from 'reactstrap';
import { createSteward } from './actions';

interface PropsFromFiefManager {
    gameSessionId: string;
    stewards: ISteward[];
    industries: IIndustry[];
}

const Stewards: FC<PropsFromFiefManager> = (props) => {
    const [reload, setReload] = useState(0);

    const handleAddSteward = async () => {
        let steward = await createSteward(props.gameSessionId);
        props.stewards.push(steward);
        setReload(reload + 1);
    }

    return (
        <Fragment>
            {props.stewards.map((steward) => {
                return (
                    <Steward
                        key={steward.stewardId}
                        stewardId={steward.stewardId}
                        name={steward.name}
                        age={steward.age}
                        skill={steward.skill}
                        loyalty={steward.loyalty}
                        resources={steward.resources}
                        industryId={steward.industryId}
                        developmentId={steward.developmentId}
                        fiefId={steward.fiefId}
                        marketId={steward.marketId}
                        portId={steward.portId}
                        shipyardId={steward.shipyardId}
                    />
                )
            })}
        <Button onClick={() => handleAddSteward()}>Lägg till</Button>
        </Fragment>
    )
}

export default Stewards;
