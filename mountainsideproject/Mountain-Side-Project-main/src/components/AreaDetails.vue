
<template>
  <div id = "climbs">
      <h1>DETAILS</h1>
      <table>
          <tr>
          <th>AREA NAME</th>
          <th>LATITUDE</th>
          <th>LONGITUDE</th>
          <th>NUMBER OF ROUTES</th>
          </tr>
          <tr>
          <td> {{ this.$store.state.selectedArea.meta_parent_sector }} </td>
          <td> {{ this.$store.state.selectedArea.lat }} </td>
          <td> {{ this.$store.state.selectedArea.lng }} </td>
          <td> {{ this.$store.state.selectedArea.count }} </td>
          </tr>
      </table>
        <div>
            <climbs-list />
        </div>  

  </div>
</template>

<script>
// import areasRoutesService from "../services/areasRoutesService";
import ClimbsList from "./ClimbsList.vue";

export default {
    components: {ClimbsList},
    name: "area-details", 
    // props:{
    //     selectedArea: {
    //         type: String
    //     }
    // },
    data() {
        return {
        details: '',
        climbIds: ''
        }
    },
    // created() {
    //     areasRoutesService.getAreaDetailsByID(this.$store.state.selectedArea).then(
    //         (response) => {
    //             this.details = response.data;
    //             // this.climbIds = this.details.mp_ids.split('|');
    //             this.climbIds = this.details.mp_ids;
    //         }
    //     )
    //     this.hideDetails = false;
    //     }
    // created() {
    //     this.climbIds = this.details.mp_ids.split('|');
    //     }
    // updated() {
    //      this.climbIds = this.details.mp_ids.split('|');
    // }

}

</script>

<style>
#climbs {
    margin: 10px;
}

</style>