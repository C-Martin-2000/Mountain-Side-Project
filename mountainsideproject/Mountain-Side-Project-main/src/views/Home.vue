<template>
  <div class="home">
    <jumbotron />
    <main>
      <areas-list v-if="this.$store.state.areas.length > 0" />
      <area-details v-if="this.$store.state.selectedArea != null" />
      <climb-details v-if="this.$store.state.selectedClimb != null" /> 
    </main>
  </div>
</template>

<script>
// @ is an alias to /src
import Jumbotron from "../components/Jumbotron.vue";
import AreasList from "../components/AreasList";
import AreaDetails from "../components/AreaDetails";
import ClimbDetails from "../components/ClimbDetails";

export default {
  name: 'Home',
  components: {
    Jumbotron,
    AreasList,
    AreaDetails,
    ClimbDetails
  },
  data() {
    return {
    }
  },
}
</script>

<style>

main{
  display: flex;
  
}

</style>