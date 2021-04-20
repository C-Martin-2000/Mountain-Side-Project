<template>
    <div>
        <ul class = "list-group">
            <div id="routes" class="btn-group-vertical" role="group">
            <th> Route Names </th>
                
                <li v-for= "climb in this.$store.state.climbs"
                    :key= "climb"
                    class= "list-group-item">
                    
                        <button id ="button" class= "btn btn-primary" v-on:click= showClimbDetails(climb.name)>{{ climb.name }}</button>
                    
                </li>
                </div>
                    
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
            selectedClimb: '',
            selected: [],
        }
    },
    methods: {
        showClimbDetails(name){
            this.climbs = this.$store.state.climbs;
            this.climbs.forEach(climb => {
                if(climb.name == name) {
                    if(this.$store.state.selectedClimb != null && this.$store.state.selectedClimb[0].name == name) {
                        return this.$store.commit("SET_SELECTED_CLIMB", null);
                    }
                    areasRoutesService.getClimbDetailsById(climb.meta_mp_route_id).then(
                    (response) => {
                        console.log(response.data);
                        this.selectedClimb = response.data;
                        this.$store.commit("SET_SELECTED_CLIMB", this.selectedClimb);
                    })
                }
            });
            
        },
    // created() {
    //     this.$store.commit("SET_SELECTED_CLIMB", null);
    // }
    },
   
        
    
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