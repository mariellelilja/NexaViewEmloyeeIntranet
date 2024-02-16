import axios from 'axios';

const baseURL = 'https://localhost:44319/api2/';

const apiService = axios.create({
  baseURL,
  headers: {
    'Content-Type': 'application/json',
  },
});

/* TODO: investigate and edit, as jwt token is not used */
//include authorization token as header on reqs, if it exists fr local storage or cookies:
apiService.interceptors.request.use((config) => {
    const token = localStorage.getItem('authToken');
    if(token){
        config.headers['Authorization'] = 'Bearer ' + token;
    }
    return config;
}, (error) => {
    return Promise.reject(error);
});

export default apiService;
