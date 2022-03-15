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
          <div id="navbar" className="navbar navbar-expand-lg navbar-dark bg-dark">
            <nav>
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
            </nav>
            <div className="nav-details">
                <p className="nav-username"> {value.username} </p>
            </div>
          </div>
        )}
      </UserContext.Consumer>
    );
  }
}
