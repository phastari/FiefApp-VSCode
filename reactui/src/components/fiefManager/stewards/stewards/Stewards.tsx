import React, { Fragment } from 'react';
import Steward from '../steward/Steward';
import { ISteward } from '../types';

const GameSessions: React.FC = () => {
    let stewards = [
        {
            stewardId: '35b1c5e1-b266-4242-be07-5485d425a8d8',
            name: 'Pelle Svanslös',
            age: 25,
            skill: 12,
            loyalty: 12,
            resources: 12,
            assignmentId: ''
        } as ISteward,
        {
            stewardId: 'b381a10d-7dc9-4047-bb46-f8348614828f',
            name: 'Mila Torsdottir',
            age: 35,
            skill: 13,
            loyalty: 12,
            resources: 11,
            assignmentId: ''
        } as ISteward,
        {
            stewardId: '5d85244b-0b35-4c2e-8659-535838bf6847',
            name: 'Moja Sunesson',
            age: 41,
            skill: 11,
            loyalty: 12,
            resources: 13,
            assignmentId: ''
        } as ISteward,
        {
            stewardId: '5d85244b-0b35-4c2e-8659-535838bf6847',
            name: 'Knut Plutten',
            age: 51,
            skill: 10,
            loyalty: 10,
            resources: 10,
            assignmentId: ''
        } as ISteward
    ]
    return (
        <Fragment>
            {stewards.map((steward) => {
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

export default GameSessions;
