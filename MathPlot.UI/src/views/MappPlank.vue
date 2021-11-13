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
                            <b-form-input type="number" size="sx-2" id="r" min="0" max="7" v-model="r"></b-form-input>
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
                        <b-button type="button" form="mappingplank" variant="secondary" v-on:click="paintChart">Submit</b-button>
                    </div>
                </b-form>
                <div class="small">
                    <line-chart :chart-data="datacollection" :options="chartOptions "/>
                </div>
                <div class="small" v-if="bifur">
                    <scatter-chart :chart-data="datacollectionb"/>
                </div>
                <div class="small" v-if="pokazlapuniva">
                    <line-chart :chart-data="datacollectionl"/>
                </div>
            </b-col>
            <b-col>               
            </b-col>
        </b-row>
    </b-container>
</template>

<script>
 import LineChart from '../components/LineChart.js'
 import ScatterChart from '../components/ScatterChart.js'
export default{
    components: {
      LineChart,
      ScatterChart,
    },
    data(){
        return{
            r: 0.8,
            lestlameri: false,
            bifur: false,
            pokazlapuniva: false,
            datacollection: null,
            datacollectionb: null,
            datacollectionl: null,
            chartOptions: null,
            x: [],
            y: [],
            ly: [],
            rb: []        
        }
    },
    mounted () {
    },
    methods: {
       f(x){
           return this.r*Math.sin(Math.PI*x)
       },
      getRandomInt () {
        return Math.floor(Math.random() * (50 - 5 + 1)) + 5
      },
      chartMapping(){
          this.x = []
          this.y = []
        for (let i = 0; i < 1; i = i+0.01) {
           this.x.push(i.toFixed(2)) 
           this.y.push(this.f(i))          
        }
          this.datacollection = {
          labels: this.x,
          datasets: [
            {
              label: 'Отображение',
              data: this.y,
              fill: false,
              pointRadius: 0,
               borderColor: 'rgb(139, 0, 0)'
            }, {
              label: 'y=x',
              data: this.x,
              fill: false,
              pointRadius: 0,
              borderColor: 'rgb(0, 0, 0)'
            }
          ]
        }
        this.chartOptions = {
            responsive: true,
            scales: {
                xAxes: [
                    {
                    min: this.x[0],
                    max: this.x[this.x.length-1],
                    ticks: {
                        stepSize: 0.5
                    }
                    }
                ]
            }
        }
      },
      chartBifur(){
          this.rb = []
        for (let i = 0; i < 1; i = i+0.001) {
            this.rb.push(i)           
        }
        var rdn = this.rb[Math.floor(Math.random()*this.rb.length)]
        const nn = this.rb.length
        var xx = []
        var datas = [{x:0,y:0}]
        for (let k = 0; k < nn;k++) {
            xx = [rdn]
            for (let n = 0; n < nn-1; n++) {
                xx.push(this.rb[k]*Math.sin(Math.PI*xx[n]))
                if(n>nn-20){
                    datas.push({x:this.rb[k],y:xx[xx.length-1]})
                }
            }
            
        }
         this.datacollectionb = {
            datasets: [{
                data: datas,
                label: "Бифуракционная Диаграмма",
                borderColor: 'rgb(139, 0, 0)',
                backgroundColor: 'rgb(139, 0, 0)',
                pointRadius: 1
            }]
        }
      },
      chartLyapunov(){
          this.rb = []
          for (let i = 0; i < 1; i = i+0.001) {
            this.rb.push(i)           
         } 
          var summ = []
          for (let j = 0; j < this.rb.length; j++) {
              var sum = 0
              var xl = [0.1]
              var xll = []
              for (let i = 0; i < this.rb.length-1; i++) {
                  xl.push(this.rb[j]*Math.sin(Math.PI*xl[i]))
                  xll.push(Math.log(Math.abs(Math.PI*this.rb[j]*Math.cos(Math.PI*xl[i]))))
              }
              for (let k = 0; k < xll.length; k++) {
                  sum = sum+ xll[k]                  
              }
              summ.push(sum/this.rb.length)
          }
           this.datacollectionl = {
          labels: this.rb,
          datasets: [
            {
              label: 'Показатели Ляпунова',
              data: summ,
              fill: false,
              pointRadius: 0,
              borderColor: 'rgb(139, 0, 0)'
            }
          ]
        }
      },
      paintChart(){
          this.chartMapping()
          if(this.bifur){
              this.chartBifur()
          }
          if(this.pokazlapuniva){
            this.chartLyapunov()
          }
      },
      async paintmapp(){
           const response = await fetch("http://localhost:56063/api/mappingplank",
           {
               method: "POST",
               headers: {"Accept": "application/json", "Content-Type": "application/json"},
               body:JSON.stringify({
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
        }
    }
  
}

</script>

