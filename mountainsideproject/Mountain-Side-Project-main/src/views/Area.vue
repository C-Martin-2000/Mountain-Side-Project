<template>
  <area-details id="main" />
</template>

<script>
import AreaDetails from '../components/AreaDetails.vue'
export default {
  components: { AreaDetails },

}
</script>

<style>
#main {
  display: grid;
  grid-template-columns: 15% 45% 45%;
}
</style>