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
import MainNoAuthLayout from  '@/layouts/MainNoAuthLayout'
export default {
  computed:{
    layout(){
      return (this.$route.meta.layout || 'MainNoAuth') + '-layout'
    }
  },
  components:{
    MainNoAuthLayout
  }
}
</script>

<style lang="scss">

</style>
