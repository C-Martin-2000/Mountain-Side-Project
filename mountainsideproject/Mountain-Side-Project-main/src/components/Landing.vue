<template>
  <div>
      <h1>
      Welcome to the mountain-side-project, an inferior app for bad climbers.
      </h1>  
      <h3>Here is a list of climbing areas near <strong>YOU</strong></h3>
        <p>
            maybe include map / get address from coordinates if can</p>
        <h3> Search for climbing areas by radius in km </h3>
            <input type="text" v-model="radius"/>
            <button v-on:click="getTheStuff()"> GO FIND IT </button>
        <table v-if="areasEmpty() == false">
          <!-- <button on:click = searchRadius()> Search </button> -->
          <tr>
            <th>
              Area name
              </th>
          </tr>
        <tr
          v-for= "area in areas"
          :key= "area.meta_mp_sector_id"
          >
          <!-- change from router link to clickable table whatevers -->
          <!-- <router-link v-on:click='selectedArea = area.meta_mp_sector_id' :to="`/area/${area.meta_mp_sector_id}`" >{{ area.meta_parent_sector }}</router-link> -->
           <button v-on:click="selectArea(area.meta_mp_sector_id)">{{ area.meta_parent_sector }}</button>
          </tr>
        </table>
         <!-- v show if selcet area id != null  / new component prop passed down for select area id -->
         <button v-if="showDetails() == true" v-on:click = hideDetails()> Hide Area </button>
         <area-details v-if="showDetails() == true" v-bind:selectedArea = 'selectedArea' :key="selectedArea"/>
  </div>
</template>

<script>
import areasRoutesService from "../services/areasRoutesService";

import AreaDetails from './AreaDetails.vue';
export default {

  components:
  {AreaDetails},
  name: 'Landing',
  data() {
    return {
    selectedArea: '',
    areas: [],
    userLat:'',
    userLong:'',
    radius:''
    }
  },
  created() {
          navigator.geolocation.getCurrentPosition(
            position => {
            console.log(position.coords.latitude);
            this.userLat = position.coords.latitude;
            console.log(position.coords.longitude);
            this.userLong = position.coords.longitude;
            },
            error => {
              console.log(error.message);
            }
          );
    },
  methods: {
    areasEmpty(){
      if(this.areas == '') {
        return true;
      }
      return false;
    },
    selectArea(id){
      this.selectedArea = id;
    },
    showDetails() {
      if(this.selectedArea != '') {
        return true;
      }
      return false;
    },
    hideDetails(){
      this.selectedArea = '';
    },
    getTheStuff() {
      console.log(this.userLat);
      console.log(this.userLong);
      console.log(this.radius);
      // // areasRoutesService.getStuffNearPGH().then(
      // var lat = this.userLat;
      // lat = lat.slice(0, 9);
      // var long = this.userLong;
      // long = long.slice(0, 9)
      areasRoutesService.getStuffNearMe(this.userLat, this.userLong, this.radius).then(
      (response) => {
        this.areas = response.data;
        console.log(response.data);
      })
    }
  }
}

</script>

<style>

</style>