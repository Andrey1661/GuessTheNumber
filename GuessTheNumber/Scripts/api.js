const api = axios.create({
    baseURL: 'http://localhost:31668/api/',
    headers: {
        'Content-type': 'application/json'
    }
});