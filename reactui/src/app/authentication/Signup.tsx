import React, { useState } from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import { history } from '../..';
import { SignupUser } from '../../store/authentication/types';
import { connect } from 'react-redux';
import { signupRequest } from '../../store/authentication/actions';
import { ApplicationState } from '../../store';

interface PropsFromState {
  loading: boolean;
  errors: string | undefined;
  username: string;
  token: string;
  isAuthenticated: boolean;
}

interface PropsFromDispatch {
  signupRequest: typeof signupRequest;
}

type AllProps = PropsFromState & PropsFromDispatch;

const Signup: React.FC<AllProps> = props => {
  const [inputName, setInputName] = useState('');
  const [inputPassword, setInputPassword] = useState('');
  const [inputConfirmPassword, setInputConfirmPassword] = useState('');

  const handleSubmit = () => {
    let user: SignupUser = {
      userName: inputName,
      password: inputPassword,
      passwordConfirmation: inputConfirmPassword
    };

    setInputName('');
    setInputPassword('');
    setInputConfirmPassword('');
    const { signupRequest } = props;
    signupRequest(user);
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
        <Label for='confirm-password'>Repetera lösenordet</Label>
        <Input
          type='password'
          name='confirm-password'
          autoComplete='confirm-password'
          placeholder='Lösenord'
          value={inputConfirmPassword}
          onChange={e => setInputConfirmPassword(e.currentTarget.value)}
        />
      </FormGroup>
      <Button onClick={() => handleSubmit()}>Signup</Button>
      <Button onClick={() => history.push('/login')}>Avbryt</Button>
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
  signupRequest: signupRequest
};

export default connect(mapStateToProps, mapDispatchToProps)(Signup);
