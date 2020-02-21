import React from 'react';
import { IShortFief, IShortRoad, IShortInheritance } from '../../../services/useFiefManagerService/types';
import { IFief } from '../../../common/models/fief';
import FiefSelector from '../../common/fiefSelector/FiefSelector';
import './information.scss';
import { Card, CardTitle } from 'reactstrap';
import ListSelector from '../../common/listSelector/ListSelector';
import TextArea from '../../common/textArea/TextArea';
import TextBox from '../../common/textBox/TextBox';

interface PropsFromFiefManager {
    fief: IFief;
    fiefsList: IShortFief[];
    roadsList: IShortRoad[];
    inheritancesList: IShortInheritance[];
}

type AllProps = PropsFromFiefManager & { handleAddFief: any, handleDeleteFief: any, handleSelectionChange: any };

const Information: React.FC<AllProps> = (props) => {
    
    const convertInheritanceList = () => {
        let array: { id: number, value: string }[] = [];
        props.inheritancesList.map(inheritance => {
            array.push({ id: parseInt(inheritance.inheritanceId), value: inheritance.type });
        })

        return array;
    }

    const convertRoadsList = () => {
        let array: { id: number, value: string }[] = [];
        props.roadsList.map(road => {
            array.push({ id: parseInt(road.roadId), value: road.type });
        })

        return array;
    }

    return (
            <div className='information-container'>
                <div className='information-box'>
                    <Card className='information-card'>
                        <CardTitle className='vinque'>Information</CardTitle>
                        <FiefSelector
                            fiefsList={props.fiefsList}
                            selectedFief={props.fief.name}/>

                        <ListSelector
                            list={convertInheritanceList()}
                            name={'Arvstyp'}
                            value={props.fief.inheritance.type}
                            canEdit={true}/>

                        <TextArea
                            name={'Beskrivning'}
                            value={props.fief.inheritance.description}
                            canEdit={false}
                            rows={5}/>

                        <TextBox
                            name={'Tunnland'}
                            value={props.fief.acres.toString()}
                            canEdit={false}
                            showLabel={true}/>

                        <TextBox
                            name={'Betesmark'}
                            value={props.fief.pastureAcres.toString()}
                            canEdit={false}
                            showLabel={true}/>

                        <TextBox
                            name={'Åkermark'}
                            value={props.fief.farmlandAcres.toString()}
                            canEdit={false}
                            showLabel={true}/>

                        <TextBox
                            name={'Skogsmark'}
                            value={props.fief.woodlandAcres.toString()}
                            canEdit={false}
                            showLabel={true}/>

                        <TextBox
                            name={'Avverkad skogsmark'}
                            value={props.fief.fellingAcres.toString()}
                            canEdit={false}
                            showLabel={true}/>

                        <TextBox
                            name={'Obrukbarmark'}
                            value={props.fief.unusableAcres.toString()}
                            canEdit={false}
                            showLabel={true}/>

                        <ListSelector
                            list={convertRoadsList()}
                            name={'Vägnät'}
                            value={props.fief.road.type}
                            canEdit={true}/>
                        </Card>
                </div>
            </div>
    )
}

export default Information;