import React, { useEffect, useState } from 'react';
import { Fief } from '../../common/models/Fief';
import { fetchFiefRequest } from '../../store/information/actions';
import { connect } from 'react-redux';
import { ApplicationState } from '../../store';
import { Container, Label, Input, Form } from 'reactstrap';
import { FetchFiefRequest } from '../../store/information/types';
import { setFiefId } from '../../store/fiefmanager/actions';

interface PropsFromState {
  fiefId: string;
  gameSessionId: string;
  fief: Fief;
  loading: boolean;
  errors?: string;
}

interface PropsFromDispatch {
  fetchFiefRequest: typeof fetchFiefRequest;
  setFiefId: typeof setFiefId;
}

type AllProps = PropsFromState & PropsFromDispatch;

const Information: React.FC<AllProps> = props => {
  const [name, setName] = useState('');
  const [acres, setAcres] = useState(0);
  const [farmlandAcres, setFarmlandAcres] = useState(0);
  const [pastureAcres, setPastureAcres] = useState(0);
  const [woodlandAcres, setWoodlandAcres] = useState(0);
  const [unusableAcres, setUnusableAcres] = useState(0);
  const [animalHusbandryQuality, setAnimalHusbandryQuality] = useState(0);
  const [agriculturalQuality, setAgriculturalQuality] = useState(0);
  const [fishingQuality, setFishingQuality] = useState(0);
  const [oreQuality, setOreQuality] = useState(0);
  const [
    animalHusbandryDevelopmentLevel,
    setAnimalHusbandryDevelopmentLevel
  ] = useState(0);
  const [
    agriculturalDevelopmentLevel,
    setAgriculturalDevelopmentLevel
  ] = useState(0);
  const [fishingDevelopmentLevel, setFishingDevelopmentLevel] = useState(0);
  const [woodlandDevelopmentLevel, setWoodlandDevelopmentLevel] = useState(0);
  const [oreDevelopmentLevel, setOreDevelopmentLevel] = useState(0);
  const [educationDevelopmentLevel, setEducationDevelopmentLevel] = useState(0);
  const [healthcareDevelopmentLevel, setHealthcareDevelopmentLevel] = useState(
    0
  );
  const [militaryDevelopmentLevel, setMilitaryDevelopmentLevel] = useState(0);
  const [seafaringDevelopmentLevel, setSearfaringDevelopmentLevel] = useState(
    0
  );
  const [road, setRoad] = useState('');
  const [livingcondition, setLivingcondition] = useState('');
  const [inheritance, setInheritance] = useState('');

  const [skipLoad, setSkipLoad] = useState(false);

  const { fetchFiefRequest, fiefId, gameSessionId } = props;

  useEffect(() => {
    let idObj: FetchFiefRequest;
    if (fiefId !== '' && skipLoad) {
      idObj = { Id: fiefId };
      setSkipLoad(true);
    } else {
      idObj = { Id: gameSessionId };
      setSkipLoad(true);
    }
    fetchFiefRequest(idObj);
  }, [fetchFiefRequest, fiefId, gameSessionId]);

  return (
    <Container>
      <Form>
        <Label for='name'>Förläning</Label>
        <Input
          type='text'
          name='name'
          placeholder='Förläning'
          value={name}
          onChange={e => setName(e.currentTarget.value)}
        />
        <Label for='acres'>Tunnland</Label>
        <Input
          type='text'
          name='acres'
          placeholder='Tunnland'
          value={acres}
          onChange={e => setAcres(+e.currentTarget.value)}
        />
        <Label for='pasture'>Tunnland för boskap</Label>
        <Input
          type='text'
          name='pasture'
          placeholder='Tunnland'
          value={pastureAcres}
          onChange={e => setPastureAcres(+e.currentTarget.value)}
        />
        <Label for='farmland'>Tunnland för jordbruk</Label>
        <Input
          type='text'
          name='farmland'
          placeholder='Tunnland'
          value={farmlandAcres}
          onChange={e => setFarmlandAcres(+e.currentTarget.value)}
        />
        <Label for='woodland'>Skogsmark</Label>
        <Input
          type='text'
          name='woodland'
          placeholder='Skogsmark'
          value={woodlandAcres}
          onChange={e => setWoodlandAcres(+e.currentTarget.value)}
        />
        <Label for='useless'>Oanvändbar</Label>
        <Input
          type='text'
          name='useless'
          placeholder='Oanvändbar'
          value={unusableAcres}
          onChange={e => setUnusableAcres(+e.currentTarget.value)}
        />
        <Label for='road'>Vägnät</Label>
        <Input
          type='text'
          name='road'
          placeholder='Vägnät'
          value={road}
          onChange={e => setRoad(e.currentTarget.value)}
        />
        <Label for='livingcondition'>Levnadsstandard</Label>
        <Input
          type='text'
          name='livingcondition'
          placeholder='Levnadsstandard'
          value={livingcondition}
          onChange={e => setLivingcondition(e.currentTarget.value)}
        />
        <Label for='type'>Länstyp</Label>
        <Input
          type='text'
          name='type'
          placeholder='Länstyp'
          value={inheritance}
          onChange={e => setInheritance(e.currentTarget.value)}
        />
        <Label for='animalHusbandryQ'>Djurhållning</Label>
        <Input
          type='text'
          name='animalHusbandryQ'
          placeholder='Kvalite'
          value={animalHusbandryQuality}
          onChange={e => setAnimalHusbandryQuality(+e.currentTarget.value)}
        />
        <Input
          type='text'
          name='animalHusbandryDL'
          placeholder='Utvecklingsnivå'
          value={animalHusbandryDevelopmentLevel}
          onChange={e =>
            setAnimalHusbandryDevelopmentLevel(+e.currentTarget.value)
          }
        />
        <Label for='agriculturalQ'>Jordbruk</Label>
        <Input
          type='text'
          name='agriculturalQ'
          placeholder='Kvalite'
          value={agriculturalQuality}
          onChange={e => setAgriculturalQuality(+e.currentTarget.value)}
        />
        <Input
          type='text'
          name='agriculturalDL'
          placeholder='Utvecklingsnivå'
          value={agriculturalDevelopmentLevel}
          onChange={e =>
            setAgriculturalDevelopmentLevel(+e.currentTarget.value)
          }
        />
        <Label for='fishingQ'>Fiske</Label>
        <Input
          type='text'
          name='fishingQ'
          placeholder='Kvalite'
          value={fishingQuality}
          onChange={e => setFishingQuality(+e.currentTarget.value)}
        />
        <Input
          type='text'
          name='fishingDL'
          placeholder='Utvecklingsnivå'
          value={fishingDevelopmentLevel}
          onChange={e => setFishingDevelopmentLevel(+e.currentTarget.value)}
        />
        <Label for='oreQ'>Fiske</Label>
        <Input
          type='text'
          name='oreQ'
          placeholder='Kvalite'
          value={oreQuality}
          onChange={e => setOreQuality(+e.currentTarget.value)}
        />
        <Input
          type='text'
          name='oreDL'
          placeholder='Utvecklingsnivå'
          value={oreDevelopmentLevel}
          onChange={e => setOreDevelopmentLevel(+e.currentTarget.value)}
        />
        <Label for='woodlandDL'>Skogsbruk</Label>
        <Input
          type='text'
          name='woodlandDL'
          placeholder='Utvecklingsnivå'
          value={woodlandDevelopmentLevel}
          onChange={e => setWoodlandDevelopmentLevel(+e.currentTarget.value)}
        />
        <Label for='educationDL'>Utbildning</Label>
        <Input
          type='text'
          name='educationDL'
          placeholder='Utvecklingsnivå'
          value={educationDevelopmentLevel}
          onChange={e => setEducationDevelopmentLevel(+e.currentTarget.value)}
        />
        <Label for='healthcareDL'>Medicin</Label>
        <Input
          type='text'
          name='healthcareDL'
          placeholder='Utvecklingsnivå'
          value={healthcareDevelopmentLevel}
          onChange={e => setHealthcareDevelopmentLevel(+e.currentTarget.value)}
        />
        <Label for='militaryDL'>Militär</Label>
        <Input
          type='text'
          name='militaryDL'
          placeholder='Utvecklingsnivå'
          value={militaryDevelopmentLevel}
          onChange={e => setMilitaryDevelopmentLevel(+e.currentTarget.value)}
        />
        <Label for='seafaringDL'>Sjöfart</Label>
        <Input
          type='text'
          name='seafaringDL'
          placeholder='Utvecklingsnivå'
          value={seafaringDevelopmentLevel}
          onChange={e => setSearfaringDevelopmentLevel(+e.currentTarget.value)}
        />
      </Form>
    </Container>
  );
};

const mapStateToProps = ({ info, fm }: ApplicationState) => ({
  fiefId: fm.fiefId,
  gameSessionId: fm.gameSessionId,
  loading: info.loading,
  errors: info.errors,
  fief: info.fief
});

const mapDispatchToProps = {
  fetchFiefRequest: fetchFiefRequest,
  setFiefId: setFiefId
};

export default connect(mapStateToProps, mapDispatchToProps)(Information);
