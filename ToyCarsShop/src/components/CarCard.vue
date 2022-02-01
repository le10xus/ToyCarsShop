<template>
    <div class="cardBlock">
        <div>
            Model: {{carData.modelName}}
        </div>
        <div>
            Color: {{color}}
        </div>
        <div>
            Type: {{carType}}
        </div>
        <div>
            Price: {{carData.price}}
        </div>
        <button v-on:click="removeCar(carData.id)">del</button>
        <button v-on:click="editCar(carData.id)">edit</button>
    </div>
</template>

<script>
    import axios from 'axios';
    import helper from './helper/helper.js';
    export default {
        name: 'CarData',
        props: { 'carData': Object },
        data() {
            return {
                cars: [],
                color: '',
                carType: ''
            }
        },
        mounted() {
            this.color = helper.getColorById(this.carData.color);
            this.carType = helper.getCarTypeById(this.carData.type);
        },
        methods: {
            removeCar: function (id) {
                const data = {
                    id
                };
                const headers = {
                    "Access-Control-Allow-Origin": "*",
                    "Access-Control-Allow-Methods":"*"
                };
                axios
                    .delete('https://localhost:44357/api/Cars', { data, headers })
                    .then(response => console.log("removed " + id))
                    .catch(error => {
                        console.log(error);
                    });
            },
            editCar: function () {
                axios
                    .delete('https://localhost:44357/api/Cars', { data, headers })
                    .then(response => console.log("removed " + id))
                    .catch(error => {
                        console.log(error);
                    });
            }
        }
    }
</script>
<style>
    .cardBlock {
        display: table;
        height: auto;
        width: auto;
        border: solid blue;
        border-radius: 5px;
        padding: 10px;
        margin: 10px;
    }
</style>