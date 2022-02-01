<template>
    <div>
        Get Car data in component:
        <button 
            v-on:click="getCars">
            Get cars
        </button>
        <div class="cardsTable">
            <div v-for="car in cars">
                <CarCard :car-data="car" />
            </div>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';
    import CarCard from './CarCard.vue';
    export default {
        name: "CarData",
        components: { 
            CarCard
        },
        data() {
            return {
                cars: []
            }
        },
        methods: {
            getCars: function () {
                axios
                    .get('https://localhost:44357/api/Cars')
                    .then(response => { this.cars = response.data });
            }
        }
    }
</script>
<style>
    .cardsTable{
        display:flex;
    }
</style>