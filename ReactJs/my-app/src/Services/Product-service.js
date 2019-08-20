import axios from 'axios';
export const getProducts = () => {
    const api = 'https://raw.githubusercontent.com/mdmoin7/Random-Products-Json-Generator/master/products.json';
    return axios.get(api).
        then(response => ({ data: response.data, status: response.status }));
}