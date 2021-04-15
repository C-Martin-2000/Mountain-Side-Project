<template>
    <div>
        <table>
            <th> Route Names </th>
                <tr v-for= "climb in climbs"
                    :key= "climb">
                    <button v-on:click= showClimbDetails(climb.name)>{{ climb.name }}</button>
                </tr>
                    <table v-if="show == true">
                            <th> ROUTE NAME </th>
                            <th> RATING </th>
                            <th> TYPE </th>
                        <tr :key = 'selected'>
                            <td> {{ selected.name }} </td>
                            <td> {{ selected.yds }} </td>
                            <td> {{ selected.type }} </td>
                        </tr>
                        <button v-on:click="show =false"> Hide Details </button>
                    </table>
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
            climbs: [],
            selected: [],
            show: false
        }
    },
    methods: {
        showClimbDetails(name){
            this.climbs.forEach(climb => {
                if(climb.name == name) {
                    this.selected = climb;
                    this.show = true;
                }
            });
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