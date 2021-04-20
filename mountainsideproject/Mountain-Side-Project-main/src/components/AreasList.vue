<template>
   <div id = "Areas">
      <table >
        <h2>  Areas </h2>
          <tr
            v-for= "area in this.$store.state.areas"
            :key= "area.meta_mp_sector_id"
            
          >
            <button class="areaButton" v-on:click="selectArea(area.meta_mp_sector_id)"> {{ area.meta_parent_sector }}</button>
          </tr>
      </table>
   </div>
</template>

<script>

import areasRoutesService from "../services/areasRoutesService";

export default {
    data(){
        return {
            areas: [],
            selectedArea: '',
            isSelectedArea: false,
            details: [],
            climbsIds: []

        }
    },
    methods: {
          areasEmpty(){
      if(this.areas == '') {
        return true;
      }
      return false;
    },


    selectArea(id){
      if (this.selectedArea == id) {
        this.selectedArea = ''
        this.$store.commit("SET_SELECTED_AREA", null);
        this.$store.commit("SET_SELECTED_CLIMB", null);
        return null;
      }
      if (this.selectedArea == '' || this.selectArea != id) {
        // this.isSelected = true;
        this.selectedArea = id;
        // this.$store.commit("SET_SELECTED_AREA", this.selectedArea);
          areasRoutesService.getAreaDetailsByID(id).then(
            (response) => {
                this.details = response.data;
                this.$store.commit("SET_SELECTED_AREA", this.details);
                this.climbIds = this.details.mp_ids;
                areasRoutesService.getClimbDetailsById(this.climbIds).then(
                    (response) => {
                        console.log(response.data);
                        this.climbs = response.data;
                        this.$store.commit("SET_CLIMBS", this.climbs);
                        this.$store.commit("SET_SELECTED_CLIMB", null);
                  })
            })
        this.selectedArea = id;
        this.isSelectedArea = true;
      }
    },
    }

}

</script>

<style>

</style>