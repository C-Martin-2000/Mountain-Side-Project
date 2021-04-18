<template>

  <main>


    <div class = "jumbotron">
      <h1>
      Welcome to the mountain-side-project, an inferior app for bad climbers.
      </h1>  
        <h5> To start finding climbing areas near you, enter a radius in km to search </h5>
          <input type="text" v-model="radius"/>
          <button class="btn btn-primary" v-on:click="getTheStuff()"> GO FIND IT </button>
    </div>




    <div id = "Areas">
      <table v-if="areasEmpty() == false">
        <h2>  Areas </h2>
          <tr
            v-for= "area in areas"
            :key= "area.meta_mp_sector_id"
            
          >
            <button class="areaButton" v-on:click="selectArea(area.meta_mp_sector_id)"> {{ area.meta_parent_sector }}</button>
          </tr>
      </table>
        
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
                <th> Route Names </th>
                
                  <li v-for= "climb in climbs" 
                    :key= "climb"
                    class= "list-group-item">
                    
                    <button id ="button" class= "btn btn-primary" v-on:click= showClimbDetails(climb.name)>{{ climb.name }}</button>
                  </li>
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
    showSelectedClimb: false
    }
  },
  created() {
          navigator.geolocation.getCurrentPosition(
            position => {
            console.log(position.coords.latitude);
            this.userLat = position.coords.latitude;
            console.log(position.coords.longitude);
            this.userLong = position.coords.longitude;
            },
            error => {
              console.log(error.message);
            }
          );
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
        this.isSelectedArea = false;
        return this.selectedArea = '';
      }
      if (this.selectedArea == '' || this.selectArea != id) {
        this.isSelected = true;
          areasRoutesService.getAreaDetailsByID(id).then(
            (response) => {
                this.details = response.data;
                this.climbIds = this.details.mp_ids;
                areasRoutesService.getClimbDetailsById(this.climbIds).then(
                    (response) => {
                        console.log(response.data);
                        this.climbs = response.data;
                  })
            })
        this.selectedArea = id;
        this.isSelectedArea = true;
      }
    },


    showDetails() {
      if(this.climbs != '') {
        return true;
      }
      return false;
    }, 

    getTheStuff() {
      console.log(this.userLat);
      console.log(this.userLong);
      console.log(this.radius);
      areasRoutesService.getStuffNearMe(this.userLat, this.userLong, this.radius).then(
      (response) => {
        this.areas = response.data;
        console.log(response.data);
      })
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

#Areas {
  display: grid;
  grid-template-columns: 20% 40% 40%;

}
.areaButton {
 margin: 2px;
 color: black;
 width:100%;
 background: white;
}
#detailsButton {
  height: 10%;
}
.selected {
  background: blue;
}


</style>