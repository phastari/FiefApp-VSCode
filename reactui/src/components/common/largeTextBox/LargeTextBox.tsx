import React, { useState, ChangeEvent } from 'react';
import './large-textbox.scss';

interface PropsFromParent {
    name: string;
    value: string;
    showLabel: boolean;
    canEdit: boolean;
}

type AllProps = PropsFromParent & { handlePropertyChange?: any }

const LargeTextBox: React.FC<AllProps> = (props) => {
    const [newValue, setNewValue] = useState(props.value);

    const handleValueChange = (e:ChangeEvent<HTMLInputElement>) => {
        setNewValue(e.target.value);
    }

    const handleLostFocus = () => {
        if (props.handlePropertyChange != null && newValue !== props.value) {
            props.handlePropertyChange(props.name, newValue);
        }
    }

    return (
        <div className='large-textbox-container'>
            <span>{props.name}</span>
            <input type='text' spellCheck='false' value={newValue} onChange={(e) => handleValueChange(e)} onBlur={() => handleLostFocus()} disabled = {(props.canEdit) ? false : true}/>
        </div>
    );
}

export default LargeTextBox;
