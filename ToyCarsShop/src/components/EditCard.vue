<template>
    <!--<div v-if="showCard" class="cardShadow" @click.self="closeCard">-->
    <div class="cardBlock">
        <div>
            Model:
        </div>
        <input v-model="carData.modelName" :disabled="editCard === false" />
        <div>
            Color:
        </div>
        <!--<input v-model="color" disabled="editCard === false" />-->
        <select class="selectItem" id="carColorList" :disabled="editCard === false">
            <option v-for="(index, color) in colorList" :selected="carColor === color" :value="index">{{color}}</option>
        </select>
        <div>
            Type:
        </div>
        <select class="selectItem" id="carTypesList" :disabled="editCard === false">
            <option v-for="(index, type) in typeList" :selected="carType === type" :value="index">{{type}}</option>
        </select>

        <div>
            Price:
        </div>
        <input v-model="carData.price" :disabled="editCard === false" />

        <div class="cardFooter">
            <button v-if="!editCard" class="footerButton editButton" v-on:click="()=>{this.editCard = true}">edit</button>
            <div v-if="editCard">
                <button class="footerButton" v-on:click="saveCar(data)">save</button>
                <button class="footerButton" v-on:click="()=>{this.editCard = false}">cancel</button>
            </div>
        </div>
    </div>
    <!--</div>-->
</template>

<script>
    import axios from 'axios';
    import helper from './helper/helper.js';
    export default {
        name: 'EditCard',
        props: { 'carData': Object },
        data() {
            return {
                editCard: false,
                carColor: '',
                carType: '',
                typeList: {},
                colorList: {},
                type: '',
                index: ''
            }
        },
        created() {
            this.typeList = helper.CarTypeEnum;
            this.colorList = helper.ColorEnum;
        },
        mounted() {
            this.carColor = helper.getColorById(this.carData.colorId);
            this.carType = helper.getCarTypeById(this.carData.typeId);
        },
        methods: {
            closeCard: function () {
                this.editCard = false
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
        border: solid lightgray;
        border-radius: 5px;
        padding: 10px;
        margin: 10px;
        background: white;
    }

    .cardShadow {
        position: absolute;
        top: 0;
        left: 0;
        min-height: 100%;
        width: 100%;
        background: rgba(0, 0, 0, 0.39);
    }

    .input {
        width: 100px;
    }

    .selectItem {
        width: 100%;
        height: 25px;
    }

    .footerButton {
        margin: 5px;
        border-radius: 10px;
        padding: 5px;
        border: none;
        background: lightgray;
    }

    .editButton {
        float: right;
    }
</style>