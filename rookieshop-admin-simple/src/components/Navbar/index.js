import React, { Component } from "react";
import { Dropdown } from "react-bootstrap";
import { Link } from "react-router-dom";
import { UserContext } from "../../index";
import "./Navbar.css";

export default class Navbar extends Component {
  state = {
    username: "Admin",
    navbar: false,
  };

  toggleNavbar = this.toggleNavbar.bind(this)

  toggleNavbar(){
    this.setState({ navbar: !this.state.navbar })
  }

  render() {
    const show = (this.state.navbar) ? "show" : "" ;

    return (
      <UserContext.Consumer>
        {(value) => (
          <nav id="navbar" className="navbar navbar-expand-lg navbar-dark bg-dark">
            <button className="navbar-toggler" type="button" onClick={ this.toggleNavbar }>
              <span className="navbar-toggler-icon"></span>
            </button>
            <div className={"collapse navbar-collapse " + show} id="navbarNav">
              <ul className="navbar-nav">
                <Link to="/">
                <li className="nav-item nav-link px-lg-4">Home</li>
                </Link>
                <Link to="/brand">
                  <li className="nav-item nav-link px-lg-4">Brand</li>
                </Link>
                <Link to="/category">
                  <li className="nav-item nav-link px-lg-4">Category</li>
                </Link>
                <Link to="/subcategory">
                  <li className="nav-item nav-link px-lg-4">SubCategory</li>
                </Link>
                <Link to="/product">
                  <li className="nav-item nav-link px-lg-4">Product</li>
                </Link>
              </ul>
            </div>
            <Dropdown>
              <Dropdown.Toggle variant="dark no-border" id="dropdown-basic">
              {value.username}              
              </Dropdown.Toggle>

              <Dropdown.Menu>
                <Dropdown.Item href="/user">User Manager</Dropdown.Item>
                <Dropdown.Item>
                  <Link to="/authentication/signin">Sign in</Link>
                </Dropdown.Item>
                <Dropdown.Item>
                <Link to="/authentication/signout">Sign out</Link>
                </Dropdown.Item>
              </Dropdown.Menu>
            </Dropdown>
          </nav>
        )}
      </UserContext.Consumer>
    );
  }
}
