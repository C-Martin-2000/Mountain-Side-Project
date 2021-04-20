<template>
    <div class = "jumbotron">
      <h1>
      Welcome to the mountain-side-project, an inferior app for bad climbers.
      </h1>  
        <h5> To start finding climbing areas near you, enter a radius in km to search </h5>
          <input type="text" v-model="radius"/>
          <button class="btn btn-primary" v-on:click="getTheStuff()"> GO FIND IT </button>
    </div>
</template>

<script>

import areasRoutesService from "../services/areasRoutesService";

export default {
    name: 'Jumbotron',
    data() {
        return {
        radius: '',
        lat: '',
        long: '',
        areas: []
        }
    },
   
    methods: {
        getTheStuff() {
        areasRoutesService.getStuffNearMe(this.lat, this.long, this.radius).then(
        (response) => {
            this.areas = response.data;
            console.log(response.data);
            this.$store.commit('SET_LONG', this.long);
            this.$store.commit('SET_LAT', this.lat);
            this.$store.commit('SET_AREAS', this.areas);
        })
        }
    },
    created() {
      navigator.geolocation.getCurrentPosition(
        position => {
        this.lat = position.coords.latitude;
        this.long = position.coords.longitude;
        },
        error => {
          console.log(error.message);
        }
      );
    },
}
</script>

<style>

</style>