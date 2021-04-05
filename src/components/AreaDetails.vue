
<template>
  <div>
      <h1>DETAILS</h1>
      <table>
          <tr>
          <th>AREA NAME</th>
          <th>LATITUDE</th>
          <th>LONGITUDE</th>
          <th>NUMBER OF ROUTES</th>
          </tr>
          <tr>
          <td> {{ details.meta_parent_sector }} </td>
          <td> {{ details.lat }} </td>
          <td> {{ details.lng }} </td>
          <td> {{ details.count }} </td>
          </tr>
      </table>
        <!-- <div>
        <climbs-list v-bind:climbIds = 'climbIds' />
        </div>   -->

  </div>
</template>

<script>
import areasRoutesService from "../services/areasRoutesService";

export default {
    name: "area-details", 
    props:{
        selectedArea: {
            type: String
        }
    },
    data() {
        return {
        details: '',
        climbIds: ''
        }
    },
    created() {
        areasRoutesService.getAreaDetailsByID(this.selectedArea).then(
            (response) => {
                this.details = response.data;
            }
        )},
    updated() {
         this.climbIds = this.details.mp_ids.split('|');
    }
}

</script>

<style>

</style>