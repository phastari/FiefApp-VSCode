import React, { useState, ChangeEvent } from 'react';
import './textarea.scss';

interface PropsFromParent {
    name: string;
    value: string;
    canEdit: boolean;
    rows: number;
}

type AllProps = PropsFromParent & { handlePropertyChange?: any };

const TextArea: React.FC<AllProps> = (props) => {
    const [newValue, setNewValue] = useState(props.value);

    const handleChange = (e: ChangeEvent<HTMLTextAreaElement>) => {
        if (props.value !== e.target.value) {
            setNewValue(e.target.value);
            if (props.handlePropertyChange !== null) {
                props.handlePropertyChange(props.name, e.target.value);
            }
        }
    }

    return (
        <div className='textarea-container'>
            <div>
                <span>{props.name}</span>
            </div>
            <div>
                <textarea spellCheck='false' disabled={props.canEdit ? false : true} rows={props.rows} value={newValue} onChange={(e) => handleChange(e)}/>
            </div>
        </div>
    );
}

export default TextArea;
