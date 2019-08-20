import { STORE_USER, LOG_OUT } from "../actions/user-actions";

const userReducer = (state = {}, action) => {
    switch (action.type) {
        case STORE_USER:
            return action.user;
        case LOG_OUT:
            return {};
        default:
            return state;
    }
}
export default userReducer;