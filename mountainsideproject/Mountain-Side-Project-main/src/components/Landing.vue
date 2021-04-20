<template>

  <main>






   
        
        <!-- <area-details v-if="showDetails() == true" v-bind:selectedArea = 'selectedArea' :key="selectedArea"/> -->




      <div v-if="isSelectedArea == true" id = "areaDetails">

        <h2>{{ details.meta_parent_sector }}</h2>
          <table>
            <tr>
              <th>LATITUDE</th>
              <th>LONGITUDE</th>
              <th>NUMBER OF ROUTES</th>
            </tr>
            <tr>
              <td> {{ details.lat }} </td>
              <td> {{ details.lng }} </td>
              <td> {{ details.count }} </td>
             </tr>
          </table>


          <div id = "climbsList">
              <!-- <climbs-list v-bind:climbIds = 'climbIds' :key= "climbIds" /> -->
            <ul class = "list-group">

              <div id="routes" class="btn-group-vertical" role="group">
                <th> Routes </th>
                  <table>
                    <button id="filterButton">Boulder</button>
                    <button id="filterButton">Top Rope</button>
                    <button id="filterButton">Sport</button>
                    <button id="filterButton">Trad</button>
                   
                    <tr v-for= "climb in filteredClimbs" 
                      :key= "climb"
                      class= "list-group-item">
                    
                    <button id ="button" class= "btn btn-primary" v-on:click= showClimbDetails(climb.name)>{{ climb.name }} {{ climb.yds }} </button>
                    
                    <!-- <td>rating {{climb.yds}}</td> -->
                  </tr>
                  </table>
              </div>
            </ul>
          </div>
      </div>



      <div v-if="showSelectedClimb == true">
        <h2> {{selected.name}} </h2>
          <table>
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
      </div>  

      
    </div>
  </main>
</template>

<script>
import areasRoutesService from "../services/areasRoutesService";

// import AreaDetails from './AreaDetails.vue';
export default {

  // components:
  // {AreaDetails},
  name: 'Landing',
  data() {
    return {
    selectedArea: '',
    areas: [],
    userLat:'',
    userLong:'',
    radius:'',
    details: '',
    climbIds: '',
    show: false,
    selected: [],
    climbs: [],
    isSelectedArea: false,
    showSelectedClimb: false,
    filteredClimbs:[]
    }
  },

 

  // computed: {
  //   filteredClimbs() {
  //     let filter = new 
  //   }  // },]

  methods: {

  


    showDetails() {
      if(this.climbs != '') {
        return true;
      }
      return false;
    }, 

    


    showClimbDetails(name) {
      this.climbs.forEach(climb => {
        if(climb.name == name) {
          if(this.selected == climb) {
            this.selected = '';
            return this.showSelectedClimb = false;
          }
          this.selected = climb;
          this.showSelectedClimb = true;
        }
      });
    }

  }
}

</script>

<style>


</style>