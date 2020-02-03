import { FormEvent, useState } from 'react';

export interface initialInformationFormFields {
  name: string;
  acres: number;
  farmlandAcres: number;
  pastureAcres: number;
  woodlandAcres: number;
  unusableAcres: number;
  animalHusbandryQuality: number;
  agriculturalQuality: number;
  fishingQuality: number;
  oreQuality: number;
  animalHusbandryDevelopmentLevel: number;
  agriculturalDevelopmentLevel: number;
  fishingDevelopmentLevel: number;
  woodlandDevelopmentLevel: number;
  oreDevelopmentLevel: number;
  educationDevelopmentLevel: number;
  healthcareDevelopmentLevel: number;
  militaryDevelopmentLevel: number;
}

const informationFormFields = (
  initialInformationFormFields: initialInformationFormFields
) => {
  const [fields, setValues] = useState(initialInformationFormFields);

  return [
    fields,
    function(event: FormEvent<HTMLInputElement>) {
      let currentTarget = event.target as HTMLInputElement;
      setValues({
        ...fields,
        [currentTarget.name]: currentTarget.value
      });
    }
  ];
};

export default informationFormFields;
