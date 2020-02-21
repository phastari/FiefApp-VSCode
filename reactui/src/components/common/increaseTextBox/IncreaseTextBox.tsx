import React, { FC, useState, ChangeEvent } from 'react';
import './increase-textbox.scss';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faChevronUp, faChevronDown } from '@fortawesome/free-solid-svg-icons';
import { isNumber } from 'util';

interface PropsFromParent {
    name: string;
    value: number;
    showLabel: boolean;
}

type AllProps = PropsFromParent & { handlePropertyChanged?: any };

const IncreaseTextBox: FC<AllProps> = (props) => {
    const [newValue, setNewValue] = useState(props.value);

    const handleIncrease = () => {
        setNewValue(newValue + 1);
    }

    const handleDecrease = () => {
        if (newValue > 0) {
            setNewValue(newValue - 1);
        }
    }

    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        let i = parseInt(e.target.value);

        if (isNumber(i)) {
            setNewValue(i);
            
            if (props.handlePropertyChanged !== null && newValue !== props.value) {
                props.handlePropertyChanged(props.name, newValue);
            }
        }
    }

    return (
        <div className='increase-textbox-container'>
            {props.showLabel &&
                <span>{props.name}</span>
            }
            <div className='holder'>
                <input spellCheck='false' type='text' value={newValue.toString()} onChange={(e) => handleChange(e)} /> 
                <ul>
                    <li onClick={() => handleIncrease()}><FontAwesomeIcon icon={faChevronUp}/></li>
                    <li onClick={() => handleDecrease()}><FontAwesomeIcon icon={faChevronDown}/></li>
                </ul>
            </div>
        </div>
    )
}

export default IncreaseTextBox;
