import axios from 'axios';


const apiKey = "AIzaSyCVkEKpvOo6NJg7XSOHIKFDcncFp2X8YLY";
const baseUrl = 'https://www.googleapis.com/identitytoolkit/v3/relyingparty'

export const userLogin = (email: string, password: string) => {
    const api = `${baseUrl}/verifyPassword?key=${apiKey}`;
    const data = { email, password, returnSecureToken: true };
    return axios.post(api, data).then(res => res.data);
}

export const userRegistration = (email: string, password: string) => {
    const api = `${baseUrl}/signupNewUser?key=${apiKey}`;
    const data = { email, password, returnSecureToken: true };
    return axios.post(api, data).then(res => res.data);
}