import axios from 'axios';

const https = axios.create({
    baseURL: "https://climb-api.openbeta.io"
})

export default {
    getStuffNearPGH(){
        console.log(https.get('/geocode/v1/sectors?latlng=40.4406%2C-79.9969&radius=100'));
        return https.get('/geocode/v1/sectors?latlng=40.4406%2C-79.9969&radius=100');
    }
    
    // Get area details for area details component 
}