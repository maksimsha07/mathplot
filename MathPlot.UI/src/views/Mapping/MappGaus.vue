<template>
    <b-container fluid id="mainMappingInfo">
        <b-row>
            <b-col>
            </b-col>
            <b-col cols="8" id="mappingActiv">
                <div style="padding: 50px">
                    <h1 >Отображение Гаусса</h1>
                    <b-form id="mappingplank">
                        <div class="form-group row" id="modalrowsize">
                            <div class="form-group col-md-6">
                                <label for="r">Значение r в диапазоне (-1;1)</label>
                                <b-form-input type="number" size="sx-2" id="r" min="-1" max="1" v-model="r" style="width:60px; position: relative; left: 43%"></b-form-input>
                            </div>
                            <div class="form-group col-md-6">
                                <label for="bifuraks">Построить бифуркационную диаграмму</label>
                                <b-form-checkbox id="bifuraks" v-model="bifur"></b-form-checkbox>
                                <label for="lapunov">Построить показатель Ляпунова</label>
                                <b-form-checkbox id="lapunov" v-model="pokazlapuniva"></b-form-checkbox>
                            </div>
                        </div>
                        <div class="form-group row" id="modalrowsize">
                            <div class="form-group col-md-5">
                            </div>
                            <div class="form-group col-md-2">
                                <b-button type="button" form="mappingplank" v-on:click="paintChart">Построить</b-button>
                            </div>
                            <div class="form-group col-md-5">
                                
                            </div>
                        </div>
                    </b-form>
                </div>
               <div >
                    <line-chart  class="mapp" id="chart" :chart-data="datacollection" :options="chartOptions" ref='chart'/>                  
                    <b-button v-if="datacollection != null"  type="button" variant="secondary" v-on:click="downloadChartPng('chart')">Скачать</b-button>
                    <b-button v-if="datacollection != null && autorize" type="button" variant="secondary" style="margin-left: 5px" v-on:click="paintmapp('chart')">Сохранить</b-button>
                </div>
                <div  v-if="bifur">
                    <scatter-chart class="mapp" :chart-data="datacollectionb" :options="chartOptionsb" id="chartb" ref='chartb'/>
                    <b-button v-if="datacollectionb != null"  type="button" variant="secondary" v-on:click="downloadChartPng('chartb')">Скачать</b-button>
                    <b-button v-if="datacollectionb != null && autorize" type="button" variant="secondary" style="margin-left: 5px" v-on:click="paintmapp('chartb')">Сохранить</b-button>
                </div>
                <div  v-if="pokazlapuniva">
                    <line-chart class="mapp" :chart-data="datacollectionl" :options="chartOptionsl" ref='chartl'/>
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
             r: -0.5,
            rMax: 1.0,
            rmin: 0,
            xMax: 1,
            xMin: 0,
            lestlameri: false,
            bifur: false,
            pokazlapuniva: false,
            datacollection: null,
            datacollectionb: null,
            datacollectionl: null,
            chartOptions: null,
            chartOptionsl: null,
            chartOptionsb: null,
            x: [],
            y: [],
            ly: [],
            rb: [],
            autorize: sessionStorage.getItem("login") === null ? false:true        
        }
    },
    mounted () {
    },
    methods: {
       f(x){
           return Math.exp((-4.9)*Math.pow(x,2))+Number(this.r)
       },
       fr(x,r){
            return Math.exp((-4.9)*Math.pow((x),2))+Number(r)
       },
       fDiff(x){
           return Math.log(Math.abs((2*4.9*x)/(Math.exp(4.9*Math.pow(x,2)))))
       },
      chartMapping(){
          this.x = []
          this.y = []
        for (let i = -1; i < this.xMax; i = i+0.01) {
           this.x.push((i).toFixed(2)) 
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
               borderColor: 'red'
            }, {
              label: 'y=x',
              data: this.x,
              fill: false,
              pointRadius: 0,
              borderColor: 'blue'
            }
          ]
        }
        this.chartOptions = {
            responsive: true, 
            maintainAspectRatio: false,
                plugins: {
                zoom: {
                    // Container for pan options
                    pan: {
                        // Boolean to enable panning
                        enabled: true,

                        // Panning directions. Remove the appropriate direction to disable 
                        // Eg. 'y' would only allow panning in the y direction
                        mode: 'xy'
                    },

                    // Container for zoom options
                    zoom: {
                        // Boolean to enable zooming
                        enabled: true,

                        // Zooming directions. Remove the appropriate direction to disable 
                        // Eg. 'y' would only allow zooming in the y direction
                        mode: 'xy',
                    }
                }
            }
        }      
      },
      chartBifur(){
        this.rb = []
        for (let i = -1; i < this.rMax; i = i+0.001) {
            this.rb.push(i.toFixed(3))           
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
        this.chartOptionsb = {
            responsive: true, 
            maintainAspectRatio: false,
                plugins: {
                zoom: {
                    // Container for pan options
                    pan: {
                        // Boolean to enable panning
                        enabled: true,

                        // Panning directions. Remove the appropriate direction to disable 
                        // Eg. 'y' would only allow panning in the y direction
                        mode: 'xy'
                    },

                    // Container for zoom options
                    zoom: {
                        // Boolean to enable zooming
                        enabled: true,

                        // Zooming directions. Remove the appropriate direction to disable 
                        // Eg. 'y' would only allow zooming in the y direction
                        mode: 'xy',
                    }
                }
            }
        }      
      },
      chartLyapunov(){
          this.rb = []
          for (let i = -1; i < this.rMax; i = i+0.001) {
            this.rb.push(i.toFixed(3))           
         } 
          var summ = [] 
          for (let j = 0; j < this.rb.length; j++) {
              var sum = 0
              var xl = [-0.1]
              var xll = []
              for (let i = 0; i < this.rb.length-1; i++) {
                  xl.push(this.fr(xl[i],this.rb[j]))
                  xll.push(this.fDiff(xl[i]))
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
                    min: -5.0,     
                }
                
                }]
            },
            plugins: {
                zoom: {
                    // Container for pan options
                    pan: {
                        // Boolean to enable panning
                        enabled: true,

                        // Panning directions. Remove the appropriate direction to disable 
                        // Eg. 'y' would only allow panning in the y direction
                        mode: 'xy'
                    },

                    // Container for zoom options
                    zoom: {
                        // Boolean to enable zooming
                        enabled: true,

                        // Zooming directions. Remove the appropriate direction to disable 
                        // Eg. 'y' would only allow zooming in the y direction
                        mode: 'xy',
                    }
                }
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
            var file=new File([new Uint8Array(array)],"mappingGauss.png",{type: 'image/png'});
            let formdata = new FormData()
            formdata.append('r',this.r)
            formdata.append('bifur',this.bifur)
            formdata.append('pokazlapuniva',this.pokazlapuniva)
            formdata.append('login',sessionStorage.getItem("login"))
            formdata.append('file',file)
           const response = await fetch("http://localhost:56063/api/mappinggauss",
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

<style>

</style>