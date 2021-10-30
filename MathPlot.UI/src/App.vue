<template>
  <div id="app">
    <component :is="layout">
      <router-view/>
    </component>
  </div>
</template>

<script>
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import 'vue-datetime/dist/vue-datetime.css'
import MainLayout from  '@/layouts/MainLayout'
export default {
  computed:{
    layout(){
      return (this.$route.meta.layout || 'Main') + '-layout'
    }
  },
  components:{
    MainLayout
  }
}
</script>

<style lang="scss">

</style>
