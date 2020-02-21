import React, { useState } from 'react';
import './list-selector.scss';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faChevronDown } from '@fortawesome/free-solid-svg-icons';

interface IDisplayItem {
    id: number;
    value: string;
}

interface PropsFromParent {
    list: IDisplayItem[];
    name: string;
    value: string;
    canEdit: boolean;
}

type AllProps = PropsFromParent & { handlePropertyChange?: any };

const ListSelector: React.FC<AllProps> = (props) => {
    const [newValue, setNewValue] = useState(props.value);
    const [open, setOpen] = useState(false);
    const [mouseOver, setMouseOver] = useState(false);

    const toggleOpen = () => {
        setOpen(!open);
    }

    const handleClick = (value: string) => {
        setNewValue(value)
        setOpen(false);
        if (props.handlePropertyChange != null && newValue !== value) {
            props.handlePropertyChange(props.name, newValue);
        }
    }

    const handleonMouseLeave = () => {
        setOpen(false);
        setMouseOver(false);
    }

    const handleIconMouseOver = () => {
        if (!open) {
            setMouseOver(true);
        }
    }

    const handleonIconMouseLeave = () => {
        if (!open) {
            setMouseOver(false);
        }
    }

    return (
        <div className='list-selector-container'>
            <span>{props.name}</span>
            <div className='click-area' onMouseLeave={() => handleonMouseLeave()}>
            {props.canEdit &&
                <div className='dropdown' onClick={() => toggleOpen()} onMouseOver={() => handleIconMouseOver()} onMouseLeave={() => handleonIconMouseLeave()}>
                <span>{newValue}{mouseOver && !open && <FontAwesomeIcon className='icon' icon={faChevronDown}/>}</span>
                    {open &&
                        <div className='dropdown-content'>
                            <ul>
                                {props.list.map((item, index) => 
                                        <li key={index}>
                                            <p onClick={() => handleClick(item.value)}>{item.value}</p>
                                        </li>
                                    )}
                            </ul>
                        </div>
                    }
                </div>
            }
            </div>

            {!props.canEdit && 
                <span>{props.value}</span>
            }
        </div>
    );
}

export default ListSelector;
