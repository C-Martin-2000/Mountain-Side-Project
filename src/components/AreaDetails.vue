
<template>
  <div>
      
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
        details: ''
        }
    },
    created() {
        areasRoutesService.getAreaDetailsByID(this.selectedArea).then(
            (response) => {
                this.details = response.data;
            }
        )}
}


</script>

<style>

</style>