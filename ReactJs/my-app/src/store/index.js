import {createStore} from 'redux';
import currencyReducer from './reducers/currency-reducer';
import rootReducer from './reducers/index'

const appStore=createStore(
    rootReducer,
    window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__());

export default appStore;