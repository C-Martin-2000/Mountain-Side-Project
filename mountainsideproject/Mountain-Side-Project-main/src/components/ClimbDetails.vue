<template>
  <table>
        <th> ROUTE NAME </th>
        <th> RATING </th>
        <th> TYPE </th>
    <tr>
        <td> {{ this.$store.state.selectedClimb[0].name }} </td>
        <td> {{ this.$store.state.selectedClimb[0].yds }} </td>
        <td> {{ this.$store.state.selectedClimb[0].type }} </td>
    </tr>
</table>
</template>

<script>
// import areasRoutesService from "../services/areasRoutesService";
export default {
    name: 'climb-details',
    data() {
        return {
            climbIds: '',
            climb: this.$store.state.selectedClimb[0],
        }
    },
    //  created() {
    //     console.log("here");
    //             areasRoutesService.getClimbDetailsById(this.$store.state.selectedClimb.meta_mp_route_id).then(
    //                 (response) => {
    //                     console.log(response.data);
    //                     this.climb = response.data;
    //                 }
    //             )
    //         }
}
</script>

<style>

</style>