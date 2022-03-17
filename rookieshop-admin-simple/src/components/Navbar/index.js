import React, { Component } from "react";
import { Dropdown } from "react-bootstrap";
import { Link } from "react-router-dom";
import { UserContext } from "../../index";
import userService from "../../services/userService"
import "./Navbar.css";

export default class Navbar extends Component {
  state = {
    username: '',
    isAuthenticated: false,
    navbar: false,
  };

  toggleNavbar = this.toggleNavbar.bind(this)

  toggleNavbar(){
    this.setState({ navbar: !this.state.navbar })
  }

  componentDidMount(){
    userService.userManager.getUser().then((user) => {
      if(user){
        this.setState ({
          username : user.profile.name,
          isAuthenticated: true,
        });          
      }  
    });
  }

  render() {
    const show = (this.state.navbar) ? "show" : "" ;
    const manage = (!this.state.isAuthenticated) ? "d-none" : "";
    const signin = (this.state.isAuthenticated) ? "d-none" : "";
    console.log(signin);

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
            <Link to="/authentication/signin" className={signin}>
                <li className={"nav-item nav-link px-lg-4 "+ signin}>Sign in</li>
            </Link>
                <Dropdown className={manage}>
                  <Dropdown.Toggle variant="dark no-border" id="dropdown-basic">
                    Hello {this.state.username}!
                  </Dropdown.Toggle>
                  <Dropdown.Menu>
                    <Dropdown.Item>
                      <Link to="/User">
                        <li className="nav-item nav-link text-dark">User Manager</li>
                      </Link>
                    </Dropdown.Item>
                    <Dropdown.Item>
                      <Link to="/authentication/signout">
                        <li className="nav-item nav-link text-dark">Sign out</li>
                      </Link>
                    </Dropdown.Item>
                  </Dropdown.Menu>
                </Dropdown>
          </nav>
        )}
      </UserContext.Consumer>
    );
  }
}
