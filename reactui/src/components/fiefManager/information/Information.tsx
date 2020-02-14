import React, { Fragment, ChangeEvent, useState } from 'react';
import { IShortFief, IShortRoad, IShortInheritance } from '../../../services/useFiefManagerService/types';
import { Col, Toast, ToastHeader, ToastBody, Form, FormGroup, Label, Input, Row, Button } from 'reactstrap';
import { tryParseInt } from '../../../common/utilities/tryParseInt';
import { IFief } from '../../../common/models/fief';

interface PropsFromFiefManager {
    fief: IFief;
    fiefsList: IShortFief[];
    roadsList: IShortRoad[];
    inheritancesList: IShortInheritance[];
}

type AllProps = PropsFromFiefManager & { handleAddFief: any, handleDeleteFief: any, handleSelectionChange: any };

const Information: React.FC<AllProps> = (props) => {
    const [changed, setChanged] = useState(false);
    const [inheritanceDescription, setInheritanceDescription] = useState(props.fief.inheritance.description);
    const [animalHusbandryQ, setAnimalHusbandryQ] = useState(props.fief.animalHusbandryQuality);
    const [animalHusbandryDL, setAnimalHusbandryDL] = useState(props.fief.animalHusbandryDevelopmentLevel);
    const [agriculturalQ, setAgriculturalQ] = useState(props.fief.agriculturalQuality);
    const [agriculturalDL, setAgriculturalDL] = useState(props.fief.agriculturalDevelopmentLevel);
    const [fishingQ, setFishingQ] = useState(props.fief.fishingQuality);
    const [fishingDL, setFishingDL] = useState(props.fief.fishingDevelopmentLevel);
    const [oreQ, setOreQ] = useState(props.fief.oreQuality);
    const [oreDL, setOreDL] = useState(props.fief.oreDevelopmentLevel);
    const [educationDL, setEducationDL] = useState(props.fief.educationDevelopmentLevel);
    const [militaryDL, setMilitaryDL] = useState(props.fief.militaryDevelopmentLevel);
    const [healthDL, setHealthDL] = useState(props.fief.healthcareDevelopmentLevel);
    const [seafaringDL, setSeafaringDL] = useState(props.fief.seafaringDevelopmentLevel);

    const fiefTypeChanged = (e: ChangeEvent<HTMLInputElement>) => {
        props.inheritancesList.forEach(inheritance => {
            if (inheritance.type === e.target.value) {
                if (props.fief !== null) {
                    props.fief.inheritance.description = inheritance.description;
                    if (!changed) {
                        setChanged(true);
                    }
                    setInheritanceDescription(inheritance.description)
                }
            }
        })
    }

    const animalHusbandryQChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (props.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                props.fief.animalHusbandryQuality = newValue;
                if (!changed) {
                    setChanged(true);
                }
                setAnimalHusbandryQ(newValue);
            }
        }
    }

    const animalHsbandryDLChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (props.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                props.fief.animalHusbandryDevelopmentLevel = newValue;
                if (!changed) {
                    setChanged(true);
                }
                setAnimalHusbandryDL(newValue);
            }
        }
    }

    const agriculturalQChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (props.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                props.fief.agriculturalQuality = newValue;
                if (!changed) {
                    setChanged(true);
                }
                setAgriculturalQ(newValue);
            }
        }
    }

    const agriculturalDLChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (props.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                props.fief.agriculturalDevelopmentLevel = newValue;
                if (!changed) {
                    setChanged(true);
                }
                setAgriculturalDL(newValue);
            }
        }
    }

    const fishingQChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (props.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                props.fief.fishingQuality = newValue;
                if (!changed) {
                    setChanged(true);
                }
                setFishingQ(newValue);
            }
        }
    }

    const fishingDLChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (props.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                props.fief.fishingDevelopmentLevel = newValue;
                if (!changed) {
                    setChanged(true);
                }
                setFishingDL(newValue);
            }
        }
    }

    const oreQChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (props.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                props.fief.oreQuality = newValue;
                if (!changed) {
                    setChanged(true);
                }
                setOreQ(newValue);
            }
        }
    }

    const oreDLChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (props.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                props.fief.oreDevelopmentLevel = newValue;
                if (!changed) {
                    setChanged(true);
                }
                setOreDL(newValue);
            }
        }
    }

    const educationDLChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (props.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                props.fief.educationDevelopmentLevel = newValue;
                if (!changed) {
                    setChanged(true);
                }
                setEducationDL(newValue);
            }
        }
    }

    const militaryDLChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (props.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                props.fief.militaryDevelopmentLevel = newValue;
                if (!changed) {
                    setChanged(true);
                }
                setMilitaryDL(newValue);
            }
        }
    }

    const healthDLChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (props.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                props.fief.healthcareDevelopmentLevel = newValue;
                if (!changed) {
                    setChanged(true);
                }
                setHealthDL(newValue);
            }
        }
    }

    const seafaringDLChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (props.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                props.fief.seafaringDevelopmentLevel = newValue;
                if (!changed) {
                    setChanged(true);
                }
                setSeafaringDL(newValue);
            }
        }
    }

    return (
            <Fragment>
                <Row>
                <Col>
                <Toast style={{marginLeft: '20px'}}>
                    <ToastHeader>Information</ToastHeader>
                    <ToastBody>
                        <Form>
                            <FormGroup row>
                                <Label 
                                    for='fiefSelect' 
                                    sm={4} 
                                    style={{ textAlign: 'right'}}>
                                Förläning
                                </Label>
                                <Col sm={8}>
                                    <Input 
                                        type='select' 
                                        name='fiefInput' 
                                        id='fiefSelect' 
                                        value={props.fief.fiefId}
                                        onChange={(e) => props.handleSelectionChange(e.target.value)}>
                                    {props.fiefsList.map(fief => {
                                        return <option key={fief.fiefId} value={fief.fiefId}>{fief.name}</option>;
                                    })}
                                    </Input>
                                </Col>
                            </FormGroup>
                            {props.fiefsList.length > 1 && <Button onClick={() => props.handleDeleteFief()}>Tabort förläning</Button>}
                            <Button onClick={() => props.handleAddFief()}>Lägg till förläning</Button>
                            <FormGroup row>
                                <Label 
                                    for='fiefType' 
                                    sm={4} 
                                    style={{ textAlign: 'right'}}>
                                Typ
                                </Label>
                                <Col sm={8}>
                                    <Input 
                                        type='select' 
                                        name='fiefInput' 
                                        id='fiefType' 
                                        onChange={(e) => fiefTypeChanged(e)}>
                                    {props.inheritancesList.map((inheritance, index) => {
                                        return <option key={index} value={inheritance.type}>{inheritance.type}</option>;
                                    })}
                                    </Input>
                                </Col>
                            </FormGroup>
                            <FormGroup row>
                                <Label 
                                    for='fiefTypeDescription' 
                                    sm={4} 
                                    style={{ textAlign: 'right'}}>
                                Beskrivning
                                </Label>
                                <Col sm={8}>
                                    <Input 
                                        type='textarea' 
                                        name='typeDescription' 
                                        id='fiefTypeDescription' 
                                        style={{height: '300px'}}
                                        value={inheritanceDescription}
                                        disabled/>
                                </Col>
                            </FormGroup>
                            <FormGroup row>
                                <Label 
                                    for='fiefRoad' 
                                    sm={4} 
                                    style={{ textAlign: 'right'}}>
                                Vägnät
                                </Label>
                                <Col sm={8}>
                                    <Input 
                                        type='text' 
                                        name='roadInput' 
                                        id='fiefRoad' 
                                        value={props.fief.road.type} 
                                        disabled/>
                                </Col>
                            </FormGroup>
                            <FormGroup row>
                                <Label 
                                    for='fiefAcres' 
                                    sm={8} 
                                    style={{ textAlign: 'right'}}>
                                Tunnland
                                </Label>
                                <Col sm={4}>
                                    <Input 
                                        type='text' 
                                        name='acresInput' 
                                        id='fiefAcres' 
                                        style={{ textAlign: 'center'}} 
                                        value={props.fief.acres} 
                                        disabled/>
                                </Col>
                            </FormGroup>
                            <FormGroup row>
                                <Label 
                                    for='fiefWoodland' 
                                    sm={8} 
                                    style={{ textAlign: 'right'}}>
                                Skogsmark
                                </Label>
                                <Col sm={4}>
                                    <Input 
                                        type='text' 
                                        name='woodlandInput' 
                                        id='fiefWoodland' 
                                        style={{ textAlign: 'center'}} 
                                        value={props.fief.woodlandAcres} 
                                        disabled/>
                                </Col>
                            </FormGroup>
                            <FormGroup row>
                                <Label 
                                    for='fiefFelling' 
                                    sm={8} 
                                    style={{ textAlign: 'right'}}>
                                Avverkad skogsmark
                                </Label>
                                <Col sm={4}>
                                    <Input 
                                        type='text' 
                                        name='fellingInput' 
                                        id='fiefFelling' 
                                        style={{ textAlign: 'center'}} 
                                        value={props.fief.fellingAcres} 
                                        disabled/>
                                </Col>
                            </FormGroup>
                            <FormGroup row>
                                <Label 
                                    for='fiefUnusable' 
                                    sm={8} 
                                    style={{ textAlign: 'right'}}>
                                Oanvändbarmark
                                </Label>
                                <Col sm={4}>
                                    <Input 
                                        type='text' 
                                        name='unusableInput' 
                                        id='fiefUnusable' 
                                        style={{ textAlign: 'center'}} 
                                        value={props.fief.unusableAcres} 
                                        disabled/>
                                </Col>
                            </FormGroup>
                        </Form>
                    </ToastBody>
                </Toast>
                </Col>
                <Col>
                    <Toast>
                        <ToastHeader>Kvaliteter</ToastHeader>
                        <ToastBody>
                            <Row style={{ marginBottom: '10px', fontWeight: 'bold' }}>
                                <Col 
                                    sm={6} 
                                    style={{ textAlign: 'right', paddingRight: '40px'}}>
                                Näring
                                </Col>
                                <Col 
                                    sm={3} 
                                    style={{ textAlign: 'center' }}>
                                Kvalitet
                                </Col>
                                <Col 
                                    sm={3} 
                                    style={{ textAlign: 'center' }}>
                                UN
                                </Col>
                            </Row>
                            <Form>
                            <FormGroup row>
                                <Label 
                                    for='qualityAnimalHusbandry' 
                                        sm={6} style={{ textAlign: 'right' }}>
                                    Djurhållning
                                </Label>
                                <Col sm={3}>
                                    <Input 
                                        type='text' 
                                        name='animalHusbandryQ' 
                                        id='qualityAnimalHusbandry' 
                                        style={{ textAlign: 'center'}} 
                                        value={animalHusbandryQ}
                                        onChange={(e) => animalHusbandryQChanged(e)}/>
                                </Col>
                                <Col sm={3}>
                                    <Input 
                                        type='text' 
                                        name='animalHusbandryDL' 
                                        id='dlAnimalHusbandry' 
                                        style={{ textAlign: 'center'}} 
                                        value={animalHusbandryDL}
                                        onChange={(e) => animalHsbandryDLChanged(e)}/>
                                </Col>
                            </FormGroup>
                            <FormGroup row>
                                <Label 
                                    for='qualityAgricultural' 
                                    sm={6} style={{ textAlign: 'right' }}>
                                Jordbruk
                                </Label>
                                <Col sm={3}>
                                    <Input 
                                        type='text' 
                                        name='agriculturalQ' 
                                        id='qualityAgricultural' 
                                        style={{ textAlign: 'center'}} 
                                        value={agriculturalQ}
                                        onChange={(e) => agriculturalQChanged(e)}/>
                                </Col>
                                <Col sm={3}>
                                    <Input 
                                        type='text' 
                                        name='agriculturalDL' 
                                        id='dlAgricultural' 
                                        style={{ textAlign: 'center'}} 
                                        value={agriculturalDL}
                                        onChange={(e) => agriculturalDLChanged(e)}/>
                                </Col>
                            </FormGroup>
                            <FormGroup row>
                                <Label 
                                    for='qualityFishing' 
                                    sm={6} style={{ textAlign: 'right' }}>
                                Fiske
                                </Label>
                                <Col sm={3}>
                                    <Input 
                                        type='text' 
                                        name='fishingQ' 
                                        id='qualityFishing' 
                                        style={{ textAlign: 'center'}} 
                                        value={fishingQ}
                                        onChange={(e) => fishingQChanged(e)}/>
                                </Col>
                                <Col sm={3}>
                                    <Input 
                                        type='text' 
                                        name='fishingDL' 
                                        id='dlFishing' 
                                        style={{ textAlign: 'center'}} 
                                        value={fishingDL}
                                        onChange={(e) => fishingDLChanged(e)}/>
                                </Col>
                            </FormGroup>
                            <FormGroup row>
                                <Label 
                                    for='qualityOre' 
                                    sm={6} style={{ textAlign: 'right' }}>
                                Malm
                                </Label>
                                <Col sm={3}>
                                    <Input 
                                        type='text' 
                                        name='oreQ' 
                                        id='qualityOre' 
                                        style={{ textAlign: 'center'}} 
                                        value={oreQ}
                                        onChange={(e) => oreQChanged(e)}/>
                                </Col>
                                <Col sm={3}>
                                    <Input 
                                        type='text' 
                                        name='oreDL' 
                                        id='dlOre' 
                                        style={{ textAlign: 'center'}} 
                                        value={oreDL}
                                        onChange={(e) => oreDLChanged(e)}/>
                                </Col>
                            </FormGroup>
                            <FormGroup row>
                                <Label 
                                    for='dlEducation' 
                                    sm={9} 
                                    style={{ textAlign: 'right' }}>
                                Utbildning
                                </Label>
                                <Col sm={3}>
                                    <Input 
                                        type='text' 
                                        name='educationDL' 
                                        id='dlEducation' 
                                        style={{ textAlign: 'center'}} 
                                        value={educationDL}
                                        onChange={(e) => educationDLChanged(e)}/>
                                </Col>
                            </FormGroup>
                            <FormGroup row>
                                <Label 
                                    for='dlMilitary' 
                                    sm={9} 
                                    style={{ textAlign: 'right' }}>
                                Militär
                                </Label>
                                <Col sm={3}>
                                    <Input 
                                        type='text' 
                                        name='militaryDL' 
                                        id='dlMilitary' 
                                        style={{ textAlign: 'center'}} 
                                        value={militaryDL}
                                        onChange={(e) => militaryDLChanged(e)}/>
                                </Col>
                            </FormGroup>
                            <FormGroup row>
                                <Label 
                                    for='dlHealth' 
                                    sm={9} 
                                    style={{ textAlign: 'right' }}>
                                Medicin
                                </Label>
                                <Col sm={3}>
                                    <Input 
                                        type='text' 
                                        name='healthDL' 
                                        id='dlHealth' 
                                        style={{ textAlign: 'center'}} 
                                        value={healthDL}
                                        onChange={(e) => healthDLChanged(e)}/>
                                </Col>
                            </FormGroup>
                            <FormGroup row>
                                <Label 
                                    for='dlSeafaring' 
                                    sm={9} 
                                    style={{ textAlign: 'right' }}>
                                Sjöfart
                                </Label>
                                <Col sm={3}>
                                    <Input 
                                        type='text' 
                                        name='seafaringDL' 
                                        id='dlSeafaring' 
                                        style={{ textAlign: 'center'}} 
                                        value={seafaringDL}
                                        onChange={(e) => seafaringDLChanged(e)}/>
                                </Col>
                            </FormGroup>
                            </Form>
                        </ToastBody>
                    </Toast>
                </Col>
                <Col></Col>
                </Row>
            </Fragment>
    )
}

export default Information;