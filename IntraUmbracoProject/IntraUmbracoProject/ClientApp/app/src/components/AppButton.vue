<template>
    <button :class="styleClass" :id="buttonId"  :type="type"> {{ buttonText }}</button> <!---@click="buttonAction"-->
</template>
  
<script>
export default {
    name: 'AppButton',
    props: {
        buttonId: String,
        buttonText: String,
        // buttonAction: Function,
        styleClass: Array,
            default: function() {
                return ['btn']
            },
        type: {
            type: String,
            default: 'button'
        },
    },
    data() {
        // return {
        //     shouldBeClickable: false /** TODO If all req fields are filled in */
        // };
    },
    mounted() {
    },
    beforeUnmount() {
    },
    methods: {
    }
}
</script>
  
<style scoped>
</style>