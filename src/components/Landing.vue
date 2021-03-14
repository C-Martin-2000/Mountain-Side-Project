<template>
  <div>
      <h1>
      Welcome to the mountain-side-project, an inferior app for bad climbers.
      </h1>  
      <h3>Here is a list of climbing areas near PGH</h3>
        <p>list goes here / needs to ask for location permsisions /
            maybe include map / list items clickable</p>
        <table>
          <tr>
            <th>
              Area name
              </th>
          </tr>
        <tr
          v-for= "area in areas"
          :key= "area.meta_mp_sector_id"
          >
          <router-link v-on:click='selectedArea = area.meta_mp_sector_id' :to="`/area/${area.meta_mp_sector_id}`" >{{ area.meta_parent_sector }}</router-link>
          </tr>
        </table>
  </div>
</template>

<script>
import areasRoutesService from "../services/areasRoutesService";
export default {
    name: 'Landing',
  data() {
    return {
    selectedArea: '',
    areas: [],
    inputRadius: '',
    userLocation: ''
    }
  },
  created() {
    areasRoutesService.getStuffNearPGH().then(
      (response) => {
        this.areas = response.data;
      }
    )}
  // methods: {
  //   selectArea(id){
  //     this.selectedArea = id;
  //   }
  // }
}

</script>

<style>

</style>