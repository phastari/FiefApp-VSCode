import React, { Fragment } from "react"
import { Nav, NavItem } from "reactstrap";
import { Link } from "@reach/router";

const SideNav = () => {
    return (
        <Fragment>
            <Nav vertical>
               <NavItem>
                   <Link to='/fiefmanager/information'>Information</Link>
                </NavItem> 
            </Nav>
        </Fragment>
    )
}

export default SideNav;
