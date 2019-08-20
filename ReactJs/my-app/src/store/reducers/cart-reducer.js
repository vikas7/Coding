import { ADD_TO_CART, REMOVE_FROM_CART } from "../actions/cart-action";


const cartReducer = (state = [], action) => {
    switch (action.type) {
        case ADD_TO_CART:
            return [...state, action.product];
        case REMOVE_FROM_CART:
            return state.filter(p => p.id != action.id);
            default:
            return state;
    }

}

export default cartReducer;