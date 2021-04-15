import axios from 'axios';


const https = axios.create({
    baseURL: "https://climb-api.openbeta.io"
})

export default {

    
    getClimbDetailsById(id) {
        console.log('here');
        return https.get(`/geocode/v1/climbs/${id}`);
    },

    getStuffNearMe(lat, long, radius){
        lat = lat.toFixed(4);
        long = long.toFixed(4);
        console.log(lat);
        console.log(long);
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