<template>
    <div>
        Get Car data in component:
        <button 
            :click="getCars">
            Get cars
        </button>
        <div v-for="car in cars">
            <CarCard carData="car"/>
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
                debugger;
                axios
                    .get('https://localhost:44357/api/Cars')
                    .then(response => { this.cars = response.data });
            }
        }
    }
</script>