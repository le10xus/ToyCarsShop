<template>
    <div v-if="showCard" class="cardShadow" @click.self="closeCard">
        <div class="cardBlock">
            <div>
                Model:
            </div>
            <input v-model="carData.model" />
            <div>
                Color:
            </div>
            <input v-model="carData.color" />
            <div>
                Type:
            </div>
            <input v-model="carData.type" />
            <div>
                Price:
            </div>
            <input v-model="carData.price" />
            <div class="cardFooter">
                <button v-on:click="saveCar(data)">save</button>
                <button v-on:click="()=>{this.showCard = false}">cancel</button>
            </div>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';
    import helper from './helper/helper.js';
    export default {
        name: 'EditCard',
        props: { 'carData': Object },
        data() {
            return {
                showCard: false
            }
        },
        mounted() {
        },
        methods: {
            closeCard: function () {
                this.showCard = false
            },
            saveCar: function () {
                const data = {
                    modelName: this.carData.model,
                    color: this.carData.color,
                    type: this.carData.type,
                    price: this.carData.price
                };
                axios
                    .post('https://localhost:44357/api/Cars', data)
                    .then(response => console.log("update " + id))
                    .catch(error => {
                        console.log(error);
                    });
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
        background:white;
    }
    .cardShadow {
        position: absolute;
        top: 0;
        left: 0;
        min-height: 100%;
        width: 100%;
        background: rgba(0, 0, 0, 0.39);
    }

    .input{
        width:100px;
    }
</style>