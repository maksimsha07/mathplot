import Vue from 'vue';
import App from './App.vue';
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'

Vue.config.productionTip = true;
Vue.use(BootstrapVue)
new Vue({
    render: h => h(App)
}).$mount('#app');
