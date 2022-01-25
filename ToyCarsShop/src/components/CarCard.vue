<template>
    <div>
        <div>
            Model: {{carData.modelName}}
        </div>
        <div>
            Color: {{carData.color}}
        </div>
        <div>
            Type: {{carData.type}}
        </div>
        <div>
            Price: {{carData.price}}
        </div>
    </div>
</template>

<script>
    export default {
        name: "CarData",
        properties: {
            carData: {}
        },
        data() {
            return {
                cars: []
            }
        },
        mounted: function () {
            debugger;
        },
        methods: {

        }
    }
</script>