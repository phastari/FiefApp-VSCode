import React, { Fragment, useState } from 'react';
import { RouteComponentProps, Link } from '@reach/router';
import useAuthenticationService from '../../services/useAuthenticationService/useAuthenticationService';
import { Navbar, Nav, NavItem, Dropdown, DropdownToggle, DropdownMenu, Button } from 'reactstrap';
import Login from '../login/Login';
import { logout } from '../../services/useAuthenticationService/actions';
import './top-navbar.scss';

type Username = {
    name: string | null;
}

const TopNavBar: React.FC<RouteComponentProps> = (_) => {
    const {
        state: { username, isAuthenticated }
    } = useAuthenticationService();

    return (
        <div>
            <Navbar color='light' light expand='md' className='navbar-expand-sm navbar-toggleable-sm border-bottom vinque'>
                <div className='container no-margins'>
                    <Link to='/' className='navbar-brand'>KUNG&ADEL</Link>
                    { isAuthenticated ? <LoggedInView name={username} /> : <LoggedOutView />}
                </div>
            </Navbar>
        </div>
    );
    
}

const LoggedInView: React.FC<Username> = ({ name }) => (
    <Fragment>
        <Nav navbar className='mr-auto'>
            <NavItem>
                <Link to='/gamesessions' className='navbar-brand'>Förlänings hanteraren</Link>
            </NavItem>
        </Nav>
        <Nav navbar className='ml-auto'>
            {name}&nbsp;
            <NavItem>
                <Button onClick={() => logout()}>Logga ut</Button>
            </NavItem>
        </Nav>
    </Fragment>
)

const LoggedOutView = () => {
    const [dropdownOpen, setDropdownOpen] = useState(false);

    const toggle = () => setDropdownOpen(prevState => !prevState);
    const callback = () => setDropdownOpen(false);

    return (
    <Fragment>
        <Nav navbar className='mr-auto'>
            <NavItem className='link'>
                <Link to='/gamesessions'>Förlänings hanteraren</Link>
            </NavItem>
        </Nav>
        <Nav navbar className='ml-auto'>
            <NavItem>
                <Dropdown isOpen={dropdownOpen} toggle={toggle}>
                    <DropdownToggle caret>
                        Logga in
                    </DropdownToggle>
                    <DropdownMenu right>
                        <Login closeCallback={callback}/>
                    </DropdownMenu>
                </Dropdown>
            </NavItem>
        </Nav>
    </Fragment>
    )
}

export default TopNavBar;