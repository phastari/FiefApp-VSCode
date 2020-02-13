import React, { Fragment } from "react"
import { Nav, NavItem, Button } from "reactstrap";
import { FiefManagerIndex } from "../types";

type Props = { setIndex: React.Dispatch<React.SetStateAction<FiefManagerIndex>> };

const SideNav: React.FC<Props> = (props) => {

    return (
        <Fragment>
            <Nav vertical>
               <NavItem>
                   <Button onClick={() => props.setIndex(FiefManagerIndex.INFORMATION)}>Information</Button>
                </NavItem> 
                <NavItem>
                   <Button onClick={() => props.setIndex(FiefManagerIndex.STEWARDS)}>Förvaltare</Button>
                </NavItem> 
            </Nav>
        </Fragment>
    )
}

export default SideNav;
