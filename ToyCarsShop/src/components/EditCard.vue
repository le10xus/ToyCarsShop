<template>
    <div class="cardBlock">
        <div>
            Model:
        </div>
        <input v-model="carData.carModel" :readonly="editCard === false" />
        <div>
            Color:
        </div>
        <select v-if="editCard" class="selectItem" id="carColorList" v-model="colorProperty.colorValue" name="colorValue">
            <option v-for="(index, color) in colorList" v-bind:value="index.colorId">{{index.colorName}}</option>
        </select>
        <input v-else v-model="carColor" readonly />
        <div>
            Type:
        </div>
        <select v-if="editCard" class="selectItem" id="carTypesList" v-model="typeProperty.typeValue" name="typeValue">
            <option v-for="(index, type) in typeList" v-bind:value="index.typeId">{{index.typeName}}</option>
        </select>
        <input v-else v-model="carType" readonly />
        <div>
            Price:
        </div>
        <input v-model="carData.price" :readonly="editCard === false" />

        <div class="cardFooter">
            <button v-if="!editCard" class="footerButton viewButton" v-on:click="()=>{}">view</button>
            <button v-if="!editCard" class="footerButton editButton" v-on:click="()=>{this.editCard = true}">edit</button>
            <div v-if="editCard">
                <button class="footerButton" v-on:click="saveCar(data)">save</button>
                <button class="footerButton" v-on:click="()=>{this.editCard = false}">cancel</button>
            </div>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';
    export default {
        name: 'EditCard',
        props: {
            'carData': Object,
            'typeList': Array,
            'colorList': Array
        },
        data() {
            return {
                colorProperty: {
                    colorValue: ''
                },
                typeProperty: {
                    typeValue: ''
                },
                editCard: false,
                carColor: '',
                carType: '',
                type: '',
                index: ''
            }
        },
        mounted() {            
            this.carColor = this.carData.color;
            this.carType = this.carData.type;

            this.colorProperty.colorValue = this.colorList.find(x => x.colorName === this.carColor)?.colorId;
            this.typeProperty.typeValue = this.typeList.find(x => x.typeName === this.carType)?.typeId;
        },
        computed() {
            //this.colorProperty.colorName = this.colorList.find(x => x.colorId === this.colorProperty.colorValue)?.colorName;
            //this.typeProperty.typeName = this.typeList.find(x => x.typeId === this.typeProperty.typeValue)?.typeName;
        },
        methods: {
            closeCard: function () {
                this.editCard = false
            },
            getCar: function () {
                axios
                    .get('https://localhost:44357/api/Cars/' + this.carData.id)
                    .then(response => console.log(response))
                    .catch(error => {
                        console.log(error);
                    });
            },

            saveCar: function () {
                const data = {
                    id: this.carData.id,
                    carModel: this.carData.carModel,
                    color: this.colorList.find(x => x.colorId === this.colorProperty.colorValue)?.colorName,
                    type: this.typeList.find(x => x.typeId === this.typeProperty.typeValue)?.typeName,
                    price: this.carData.price
                };

                axios
                    .put('https://localhost:44357/api/Cars/' + data.id, data)
                    .then(response => {console.log("update " + id)})
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

    .viewButton{
        float: left;
    }

    .editButton {
        float: right;
    }
</style>