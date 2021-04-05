import axios from 'axios';

const https = axios.create({
    baseURL: "https://climb-api.openbeta.io"
})

export default {

    getStuffNearMe(lat, long, radius){
        // console.log(https.get(`/geocode/v1/sectors?latlng=${lat}%2C${long}&radius=${radius}`));
        return https.get(`/geocode/v1/sectors?latlng=${lat}%2C${long}&radius=${radius}`);
    },

    // getStuffNearPGH(){
    //     console.log(https.get('/geocode/v1/sectors?latlng=40.4406%2C-79.9969&radius=100'));
    //     return https.get('/geocode/v1/sectors?latlng=40.4406%2C-79.9969&radius=100');
    // },
    getAreaDetailsByID(id){
        return https.get(`/geocode/v1/sectors/${id}`);
    }
}