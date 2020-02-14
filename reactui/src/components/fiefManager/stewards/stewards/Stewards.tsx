import React, { Fragment, FC } from 'react';
import Steward from '../steward/Steward';
import { ISteward } from '../../../../common/models/steward';
import { IIndustry } from '../../../../common/models/industry';
import { Button } from 'reactstrap';

interface PropsFromFiefManager {
    gameSessionId: string;
    stewards: ISteward[];
    industries: IIndustry[];
}

type AllProps = PropsFromFiefManager & { handleAddSteward: any };

const Stewards: FC<AllProps> = (props) => {
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
        <Button onClick={() => props.handleAddSteward()}>Lägg till</Button>
        </Fragment>
    )
}

export default Stewards;
