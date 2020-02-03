import * as React from 'react';
import { connect } from 'react-redux';

const HomePage = () => (
  <div>
    <h1>KUNG&ADEL</h1>
    <h2>Kluriga Uträkningar Några Gillar & Alla Dina Egendomar och Land</h2>
    <p>
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
  </div>
);

export default connect()(HomePage);
