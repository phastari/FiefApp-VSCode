import React, { Fragment } from 'react';
import { RouteComponentProps } from '@reach/router';



const Home: React.FC<RouteComponentProps> = (_: RouteComponentProps) => {
    
    return (
        <Fragment>
            <h1 className='vinque' style={{fontSize: '10vw'}}>KUNG&ADEL</h1>
            <h2 className='goudyoldstylebold' style={{fontSize: '2.4vw'}}>Kluriga Uträkningar Några Gillar & Alla Dina Egendomar och Land</h2>
            <p className='goudyoldstyleitalic' style={{fontSize: '1.8vw'}}>
            Många riddare står som förvaltare av jord. Dessa ägor kan vara ärvda eller
            förvärvade,
            <br />
            erövrade eller till och med köpta. Jorden är den viktigaste källan till
            inkomst i<br />
            Mundana; och den som äger mycket jord kan ofta räkna sig som en maktfaktor
            även
            <br />
            vad gäller politik. En jordägande vasall kallas hädenefter länsherre -
            herre eftersom han är
            <br />
            härskare över sitt län och nästan alla som lever där. Inte ens rikets
            högste har mycket att
            <br />
            säga till om i länet.
            </p>
        </Fragment>
    );
};

export default Home;
