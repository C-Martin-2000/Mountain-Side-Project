import axios from 'axios';


const https = axios.create({
    baseURL: "https://climb-api.openbeta.io"
})

export default {

    getClimbDetailsById(id) {
        console.log('here');
        return https.get(`/geocode/v1/sectors/${id}`);
    }

}