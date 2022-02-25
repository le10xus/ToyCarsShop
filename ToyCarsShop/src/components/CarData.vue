<template>
    <div>
        <div v-if="!dataLoaded">Loading...</div>
        <div v-else="dataLoaded" class="cardsTable">
            <div v-for="car in cars">
                <EditCard 
                          :car-data="car"
                          :type-list="types"
                          :color-list="colors"/>
            </div>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';
    import CarCard from './CarCard.vue';
    import EditCard from './EditCard.vue';
    export default {
        name: "CarData",
        components: { 
            CarCard,
            EditCard
        },
        data() {
            return {
                cars: [],
                dataLoaded: false,
                types: [],
                colors: []
            }
        },
        mounted() {
            this.getCars();
            this.getColor();
            this.getType();
        },
        methods: {
            getCars: function () {
                axios
                    .get('https://localhost:44357/api/Cars')
                    .then(response => {
                        this.cars = response.data;
                        this.dataLoaded = true;
                    });
            },
            getColor: function () {
                axios
                    .get('https://localhost:44357/api/CarColors/')
                    .then(response => this.colors = response.data)
                    .catch(error => {
                        console.log(error);
                    });
            },
            getType: function () {
                axios
                    .get('https://localhost:44357/api/CarTypes/')
                    .then(response => this.types = response.data)
                    .catch(error => {
                        console.log(error);
                    });
            },
        }
    }
</script>
<style>
    .cardsTable{
        display:flex;
    }
</style>