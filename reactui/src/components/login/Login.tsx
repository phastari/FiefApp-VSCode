import React, { useState, SyntheticEvent } from 'react';
import { Form, FormGroup, Label, Input, Button } from "reactstrap";
import { RouteComponentProps } from '@reach/router';
import useAuthenticationService from '../../services/useAuthenticationService/useAuthenticationService';
import { login } from '../../services/useAuthenticationService/actions';

type AllProps = RouteComponentProps & { closeCallback: any };

const Login: React.FC<AllProps> = (props) => {
    const [inputUsername, setInputUsername] = useState('');
    const [password, setPassword] = useState('');
    const [authenticating, setAuthenticating] = useState(false);
    const {
        state: { username, token },
        dispatch
    } = useAuthenticationService();


    const handleSubmit = async (event: SyntheticEvent) => {
        event.preventDefault();
        setAuthenticating(true);

        if (!authenticating) {
            try {
                const user = await login(inputUsername, password);
                dispatch({ type: 'LOGIN_SUCCESS', username: user.username, token: user.token });
                setAuthenticating(false);
                props.closeCallback();
            } catch (error) {
                console.log(error);
                setAuthenticating(false);
                dispatch({ type: 'LOGIN_FAILURE'});
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
