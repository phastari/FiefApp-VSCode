import React, { Fragment, useEffect } from 'react';
import useFiefManagerService from '../../../services/useFiefManagerService/useFiefManagerService';
import { FiefManagerStatuses, FiefManagerActionTypes } from '../../../services/useFiefManagerService/types';
import Loading from '../../loading/Loading';
import { Col, Toast, ToastHeader, ToastBody, Form, FormGroup, Label, Input, Row } from 'reactstrap';
import { RouteComponentProps } from '@reach/router';

const Information: React.FC<RouteComponentProps> = (_: RouteComponentProps) => {
    const service = useFiefManagerService();

    useEffect(() => {
        if (service.state.status === FiefManagerStatuses.INITIALIZED && service.state.fiefId !== '') {
            service.dispatch({ type: FiefManagerActionTypes.FIEFMANAGER_LOAD_FIEF_REQUEST, id: service.state.fiefId });
        } else if (service.state.status === FiefManagerStatuses.INITIALIZING && service.state.gameSessionId !== '') {
            service.dispatch({ type: FiefManagerActionTypes.FIEFMANAGER_REQUEST_INITIALIZE })
        }
    }, [service])

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
                                    <Label for='fiefSelect' sm={4} style={{ textAlign: 'right'}}>Förläning</Label>
                                    <Col sm={8}>
                                        <Input type='select' name='fiefInput' id='fiefSelect'>
                                            {service.state.fiefs.map(fief => 
                                                <option key={fief.fiefId}>{fief.name}</option>
                                            )}
                                        </Input>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for='fiefType' sm={4} style={{ textAlign: 'right'}}>Typ</Label>
                                    <Col sm={8}>
                                        <Input type='text' name='typeInput' id='fiefType' value={service.state.fief.inheritance.type}/>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for='fiefTypeDescription' sm={4} style={{ textAlign: 'right'}}>Beskrivning</Label>
                                    <Col sm={8}>
                                        <Input type='textarea' name='typeDescription' id='fiefTypeDescription' value={service.state.fief.inheritance.description}/>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for='fiefRoad' sm={4} style={{ textAlign: 'right'}}>Vägnät</Label>
                                    <Col sm={8}>
                                        <Input type='text' name='roadInput' id='fiefRoad' value={service.state.fief.road.type}/>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for='fiefAcres' sm={8} style={{ textAlign: 'right'}}>Tunnland</Label>
                                    <Col sm={4}>
                                        <Input type='text' name='acresInput' id='fiefAcres' value={service.state.fief.acres}/>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for='fiefWoodland' sm={8} style={{ textAlign: 'right'}}>Skogsmark</Label>
                                    <Col sm={4}>
                                        <Input type='text' name='woodlandInput' id='fiefWoodland' value={service.state.fief.woodlandAcres}/>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for='fiefFelling' sm={8} style={{ textAlign: 'right'}}>Avverkat</Label>
                                    <Col sm={4}>
                                        <Input type='text' name='fellingInput' id='fiefFelling' value={service.state.fief.fellingAcres}/>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for='fiefUnusable' sm={8} style={{ textAlign: 'right'}}>Oanvändbar</Label>
                                    <Col sm={4}>
                                        <Input type='text' name='unusableInput' id='fiefUnusable' value={service.state.fief.unusableAcres}/>
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
                                <Row>
                                    <Col sm={6} style={{ textAlign: 'right', paddingRight: '40px'}}>Näring</Col>
                                    <Col sm={3} style={{ textAlign: 'center' }}>Kvalitet</Col>
                                    <Col sm={3} style={{ textAlign: 'center' }}>UN</Col>
                                </Row>
                                <Form>
                                <FormGroup row>
                                    <Label for='qualityAnimalHusbandry' sm={6} style={{ textAlign: 'right' }}>Djurhållning</Label>
                                    <Col sm={3}>
                                        <Input type='text' name='animalHusbandryQ' id='qualityAnimalHusbandry' value={service.state.fief.animalHusbandryQuality}/>
                                    </Col>
                                    <Col sm={3}>
                                        <Input type='text' name='animalHusbandryDL' id='dlAnimalHusbandry' value={service.state.fief.animalHusbandryDevelopmentLevel}/>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for='qualityAgricultural' sm={6} style={{ textAlign: 'right' }}>Jordbruk</Label>
                                    <Col sm={3}>
                                        <Input type='text' name='agriculturalQ' id='qualityAgricultural' value={service.state.fief.agriculturalQuality}/>
                                    </Col>
                                    <Col sm={3}>
                                        <Input type='text' name='agriculturalDL' id='dlAgricultural' value={service.state.fief.agriculturalDevelopmentLevel}/>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for='qualityFishing' sm={6} style={{ textAlign: 'right' }}>Fiske</Label>
                                    <Col sm={3}>
                                        <Input type='text' name='fishingQ' id='qualityFishing' value={service.state.fief.fishingQuality}/>
                                    </Col>
                                    <Col sm={3}>
                                        <Input type='text' name='fishingDL' id='dlFishing' value={service.state.fief.fishingDevelopmentLevel}/>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for='qualityOre' sm={6} style={{ textAlign: 'right' }}>Malm</Label>
                                    <Col sm={3}>
                                        <Input type='text' name='oreQ' id='qualityOre' value={service.state.fief.oreQuality}/>
                                    </Col>
                                    <Col sm={3}>
                                        <Input type='text' name='oreDL' id='dlOre' value={service.state.fief.oreDevelopmentLevel}/>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for='dlEducation' sm={9} style={{ textAlign: 'right' }}>Utbildning</Label>
                                    <Col sm={3}>
                                        <Input type='text' name='educationDL' id='dlEducation' value={service.state.fief.educationDevelopmentLevel}/>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for='dlMilitary' sm={9} style={{ textAlign: 'right' }}>Militär</Label>
                                    <Col sm={3}>
                                        <Input type='text' name='militaryDL' id='dlMilitary' value={service.state.fief.militaryDevelopmentLevel}/>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for='dlHealth' sm={9} style={{ textAlign: 'right' }}>Medicin</Label>
                                    <Col sm={3}>
                                        <Input type='text' name='healthDL' id='dlHealth' value={service.state.fief.healthcareDevelopmentLevel}/>
                                    </Col>
                                </FormGroup>
                                <FormGroup row>
                                    <Label for='dlSeafaring' sm={9} style={{ textAlign: 'right' }}>Sjöfart</Label>
                                    <Col sm={3}>
                                        <Input type='text' name='seafaringDL' id='dlSeafaring' value={service.state.fief.seafaringDevelopmentLevel}/>
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