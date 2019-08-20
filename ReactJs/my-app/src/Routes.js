import React from 'react';
import Demo from './Demo';
import ProductList from './Containers/ProductList';
import UserForm from './Containers/UserForm';
import ErrorPage from './components/ErrorPage';
import './App.css';

//Day 3
import {
    BrowserRouter as Router, Route, Link, Switch
  } from 'react-router-dom'; 
import Cart from './Containers/Cart';
import WishList from './Containers/WishList';

const AppRouter = (props) => {
    return (
        <Router>
            <ul>
                <li><Link to = "/">Home</Link></li>
                <li><Link to = "/products">Products</Link></li>
                <li><Link to = "/form/demo">Form</Link></li>
                <li><Link to = "/cart">Cart</Link></li>
                <li><Link to = "/wishlist">wishlist</Link></li>
                <li><Link to = "/error">404</Link></li>
            </ul>
            <Switch>
            <Route exact path = "/" component={Demo}/>
            <Route path = "/products" component={ProductList}/>
            <Route path = "/form/:name" component={UserForm}/>
            <Route path = "/cart" component={Cart}/>
            <Route path = "/wishlist" component={WishList}/>

            <Route component={ErrorPage}/>
            </Switch>
        </Router>
    )
}

export default AppRouter;
