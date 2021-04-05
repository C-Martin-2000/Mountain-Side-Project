<template>
    <div>
        <table>
            <th> Route Names </th>
                <tr v-for="route in climbIds" :key="route">
                    <button v-on:click="showClimbDetails(route)" />
    </div>
  
</template>

<script>
export default {
    name: 'climbs-list',
    props:{
        climbIds: {
            type: Array
        }
    }

}
</script>

<style>

</style>