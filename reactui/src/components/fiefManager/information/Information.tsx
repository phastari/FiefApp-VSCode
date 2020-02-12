import React, { Fragment, useEffect, ChangeEvent, useState } from 'react';
import useFiefManagerService from '../../../services/useFiefManagerService/useFiefManagerService';
import { FiefManagerStatuses, FiefManagerActionTypes } from '../../../services/useFiefManagerService/types';
import Loading from '../../loading/Loading';
import { Col, Toast, ToastHeader, ToastBody, Form, FormGroup, Label, Input, Row } from 'reactstrap';
import { RouteComponentProps } from '@reach/router';
import { tryParseInt } from '../../../common/utilities/tryParseInt';

const Information: React.FC<RouteComponentProps> = (_: RouteComponentProps) => {
    const service = useFiefManagerService();
    const [changed, setChanged] = useState(false);
    const [inheritanceDescription, setInheritanceDescription] = useState(service.state.fief?.inheritance.description);
    const [animalHusbandryQ, setAnimalHusbandryQ] = useState(service.state.fief?.animalHusbandryQuality);
    const [animalHusbandryDL, setAnimalHusbandryDL] = useState(service.state.fief?.animalHusbandryDevelopmentLevel);
    const [agriculturalQ, setAgriculturalQ] = useState(service.state.fief?.agriculturalQuality);
    const [agriculturalDL, setAgriculturalDL] = useState(service.state.fief?.agriculturalDevelopmentLevel);
    const [fishingQ, setFishingQ] = useState(service.state.fief?.fishingQuality);
    const [fishingDL, setFishingDL] = useState(service.state.fief?.fishingDevelopmentLevel);
    const [oreQ, setOreQ] = useState(service.state.fief?.oreQuality);
    const [oreDL, setOreDL] = useState(service.state.fief?.oreDevelopmentLevel);
    const [educationDL, setEducationDL] = useState(service.state.fief?.educationDevelopmentLevel);
    const [militaryDL, setMilitaryDL] = useState(service.state.fief?.militaryDevelopmentLevel);
    const [healthDL, setHealthDL] = useState(service.state.fief?.healthcareDevelopmentLevel);
    const [seafaringDL, setSeafaringDL] = useState(service.state.fief?.seafaringDevelopmentLevel);

    const fiefSelectionChanged = (e: ChangeEvent<HTMLInputElement>) => {
        console.log(e.target.value);
    }

    const fiefTypeChanged = (e: ChangeEvent<HTMLInputElement>) => {
        service.state.inheritancesList.forEach(inheritance => {
            if (inheritance.type === e.target.value) {
                if (service.state.fief !== null) {
                    service.state.fief.inheritance.description = inheritance.description;
                    setChanged(true);
                    setInheritanceDescription(inheritance.description)
                }
            }
        })
    }

    const animalHusbandryQChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (service.state.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                service.state.fief.animalHusbandryQuality = newValue;
                setChanged(true);
                setAnimalHusbandryQ(newValue);
            }
        }
    }

    const animalHsbandryDLChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (service.state.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                service.state.fief.animalHusbandryDevelopmentLevel = newValue;
                setChanged(true);
                setAnimalHusbandryDL(newValue);
            }
        }
    }

    const agriculturalQChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (service.state.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                service.state.fief.agriculturalQuality = newValue;
                setChanged(true);
                setAgriculturalQ(newValue);
            }
        }
    }

    const agriculturalDLChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (service.state.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                service.state.fief.agriculturalDevelopmentLevel = newValue;
                setChanged(true);
                setAgriculturalDL(newValue);
            }
        }
    }

    const fishingQChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (service.state.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                service.state.fief.fishingQuality = newValue;
                setChanged(true);
                setFishingQ(newValue);
            }
        }
    }

    const fishingDLChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (service.state.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                service.state.fief.fishingDevelopmentLevel = newValue;
                setChanged(true);
                setFishingDL(newValue);
            }
        }
    }

    const oreQChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (service.state.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                service.state.fief.oreQuality = newValue;
                setChanged(true);
                setOreQ(newValue);
            }
        }
    }

    const oreDLChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (service.state.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                service.state.fief.oreDevelopmentLevel = newValue;
                setChanged(true);
                setOreDL(newValue);
            }
        }
    }

    const educationDLChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (service.state.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                service.state.fief.educationDevelopmentLevel = newValue;
                setChanged(true);
                setEducationDL(newValue);
            }
        }
    }

    const militaryDLChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (service.state.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                service.state.fief.militaryDevelopmentLevel = newValue;
                setChanged(true);
                setMilitaryDL(newValue);
            }
        }
    }

    const healthDLChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (service.state.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                service.state.fief.healthcareDevelopmentLevel = newValue;
                setChanged(true);
                setHealthDL(newValue);
            }
        }
    }

    const seafaringDLChanged = (e: ChangeEvent<HTMLInputElement>) => {
        if (service.state.fief !== null) {
            let newValue = tryParseInt(e.target.value);
            if (newValue != null) {
                service.state.fief.seafaringDevelopmentLevel = newValue;
                setChanged(true);
                setSeafaringDL(newValue);
            }
        }
    }

    useEffect(() => {
        if (service.state.status === FiefManagerStatuses.INITIALIZED && service.state.fiefId !== '') {
            service.dispatch({ type: FiefManagerActionTypes.FIEFMANAGER_LOAD_FIEF_REQUEST, id: service.state.fiefId });
        } else if (service.state.status === FiefManagerStatuses.INITIALIZING && service.state.gameSessionId !== '') {
            service.dispatch({ type: FiefManagerActionTypes.FIEFMANAGER_REQUEST_INITIALIZE })
        }

        
    }, [service, changed, inheritanceDescription, animalHusbandryQ, animalHusbandryDL, agriculturalQ, agriculturalDL, fishingQ, fishingDL, oreQ, oreDL, educationDL, militaryDL, healthDL, seafaringDL])

    return (
        <Fragment>
            {service.state.status === FiefManagerStatuses.LOADING && <Loading />}

            {service.state.status === FiefManagerStatuses.ERROR && (
                <div>{service.state.errors}</div>
            )}

            {service.state.status === FiefManagerStatuses.LOADED && service.state.fief !== null && (
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
                                            onChange={(e) => fiefSelectionChanged(e)}>
                                        {service.state.fiefsList.map(fief => {
                                            return <option key={fief.fiefId} value={fief.name}>{fief.name}</option>;
                                        })}
                                        </Input>
                                    </Col>
                                </FormGroup>
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
                                        {service.state.inheritancesList.map(inheritance => {
                                            return <option key={inheritance.inheritanceId} value={inheritance.type}>{inheritance.type}</option>;
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
                                            value={service.state.fief.road.type} 
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
                                            value={service.state.fief.acres} 
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
                                            value={service.state.fief.woodlandAcres} 
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
                                            value={service.state.fief.fellingAcres} 
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
                                            value={service.state.fief.unusableAcres} 
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
            )}
        </Fragment>
    )
}

export default Information;