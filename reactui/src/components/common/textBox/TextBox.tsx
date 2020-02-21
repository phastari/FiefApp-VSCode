import React, { useState, ChangeEvent } from 'react';
import './textbox.scss';

interface PropsFromParent {
    name: string;
    value: string;
    canEdit: boolean;
    showLabel: boolean;
}

type AllProps = PropsFromParent & { handlePropertyChange?: any }

const TextBox: React.FC<AllProps> = (props) => {
    const [newValue, setValue] = useState(props.value);

    const handleValueChange = (e:ChangeEvent<HTMLInputElement>) => {
        setValue(e.target.value);
    }

    const handleLostFocus = () => {
        if (props.handlePropertyChange != null) {
            props.handlePropertyChange(props.name, newValue);
        }
    }

    return (
        <div className='textbox-container'>
            {props.showLabel &&
                <span>{props.name}</span>
            }
            <input type='text' spellCheck='false' value={newValue} onChange={(e) => handleValueChange(e)} onBlur={() => handleLostFocus()} disabled = {(props.canEdit) ? false : true}/>
        </div>
    );
}

export default TextBox;
