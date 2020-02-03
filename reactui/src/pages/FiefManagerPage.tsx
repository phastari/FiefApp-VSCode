import * as React from 'react';
import { connect } from 'react-redux';
import Information from '../components/information/Information';

const FiefManagerPage = () => <Information />;

export default connect()(FiefManagerPage);
