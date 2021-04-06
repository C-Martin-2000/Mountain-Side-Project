<template>
    <div>
        <table>
            <th> Route Names </th>
                <tr v-for= "climb in climbs"
                    :key= "climb">
                    <button>{{ climb.name }}</button>
                    </tr>
        </table>
    </div>
  
</template>

<script>

import areasRoutesService from "../services/areasRoutesService";

export default {
    name: 'climbs-list',
    props:{
        climbIds: {
            type: String
        }
    },
    data() {
        return {
            climbs: []
        }
    },
    created() {
        console.log("here");
                areasRoutesService.getClimbDetailsById(this.climbIds).then(
                    (response) => {
                        console.log(response.data);
                        this.climbs = response.data;
                    }
                )
            }
        
    
}
</script>

<style>

</style>