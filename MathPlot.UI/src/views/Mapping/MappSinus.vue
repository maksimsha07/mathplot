<template>
    <b-container fluid>
        <b-row>
            <b-col>
            </b-col>
            <b-col>
                <h1>Отображение синус</h1>
                <b-form id="mappingplank">
                    <div class="form-group row" id="modalrowsize">
                        <div class="form-group col-md-12">
                            <label for="r">Значение r в диапазоне (0;1)</label>
                            <b-form-input type="number" size="sx-2" id="r" min="0" max="1" v-model="r"></b-form-input>
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
                    <b-button v-if="datacollection != null && autorize" type="button" variant="secondary" style="margin-left: 5px" v-on:click="paintmapp('chart')">Сохранить</b-button>
                </div>
                <div class="small" v-if="bifur">
                    <scatter-chart :chart-data="datacollectionb" id="chartb" ref='chartb'/>
                    <b-button v-if="datacollectionb != null"  type="button" variant="secondary" v-on:click="downloadChartPng('chartb')">Скачать</b-button>
                    <b-button v-if="datacollectionb != null && autorize" type="button" variant="secondary" style="margin-left: 5px" v-on:click="paintmapp('chartb')">Сохранить</b-button>
                </div>
                <div class="small" v-if="pokazlapuniva">
                    <line-chart :chart-data="datacollectionl" :options="chartOptionsl" ref='chartl'/>
                    <b-button v-if="datacollectionl != null"  type="button" variant="secondary" v-on:click="downloadChartPng('chartl')">Скачать</b-button>
                    <b-button v-if="datacollectionl != null && autorize" type="button" variant="secondary" style="margin-left: 5px" v-on:click="paintmapp('chartl')">Сохранить</b-button>
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
             r: 0.8,
            rMax:1,
            rmin: 0,
            xMax: 1,
            xMin: 0,
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
            rb: [],
            autorize: sessionStorage.getItem("login") === null ? false:true,         
        }
    },
    mounted () {
    },
    methods: {
       f(x){
           return this.r*Math.sin(Math.PI*x)
       },
       fr(x,r){
            return r*Math.sin(Math.PI*x)
       },
       fDiff(x,r){
           return Math.log(Math.abs(Math.PI*r*Math.cos(Math.PI*x)))
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
        for (let i = this.rmin; i < this.rMax; i = i+0.001) {
            this.rb.push(i.toFixed(2))           
        }
        var rdn = this.rb[Math.floor(Math.random()*this.rb.length)]
        const nn = this.rb.length
        var xx = []
        var datas = [{x:0,y:0}]
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
          this.rb = []
          for (let i = this.rmin; i < this.rMax; i = i+0.001) {
            this.rb.push(i.toFixed(2))           
         } 
          var summ = [] 
          for (let j = 0; j < this.rb.length; j++) {
              var sum = 0
              var xl = [0.1]
              var xll = []
              for (let i = 0; i < this.rb.length-1; i++) {
                  xl.push(this.fr(xl[i],this.rb[j]))
                  xll.push(this.fDiff(xl[i],this.rb[j]))
                  sum = sum+ xll[i] 
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
      async paintmapp(ref){
          const component = this.$refs[ref] 
            const canvas = component.$refs.canvas
            var image = canvas.toDataURL("image/png").replace("image/png", "image/octet-stream");
            var blobBin = atob(image.split(',')[1]);
            var array = [];
            for(var i = 0; i < blobBin.length; i++) {
                array.push(blobBin.charCodeAt(i));
            }
            var file=new File([new Uint8Array(array)],"mappingSinus.png",{type: 'image/png'});
            let formdata = new FormData()
            formdata.append('r',this.r)
            formdata.append('bifur',this.bifur)
            formdata.append('pokazlapuniva',this.pokazlapuniva)
            formdata.append('login',sessionStorage.getItem("login"))
            formdata.append('file',file)
           const response = await fetch("http://localhost:56063/api/mappingsinus",
           {
               method: "POST",
               body: formdata
           });
           if(response.ok === true){
               console.log(response);
           }      
           else{
                console.log(response.status, response.statusText);
            }    
        }
    }
  
}

</script>

