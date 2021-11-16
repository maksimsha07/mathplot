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
                    <line-chart :chart-data="datacollection" :options="chartOptions" ref='chart'/>                  
                    <b-button v-if="datacollection != null"  type="button" variant="secondary" v-on:click="downloadChartPng('chart')">Скачать</b-button>
                    <b-button v-if="datacollection != null" type="button" variant="secondary" style="margin-left: 5px">Сохранить</b-button>
                </div>
                <div class="small" v-if="bifur">
                    <scatter-chart :chart-data="datacollectionb" id="chartb" ref='chartb'/>
                    <b-button v-if="datacollectionb != null"  type="button" variant="secondary" v-on:click="downloadChartPng('chartb')">Скачать</b-button>
                    <b-button v-if="datacollectionb != null" type="button" variant="secondary" style="margin-left: 5px">Сохранить</b-button>
                </div>
                <div class="small" v-if="pokazlapuniva">
                    <line-chart :chart-data="datacollectionl" :options="chartOptionsl" ref='chartl'/>
                    <b-button v-if="datacollectionl != null"  type="button" variant="secondary" v-on:click="downloadChartPng('chartl')">Скачать</b-button>
                    <b-button v-if="datacollectionl != null" type="button" variant="secondary" style="margin-left: 5px">Сохранить</b-button>
                </div>
            </b-col>
            <b-col>               
            </b-col>
        </b-row>
    </b-container>
</template>

<script>
 import LineChart from '../../components/MoreChart/LineChart.js'
 import ScatterChart from '../../components/MoreChart/ScatterChart.js'
export default{
    components: {
      LineChart,
      ScatterChart,
    },
    data(){
        return{
            r: 4,
            rMax:7,
            rmin: 1,
            xMax: 5,
            xMin: 0,
            lestlameri: false,
            bifur: false,
            pokazlapuniva: false,
            datacollection: null,
            datacollectionb: null,
            datacollectionl: null,
            chartOptions: null,
            chartOptionsl: null,
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
           return (this.r*Math.pow(x,3))/(1+Math.exp(x))
       },
       fr(x,r){
            return (r*Math.pow(x,3))/(1+Math.exp(x))
       },
       fDiff(x,r){
           return Math.log(Math.abs((r*Math.pow(x,2)*((x-3)*Math.exp(x)-3))/(Math.pow((1+Math.exp(x)),2))))
       },
      chartMapping(){
          this.x = []
          this.y = []
        for (let i = this.xMin; i < this.xMax; i = i+0.01) {
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
        for (let i = this.rmin; i < this.rMax; i = i+0.01) {
            this.rb.push(i.toFixed(2))           
        }
        var rdn = this.rb[Math.floor(Math.random()*this.rb.length)]
        const nn = this.rb.length
        var xx = []
        var datas = [{x:1,y:1}]
        for (let k = 0; k < nn;k++) {
            xx = [rdn]
            for (let n = 0; n < nn-1; n++) {
                xx.push(this.fr(xx[n],this.rb[k]))
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
          const start= new Date().getTime();
          this.rb = []
          for (let i = this.rmin; i < this.rMax; i = i+0.01) {
            this.rb.push(i.toFixed(2))           
         } 
          var summ = [] 
          for (let j = 0; j < this.rb.length; j++) {
              var sum = 0
              var xl = [2.0]
              var xll = []
              for (let i = 0; i < this.rb.length-1; i++) {
                  xl.push(this.fr(xl[i],this.rb[j]))
                  xll.push(this.fDiff(xl[i],this.rb[j]))
                  sum = sum+ xll[i] 
              }
              summ.push(sum/this.rb.length)
          }
          console.log(xl)
          console.log(xll)
          const end = new Date().getTime();
          console.log(end-start);
           this.datacollectionl = {
          labels: this.rb,
          datasets: [
            {
              label: 'Показатели Ляпунова',
              data: summ,
              fill: false,
              pointRadius: 0,
              borderColor: 'rgb(139, 0, 0)',
              borderWidth: 1,
            }
          ]
        }
        this.chartOptionsl = {
            responsive: true,
            scales: {
               yAxes: [{
                gridLines: {
                    display: true
                },
                ticks: {   
                    min: -1,     
                }
                
                }]
            }
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
      downloadChartPng(ref){
        const component = this.$refs[ref] 
        const canvas = component.$refs.canvas
        var dataURL = canvas.toDataURL("image/png")
        var link = document.createElement("a")
        link.href = dataURL
        link.download = "my-image-name.png";
        link.click();
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

