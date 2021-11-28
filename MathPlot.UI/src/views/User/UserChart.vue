<template>
    <div v-if="datas != null">
        <div style="display: flex;" v-for="data in datas[0]" :key="data.id">
            <div>
                <b-img :src="require('../../UserCharts/'+login +'/'+ 'mappingplank'+'/'+data)"
                v-bind="mainProps"></b-img>
            </div>
        </div>
        <div style="display: flex;" v-for="data in  datas[1]" :key="data.id">
            <div>
                <b-img :src="require('../../UserCharts/'+login +'/'+ 'mappingGauss'+'/'+data)" 
                v-bind="mainProps"></b-img>
            </div>
        </div>
        <div style="display: flex;" v-for="data in  datas[2]" :key="data.id">
            <div>
                <b-img :src="require('../../UserCharts/'+login +'/'+ 'mappingLogistic'+'/'+data)" 
                v-bind="mainProps"></b-img>
            </div>
        </div>
        <div style="display: flex;" v-for="data in  datas[3]" :key="data.id">
            <div>
                <b-img :src="require('../../UserCharts/'+login +'/'+ 'mappingTwo'+'/'+data)"
                v-bind="mainProps"></b-img>
            </div>
        </div>
        <div style="display: flex;" v-for="data in  datas[4]" :key="data.id">
            <div>
                <b-img :src="require('../../UserCharts/'+login +'/'+ 'mappingSunis'+'/'+data)"
                v-bind="mainProps"></b-img>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    data(){
        return{
            datas:null,
            login:sessionStorage.getItem('login'),
             mainProps: {width: 500, height: 500},
        }
    },
    mounted(){
        this.getAllMappingByUser()
    },
    methods:{
        async getAllMappingByUser(){
             const response = await fetch("http://localhost:56063/api/Mapping/"+this.login,
            {
                method: "GET",
                headers: {"Accept": "application/json"}
            });
            if(response.status >=200 && response.status <= 299){
                this.datas = await response.json();              
            }
            else{
                console.log(response.status, response.statusText);
            }
        }
    }
}
</script>