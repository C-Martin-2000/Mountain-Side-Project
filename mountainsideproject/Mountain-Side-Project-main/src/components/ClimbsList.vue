<template>
    <div>
        <ul class = "list-group">
            <div id="routes" class="btn-group-vertical" role="group">
            <th> Route Names </th>
                
                <li v-for= "climb in climbs"
                    :key= "climb"
                    class= "list-group-item">
                    
                        <button id ="button" class= "btn btn-primary" v-on:click= showClimbDetails(climb.name)>{{ climb.name }}</button>
                    
                </li>
                </div>
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
        </ul>
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
    #routes {
        display:flex;
        align-items: center;
        width: 50%;
    }

    #button {
        width:100%;
        margin: 0%;
        border: 0%;
    }
    .list-group-item {
        width:100%;
        margin: 0%;
        border: 0%;
        padding: 5px 5px 5px 5px;
    }
    .list-group {
        align-items: center;
        overflow-y:auto;
    }
</style>