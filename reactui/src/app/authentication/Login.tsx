import React, { useState } from 'react';
import { UserAuthentication } from '../../store/authentication/types';
import { loginRequest } from '../../store/authentication/actions';
import { connect } from 'react-redux';
import { ApplicationState } from '../../store';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import { history } from '../..';

interface PropsFromState {
  loading: boolean;
  errors: string | undefined;
  username: string;
  token: string;
  isAuthenticated: boolean;
}

interface PropsFromDispatch {
  loginRequest: typeof loginRequest;
}

type AllProps = PropsFromState & PropsFromDispatch;

const Login: React.FC<AllProps> = props => {
  const [inputName, setInputName] = useState('');
  const [inputPassword, setInputPassword] = useState('');

  const handleSubmit = () => {
    let user: UserAuthentication = {
      username: inputName,
      password: inputPassword
    };

    setInputName('');
    setInputPassword('');
    const { loginRequest } = props;
    loginRequest(user);
  };

  return (
    <Form>
      <FormGroup
        style={{
          padding: '10px',
          marginBottom: '0px',
          paddingBottom: '0px'
        }}
      >
        <Label for='name'>Användarnamn</Label>
        <Input
          type='text'
          name='name'
          autoComplete='username'
          placeholder='Användarnamn'
          value={inputName}
          onChange={e => setInputName(e.currentTarget.value)}
        />
      </FormGroup>
      <FormGroup
        style={{
          padding: '10px',
          marginTop: '0px',
          paddingTop: '6px'
        }}
      >
        <Label for='current-password'>Lörsenord</Label>
        <Input
          type='password'
          name='current-password'
          autoComplete='current-password'
          placeholder='Lösenord'
          value={inputPassword}
          onChange={e => setInputPassword(e.currentTarget.value)}
        />
      </FormGroup>
      <Button onClick={() => handleSubmit()}>login</Button>
      <Button onClick={() => history.push('/signup')}>Signup</Button>
      <Label>{props.errors}</Label>
    </Form>
  );
};

const mapStateToProps = ({ auth }: ApplicationState) => ({
  authenticating: auth.loading,
  errors: auth.errors,
  username: auth.username,
  token: auth.token,
  isAuthenticated: auth.isAuthenticated
});

const mapDispatchToProps = {
  loginRequest: loginRequest
};

export default connect(mapStateToProps, mapDispatchToProps)(Login);
