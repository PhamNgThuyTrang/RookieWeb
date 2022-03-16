import React, { lazy, Suspense } from "react";
import "./App.css";
import 'bootstrap/dist/css/bootstrap.min.css';
import Home from "./components/Home";
import Navbar from "./components/Navbar";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import InLineLoader from "./shared-components/InlineLoader";
import { BRAND, CATEGORY, PRODUCT, SUBCATEGORY, SIGNIN, SIGNOUT } from "./Constants/pages";
import { SigninOidc } from "./components/Authentication/signin";
import { Signout } from "./components/Authentication/signout";

const Brand = lazy(() => import('./components/Brand'));
const Category = lazy(() => import('./components/Category'));
const Product = lazy(() => import('./components/Product'));
const SubCategory = lazy(() => import('./components/SubCategory'));


const SusspenseLoading = ({ children }) => (
  <Suspense fallback={<InLineLoader />}>
    {children}
  </Suspense>
);

class App extends React.Component {
  state = {
    bootcamp: "Rookies",
    homeClass: "",
  };

  updateName() {
    this.setState({
      isShowHelloElement: !this.state.isShowHelloElement,
      bootcamp: "sdfalsfjlsd",
    });
  }

  handleSearchKey(e) {
    console.log(e.target.value);
  }

  render() {
    return (
      <Router>
        <div className="App">
          <Navbar onSearchKey={(e) => this.handleSearchKey(e)} />
          <div className="container">
          <SusspenseLoading>
            <Switch>
              <Route exact path="/">
                <Home bootcamp={this.state.bootcamp} />
              </Route>
              <Route path={BRAND}>
                <Brand />
              </Route>
              <Route path={CATEGORY}>
                <Category />
              </Route>
              <Route path={PRODUCT}>
                <Product />
              </Route>
              <Route path={SUBCATEGORY}>
                <SubCategory />
              </Route>
              <Route path={SIGNIN}>
                <SigninOidc />
              </Route>
              <Route path={SIGNOUT}>
                <Signout />
              </Route>
          </Switch>
         </SusspenseLoading>
         </div>
        </div>
      </Router>
    );
  }
}

export default App;
