import React, { useState, SyntheticEvent } from 'react';
import { Form, FormGroup, Label, Input, Button } from "reactstrap";
import { RouteComponentProps } from '@reach/router';
import useAuthenticationService from '../../services/useAuthenticationService/useAuthenticationService';
import { login } from '../../services/useAuthenticationService/actions';
import { AuthenticationActionTypes, IAuthenticationUser } from '../../services/useAuthenticationService/types';

type AllProps = RouteComponentProps & { closeCallback: any };

const Login: React.FC<AllProps> = (props) => {
    const [inputUsername, setInputUsername] = useState('');
    const [password, setPassword] = useState('');
    const [authenticating, setAuthenticating] = useState(false);
    const {
        dispatch
    } = useAuthenticationService();


    const handleSubmit = async (event: SyntheticEvent) => {
        event.preventDefault();
        setAuthenticating(true);

        if (!authenticating) {
            try {
                let user: IAuthenticationUser = { username: inputUsername, password: password };
                const response = await login(user);
                dispatch({ type: AuthenticationActionTypes.AUTHENTICATION_LOGIN_SUCCESS, username: response.username, token: response.token });
                setAuthenticating(false);
                props.closeCallback();
            } catch (error) {
                setAuthenticating(false);
                dispatch({ type: AuthenticationActionTypes.AUTHENTICATION_LOGIN_FAILURE, errors: error});
            }
        }
    };

    return (
        <Form onSubmit={handleSubmit} style={{width: '260px', paddingLeft: '20px', paddingRight: '20px'}}>
            <FormGroup>
                <Label for='username'>Användarnamn</Label>
                <Input type='text' id='username' placeholder='Användarnamn' value={inputUsername} onChange={(event) => setInputUsername(event.target.value)} />
            </FormGroup>
            <FormGroup>
                <Label for='password'>Lösenord</Label>
                <Input type='password' id='password' placeholder='Lösenord' value={password} onChange={(event) => setPassword(event.target.value)} />
            </FormGroup>
            <Button style={{float: 'right'}}>Logga in</Button>
        </Form>
    );
}

export default Login;
