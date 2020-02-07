import React, { Fragment, useState } from 'react';
import { RouteComponentProps, Link } from '@reach/router';
import useAuthenticationService from '../../services/useAuthenticationService/useAuthenticationService';
import { Navbar, Nav, NavItem, NavLink, Dropdown, DropdownToggle, DropdownMenu } from 'reactstrap';
import '../../index.css';
import Login from '../login/Login';

type Username = {
    name: string | null;
}

const TopNavBar: React.FC<RouteComponentProps> = (_) => {
    const {
        state: { username, isAuthenticated }
    } = useAuthenticationService();

    return (
        <Navbar color='light' light expand='md' className='navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow mb-3 vinque'>
            <div className='container'>
                <Link to='/' className='navbar-brand'>KUNG&ADEL</Link>
                { isAuthenticated ? <LoggedInView name={username} /> : <LoggedOutView />}
            </div>
        </Navbar>
    );
    
}

const LoggedInView: React.FC<Username> = ({ name }) => (
    <Fragment>
        <Nav navbar className='mr-auto'>
            <NavItem>
                <NavLink to='/gamesessions'>Förlänings hanteraren</NavLink>
            </NavItem>
        </Nav>
        <Nav navbar className='ml-auto'>
            {name}&nbsp;
            <NavItem>
                <NavLink to='/logout'>Logga ut</NavLink>
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
            <NavItem>
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