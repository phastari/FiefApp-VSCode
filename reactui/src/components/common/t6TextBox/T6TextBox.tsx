import React, { FC, useState } from 'react';
import './t6-textbox.scss';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faChevronUp, faChevronDown } from '@fortawesome/free-solid-svg-icons';

interface PropsFromParent {
    name: string;
    value: number;
    showLabel: boolean;
}

type AllProps = PropsFromParent & { handlePropertyChanged?: any };

const T6TextBox: FC<AllProps> = (props) => {
    const [newValue, setNewValue] = useState(props.value);
    const [numeric, setNumeric] = useState(false);

    const convertToString = (num: number) => {
        if (num === 0) {
            return '0T6';
        }

        let x = Math.floor(num / 4);
        let y = num / 4;
        if (x === y) {
            return x + 'T6';
        }

        let i = num - x * 4;
        return x + 'T6+' + i;
    }

    const handleFocus = () => {
        setNumeric(true);
    }

    const handleLostFocus = () => {
        setNumeric(false);
        if (props.handlePropertyChanged != null) {
            props.handlePropertyChanged(props.name, newValue);
        }
    }

    const handleIncrease = () => {
        setNewValue(newValue + 1);
    }

    const handleDecrease = () => {
        if (newValue > 0) {
            setNewValue(newValue - 1);
        }
    }

    return (
        <div className='t6container'>
            {props.showLabel &&
                <span>{props.name}</span>
            }
            <div className='holder'>
                {numeric ? 
                    <input onBlur={() => handleLostFocus()} onClick={() => handleFocus()} spellCheck='false' type='text' value={newValue.toString()} /> 
                    : <input onBlur={() => handleLostFocus()} onClick={() => handleFocus()} spellCheck='false' type='text' value={convertToString(newValue)} />}
                <ul>
                    <li onClick={() => handleIncrease()}><FontAwesomeIcon icon={faChevronUp}/></li>
                    <li onClick={() => handleDecrease()}><FontAwesomeIcon icon={faChevronDown}/></li>
                </ul>
            </div>
        </div>
    )
}

export default T6TextBox;
