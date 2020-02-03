import * as React from 'react';
import {
  Collapse,
  Container,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
  NavLink,
  Nav,
  Button
} from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import { connect } from 'react-redux';
import { ApplicationState } from '../../store';
import { logoutRequest } from '../../store/navmenu/actions';

interface PropsFromState {
  isOpen: boolean;
  isAuthenticated: boolean;
}

interface PropsFromDispatch {
  logoutRequest: typeof logoutRequest;
}

type Props = PropsFromState & PropsFromDispatch;

const NavMenu: React.FC<Props> = props => {
  const { isAuthenticated, logoutRequest } = props;
  return (
    <header>
      <Navbar
        className='navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow mb-3'
        light
      >
        <Container>
          <NavbarBrand tag={Link} to='/'>
            KUNG&ADEL
          </NavbarBrand>
          <NavbarToggler
            onClick={() => (props.isOpen = !props.isOpen)}
            className='mr-2'
          />
          <Collapse
            className='d-sm-inline-flex flex-sm-row-reverse'
            isOpen={props.isOpen}
            navbar
          >
            {isAuthenticated ? (
              <Button onClick={() => logoutRequest()}>Logout</Button>
            ) : (
              <Nav navbar className='ml-auto'>
                <NavItem>
                  <NavLink tag={Link} className='text-dark' to='/login'>
                    Login
                  </NavLink>
                </NavItem>
              </Nav>
            )}

            <Nav navbar className='mr-auto'>
              <NavItem>
                <NavLink tag={Link} className='text-dark' to='/gamesessions'>
                  Förläningshanteraren
                </NavLink>
              </NavItem>
            </Nav>
          </Collapse>
        </Container>
      </Navbar>
    </header>
  );
};

const mapStateToProps = ({ nav, auth }: ApplicationState) => ({
  isOpen: nav.isOpen,
  isAuthenticated: auth.isAuthenticated
});

const mapDispatchToProps = {
  logoutRequest: logoutRequest
};

export default connect(mapStateToProps, mapDispatchToProps)(NavMenu);
