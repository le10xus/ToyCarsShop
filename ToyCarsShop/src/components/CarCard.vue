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
        <button v-on:click="showCard()">edit</button>
        <edit-card ref="modal" :car-data="dataForEdit"></edit-card>
    </div>
</template>

<script>
    import axios from 'axios';
    import EditCard from './EditCard.vue'
    import helper from './helper/helper.js';
    export default {
        name: 'CarData',
        components: {
            EditCard
        },
        props: { 'carData': Object },
        data() {
            return {
                cars: [],
                color: '',
                carType: '',
                dataForEdit: {}
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
            showCard: function () {
                this.dataForEdit = {
                    model: this.carData.modelName,
                    color: this.color,
                    type: this.carType,
                    price: this.carData.price
                };
                this.$refs.modal.showCard = true;
            }
        }
    }
</script>
<style scoped>
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