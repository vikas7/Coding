import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';

import Product from './components/Product';
import ProductList from './Containers/ProductList';
import Currency from './Containers/Currency';
import ErrorBoundary from './Containers/ErrorBoundary'
import UserForm from './Containers/UserForm';
import UserFormRef from './components/UserFormRef'
import { BrowserRouter as Router, Route, Link, Switch } from 'react-router-dom'
import { ErrorPage } from './components/ErrorPage'
import AppRouter from './Routes';

class App extends Component {

  state = {
    currentCurrency: 'USD'
  }

  updateCurrency(c) {
    this.currentCurrency = c;
    console.log(c);
    this.setState({ currentCurrency: c });

  }

  render() {
    return (
      <div>
        <h1>HEADER</h1>
        <Currency/>
        <AppRouter/>
        <h1>FOOTER</h1>
        {/* <UserForm/> */}
        {/* <Demo /> */}
        {/* <Currency changeCurrency={(e) => this.updateCurrency(e)} />
        <ErrorBoundary>
          <ProductList cCode={this.state.currentCurrency} />
        </ErrorBoundary> */}
      </div>

    );
  }
}

export default App;
