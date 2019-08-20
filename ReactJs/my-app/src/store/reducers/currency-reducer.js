import { UPDATE_CURRENCY } from "../actions/currency-actions";

// currency-reducer.js, it updsted state to store
//(state, action)

const currencyReducer = (state = 'USD', action) => {
    switch (action.type) {
        case UPDATE_CURRENCY:
            return action.code;
        default:
            return state;
    }
}

export default currencyReducer;