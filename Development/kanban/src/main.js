import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import router from './router'
import { createPinia, PiniaVuePlugin } from 'pinia'

Vue.use(PiniaVuePlugin);
const pinia = createPinia();

Vue.config.productionTip = false

new Vue({
  vuetify,
  router,
  pinia,
  render: h => h(App)
}).$mount('#app')

export const bus = new Vue();