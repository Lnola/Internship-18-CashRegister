import React, { Component } from "react";
import {
  Collapse,
  Container,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
  NavLink
} from "reactstrap";
import { Link } from "react-router-dom";
import "./NavMenu.css";

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor(props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true,
      navText: "Intro"
    };
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  handleNavTextChange = newText => {
    if (localStorage.getItem("cashierId") !== null)
      this.setState({ navText: newText });
  };

  handleLogOut = () => {
    this.handleNavTextChange("Login");
    localStorage.removeItem("cashierId");
    localStorage.removeItem("registerId");
  };

  render() {
    return (
      <header>
        <Navbar
          className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
          light
        >
          <Container>
            <NavbarBrand
              onClick={() => this.handleNavTextChange("Cash Register")}
              tag={Link}
              to="/"
            >
              {this.state.navText}
            </NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse
              className="d-sm-inline-flex flex-sm-row-reverse"
              isOpen={!this.state.collapsed}
              navbar
            >
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink
                    onClick={() => this.handleNavTextChange("Cash Register")}
                    tag={Link}
                    className="text-dark"
                    to="/register"
                  >
                    Cash register
                  </NavLink>
                </NavItem>

                <NavItem>
                  <NavLink
                    onClick={() => this.handleNavTextChange("Store Inventory")}
                    tag={Link}
                    className="text-dark"
                    to="/inventory"
                  >
                    Inventory
                  </NavLink>
                </NavItem>

                <NavItem>
                  <NavLink
                    onClick={() => this.handleNavTextChange("Bill History")}
                    tag={Link}
                    className="text-dark"
                    to="/history"
                  >
                    History
                  </NavLink>
                </NavItem>

                <NavItem>
                  <NavLink
                    onClick={this.handleLogOut}
                    tag={Link}
                    className="text-dark"
                    to="/"
                  >
                    Log out
                  </NavLink>
                </NavItem>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
