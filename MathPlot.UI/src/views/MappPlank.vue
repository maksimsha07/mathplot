<template>
    <b-container fluid>
        <b-row>
            <b-col>
            </b-col>
            <b-col>
                <h1>Отображение Планка</h1>
                <b-form id="mappingplank">
                    <div class="form-group row" id="modalrowsize">
                        <div class="form-group col-md-6">
                            <label for="r">Значение r в диапазоне (0;7)</label>
                            <b-form-input type="number" size="sx-2" id="r" min="0" max="7" v-model="kofr"></b-form-input>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="lameria">Построить с лестницей Ламерея</label>
                            <b-form-checkbox id="lameria" v-model="lestlameri"></b-form-checkbox>
                        </div>
                    </div>
                    <div class="form-group row" id="modalrowsize">
                        <div class="form-group col-md-6">
                            <label for="bifuraks">Построить бифуркационную диаграмму</label>
                            <b-form-checkbox id="bifuraks" v-model="bifur"></b-form-checkbox>
                        </div>
                        <div class="form-group col-md-6">
                            <label for="lapunov">Построить показатель Ляпунова</label>
                            <b-form-checkbox id="lapunov" v-model="pokazlapuniva"></b-form-checkbox>
                        </div>
                    </div>
                    <div class="form-group row" id="modalrowsize">
                        <b-button type="button" form="mappingplank" variant="secondary" v-on:click="paintmapp()">Submit</b-button>
                    </div>
                </b-form>
                <div>
                    <canvas id="myChart1" width="628" height="400"></canvas>
                </div>
                <canvas id="myChart2" width="628" height="400"></canvas>
                <canvas id="myChart3" width="628" height="400"></canvas>
            </b-col>
            <b-col>               
            </b-col>
        </b-row>
    </b-container>
</template>

<script>
export default{
    data(){
        return{
            kofr: null,
            lestlameri: false,
            bifur: false,
            pokazlapuniva: false
        }
    },
    methods:{
       async paintmapp(){
           const response = await fetch("http://localhost:56063/api/mappingplank",
           {
               method: "POST",
               headers: {"Accept": "application/json", "Content-Type": "application/json"},
               body:({
                    r: Number(this.kofr),
                    lestlameri: this.lestlameri,
                    bifur: this.bifur,
                    pokazlapuniva: this.pokazlapuniva,
                    login: sessionStorage.getItem("login") === null ? null:sessionStorage.getItem("login"),
               })
           });
           if(response.ok === true){
               console.log(response.json());
               console.log(Number(this.kofr) + typeof(Number(this.kofr)))
           }          
        },
        }
    }

</script>

