<template>
    <div>
        <div class="intro" v-on:scroll="handleScroll">
        </div>
        <div>
            sfsdfsfs
        </div>
    </div>
</template>

<script>
export default {
    data(){
        return{
            i: 110
        }
    },
    created () {
    window.addEventListener('scroll', this.handleScroll);
    },
    destroyed () {
        window.removeEventListener('scroll', this.handleScroll);
    },
    methods:{
        handleScroll(){
            var b = document.querySelector(".intro")
            if (window.scrollY < 50) {
                b.style.backgroundSize = this.i +"%"
                this.i = this.i +1
                console.log(this.i)
                
            }
        }
    }
}
</script>
<style>
.intro{
    width: 100%;
    height: 100vh;
    background: url("../assets/intro1.jpg") center no-repeat;
    background-size: 110%;
}
</style>