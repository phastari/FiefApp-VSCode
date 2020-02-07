import React from 'react';
import './loading.css';

const Loading: React.FC = () => {
    return (
            <div className="loader">
                <div className="box1"></div>
                <div className="box2"></div>
                <div className="box3"></div>
                <div className="box4"></div>
                <div className="box5"></div>
            </div>
    )
}

export default Loading;
