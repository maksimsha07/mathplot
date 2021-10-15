import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import { BootstrapVue} from 'bootstrap-vue'
import UUID from "vue-uuid";
import { Datetime } from 'vue-datetime'
 
Vue.config.productionTip = false
Vue.use(BootstrapVue)
Vue.use(UUID);
Vue.use(Datetime)

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
