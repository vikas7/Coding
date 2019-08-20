import React from 'react';
import { getMenuList } from '../shared/menu-service';
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
  UncontrolledDropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem
} from 'reactstrap';

import { MenuModel } from '../shared/menu-model';
import { Link } from 'react-router-dom';

class Menu extends React.Component {

  state = { menuItems: [], isOpen: false };

  componentDidMount() {
    getMenuList().
      then(menuItems => this.setState({ menuItems })
      ).catch(err => console.log('error', err));
  }
  _renderSubMenu = (menuText: string, submenu: MenuModel[]) => {
    console.log(submenu);
    return (
      <UncontrolledDropdown nav inNavbar>
        <DropdownToggle nav caret>{menuText}</DropdownToggle>
        <DropdownMenu>
          {
            submenu.map(
              (menu, i) => <DropdownItem key={i}>
                <Link to={menu.menuLink}>
                  {menu.menuText}
                </Link>
              </DropdownItem>
            )
          }
        </DropdownMenu>
      </UncontrolledDropdown>
    );
  }

  toggle() {
    this.setState({
      isOpen: !this.state.isOpen
    });
  }

  _rednerMenu = (menu: MenuModel) => {
    if (!menu.submenu) {
      return (
        <NavItem key={menu.menuLink}>
          <Link to={menu.menuLink}>
            {menu.menuText}
          </Link>
        </NavItem>
      )
    } else {
      return this._renderSubMenu(menu.menuText, menu.submenu);
    }
  }
  render() {
    const menuList = this.state.menuItems as MenuModel[];
    return (
      <div>
        <Navbar color="light" light expand="md">
          <NavbarBrand href="/">reactstrap</NavbarBrand>
          <NavbarToggler onClick={this.toggle} />
          <Collapse isOpen={this.state.isOpen} navbar>
            <Nav navbar>
              {
                menuList.map(
                  menu => this._rednerMenu(menu)
                )
              }
            </Nav>
          </Collapse>
        </Navbar>
      </div>
    );
  }
}

export default Menu;