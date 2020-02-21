import React, { useState, ChangeEvent } from 'react';
import './fief-selector.scss';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEdit, faTrashAlt, faPlusCircle, faSave, faTimes, faChevronDown } from '@fortawesome/free-solid-svg-icons';
import { IShortFief } from '../../../services/useFiefManagerService/types';

interface Props {
    fiefsList: IShortFief[];
    selectedFief: string;
}

const FiefSelector: React.FC<Props> = (props) => {
    const [selectedFief, setSelectedFief] = useState(props.selectedFief);
    const [open, setOpen] = useState(false);
    const [edit, setEdit] = useState(false);
    const [newName, setNewName] = useState('');
    const [mouseOver, setMouseOver] = useState(false);

    const handleClick = (name: string) => {
        setSelectedFief(name);
        setOpen(false);
    }

    const handleEditClick = () => {
        setEdit(true);
        setOpen(false);
    }

    const handleCancel = () => {
        setNewName('');
        setEdit(false);
    }

    const handleToggle = () => {
        setOpen(!open);
    }

    const handleMouseLeave = () => {
        setOpen(false);
        setMouseOver(false);
    }

    const handleFiefNameChange = (e: ChangeEvent<HTMLInputElement>) => {
        setNewName(e.target.value);
    }

    const handleIconMouseOver = () => {
        if (!open) {
            setMouseOver(true);
        }
    }

    return (
        <div className='fief-selector-container'>
            <span>Förläning</span>
            {!edit &&
                <div className='dropdown' onClick={() => handleToggle()} onMouseLeave={() => handleMouseLeave()} onMouseOver={() => handleIconMouseOver()}>
                <span>{selectedFief}{mouseOver && !open && <FontAwesomeIcon className='icon' icon={faChevronDown}/>}</span>
                <div className='icons-holder'>
                    {props.fiefsList.length > 1 && mouseOver && !open &&
                        <span><FontAwesomeIcon icon={faTrashAlt}/></span>
                    }
                    {mouseOver && !open &&
                        <span><FontAwesomeIcon icon={faEdit} onClick={() => handleEditClick()}/></span>
                    }
                </div>
                {open && 
                    <div className='dropdown-content'>
                        <ul>
                            {props.fiefsList.map(fief => 
                                <li key={fief.fiefId}>
                                    <p onClick={() => handleClick(fief.name)}>{fief.name}</p>
                                </li>
                            )}
                        </ul>
                    </div>
                }
            </div>
            }
            
            {edit && 
                <div className='edit-div'>
                    <input type='text' className='edit-input' value={selectedFief} onChange={(e) => handleFiefNameChange(e)}/>
                    <div className='icons-holder'>
                        <span><FontAwesomeIcon icon={faSave}/></span>
                        <span><FontAwesomeIcon icon={faTimes} onClick={() => handleCancel()}/></span>
                    </div>
                </div>
            }
            <span><FontAwesomeIcon icon={faPlusCircle} className='add-icon'/></span>
        </div>
    )
}

export default FiefSelector;
