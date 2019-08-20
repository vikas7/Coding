import {createStore} from 'redux';
import rootReducer from './'
const appStore=createStore(
    rootReducer,
    window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__());

export default appStore;