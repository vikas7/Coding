import axios from'axios';

export const getMockData = () => {
    return axios.get('/mock-data.json').then(res =>res.data);
}