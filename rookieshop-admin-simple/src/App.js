import React, { lazy, Suspense, useEffect } from "react";
import logo from "./logo.svg";
import "./App.css";
import Home from "./components/Home";
import Navbar from "./components/Navbar";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import InLineLoader from "./shared-components/InlineLoader";
import { BRAND, CATEGORY, PRODUCT } from "./Constants/pages";

const Brand = lazy(() => import('./components/Brand'));
const Category = lazy(() => import('./components/Category'));
const Product = lazy(() => import('./components/Product'));


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
          </Switch>
         </SusspenseLoading>
        </div>
      </Router>
    );
  }
}

export default App;
