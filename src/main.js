import Vue from 'vue'
import Search from './components/Search.vue'
// Import element-ui.
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import enLocale from 'element-ui/lib/locale/lang/en'
Vue.config.productionTip = false

Vue.use(ElementUI, { enLocale })
new Vue({
  render: h => h(Search),
}).$mount('#app')