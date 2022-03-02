<template>
    <div>
        <div v-if="!dataLoaded">Loading...</div>
        <div v-else="dataLoaded" class="cardsTable">
            <div v-for="car in cars.data">
                <EditCard 
                          :car-data="car"
                          :type-list="types.data"
                          :color-list="colors.data"/>
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
        },
        methods: {
            getCars: async function () {
                try {
                    this.cars = await axios
                        .get('https://localhost:44357/api/Cars');
                    this.colors = await axios
                        .get('https://localhost:44357/api/CarColors/');
                    this.types = await axios
                        .get('https://localhost:44357/api/CarTypes/');

                } catch (e) {
                    console.log(e);
                } finally {
                    this.dataLoaded = true;
                }
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