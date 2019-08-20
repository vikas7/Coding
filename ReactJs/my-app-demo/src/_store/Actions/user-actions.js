
export const STORE_USER = 'STORE_USER';
export const LOG_OUT = 'LOG_OUT';

export const storeuser = (user) => ({
    type: STORE_USER,
    user
});

export const logOut = () => ({
    type: LOG_OUT
});