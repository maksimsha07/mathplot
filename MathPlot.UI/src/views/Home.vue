<template>
    <div>
        <div class="intro" v-on:scroll="handleScroll">
        </div>
        <div id="mainInfo">
            <b-container id="cardContainer">
                <b-row>
                    <b-col id="parentsCardOne">
                        <h2 style="padding:25%">Логистическое отображение</h2>
                    </b-col>
                    <b-col id="parentsCardTwo">
                        <div style="padding:15%">
                            <p id="maintext">Логистическое отображение, это отображение вида <vue-mathjax :formula='"$$x_{n+1}=rx_n(1-x_n) $$"'></vue-mathjax> которое описывает
                                как меняется численность популяции с течением времени. Одно из
                                очень простых нелинейных уравнений в котором может появится сложное
                                хаотическое поведение.
                            </p>
                        </div>
                    </b-col>
                </b-row>
            </b-container>
            <b-container id="cardContainer">
                <b-row>
                    <b-col id="parentsCardTwo">
                        <div style="padding:15%">
                            <p id="maintext"> Отображение синус это отображение вида<vue-mathjax :formula='"$$x_{n+1}=r \\cdot sin(\\pi x_n) $$"'></vue-mathjax>б
                            по свойства оно очень похоже на логистическое отображение, но все же обладает своими особенностями
                            </p>
                        </div>
                    </b-col>
                    <b-col id="parentsCardOne">
                        <h2 style="padding:25%">Отображение синус</h2>
                    </b-col>
                </b-row>
            </b-container>
            <b-container id="cardContainer">
                <b-row>
                    <b-col id="parentsCardOne">
                        <h2 style="padding:25%">Отображение Гаусса</h2>
                    </b-col>
                    <b-col id="parentsCardTwo">
                        <div style="padding:15%">
                            <p id="maintext">Отображение Гаусса это отображение вида
                                <vue-mathjax :formula='"$$x_{n+1}=e^{-ax_n^2}+r $$"'></vue-mathjax>
                                очередное отображение, просто красивое
                            </p>
                        </div>
                    </b-col>
                </b-row>
            </b-container>
            <b-container id="cardContainer">
                <b-row>
                    <b-col id="parentsCardTwo">
                        <div style="padding:15%">
                            <p id="maintext">Очень нетипичное отображение, ее бифуркационная диаграмма
                                отличается от остальных <vue-mathjax :formula='"$$x_{n+1}=\\frac{rx_n}{1+x_n^3} $$"'></vue-mathjax>
                            </p>
                        </div>
                    </b-col>
                     <b-col id="parentsCardOne">
                        <h2 style="padding:25%">Двусторонее отображение</h2>
                    </b-col>
                </b-row>
            </b-container>
            <b-container id="cardContainer">
                <b-row>
                    <b-col id="parentsCardOne">
                        <h2 style="padding:25%">Отображение Планка </h2>
                    </b-col>
                    <b-col id="parentsCardTwo">
                        <div style="padding:15%">
                            <p id="maintext">Это отображение названо в честь величайшего физика лишь
                                потому, что функция, отвечающая отображению, напоминает формулу Планка. Но только
                                напоминает..
                                <vue-mathjax :formula='"$$x_{n+1}=\\frac{rx_n^3}{1+e^{x_n}}$$"'></vue-mathjax>
                            </p>
                        </div>
                    </b-col>
                </b-row>
            </b-container>
        </div>
    </div>
</template>

<script>
import {VueMathjax} from 'vue-mathjax'
export default {
    components: {
        'vue-mathjax': VueMathjax
    },
    data(){
        return{
            i: 100
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
            if (this.i<140) {
                b.style.backgroundSize = this.i +"%"
                this.i = this.i +0.3
                
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
    background-size: cover;
}
#cardContainer{
    position: relative;
    top: -100px;
}
</style>