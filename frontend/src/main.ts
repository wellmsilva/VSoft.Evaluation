import './assets/style.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'
import axios from 'axios'
import VueAxios from 'vue-axios'


import 'vuetify/styles'
import '@mdi/font/css/materialdesignicons.css'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

import App from './App.vue'
import router from './router'
import colors from 'vuetify/util/colors'

const app = createApp(App)
// use
app.use(createPinia())
app.use(router)

const vuetify = createVuetify({
  components,
  directives,
  icons: {
    defaultSet: 'mdi'
  },
  theme: {
    themes: {
      light: {
        dark: false,
        colors: {
          primary: colors.red.darken1, // #E53935
          secondary: colors.red.lighten4, // #FFCDD2
           background: "#c0c0b5",
          "header-background": "#b5b5a6",
          "info-text": "#666660",
        }
      },
    },
  },
})
app.use(vuetify)
app.use(VueAxios, axios)


app.mount('#app')


