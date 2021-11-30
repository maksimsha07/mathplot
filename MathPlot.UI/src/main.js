import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import { BootstrapVue,IconsPlugin} from 'bootstrap-vue'
import UUID from "vue-uuid";
import { Datetime } from 'vue-datetime'
import '../src/assets/css/styles.scss';
import 'bootstrap'
import './assets/css/styles.scss'
import VueMathjax from 'vue-mathjax'
Vue.use(VueMathjax)
 
Vue.config.productionTip = false
Vue.use(BootstrapVue)
Vue.use(UUID);
Vue.use(Datetime)
Vue.use(IconsPlugin)

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
