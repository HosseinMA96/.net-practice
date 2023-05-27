import { createApp } from 'vue'
import { createRouter, createWebHistory } from 'vue-router'

import App from './App.vue'
import Get_weather from './components/Get_weather.vue'
import Delete_employee from './components/Delete_employee.vue'
import Add_employee from './components/Add_employee.vue'
import Show_single_employee from './components/Show_single_employee.vue'
import Show_all_employees from './components/Show_all_employees.vue'


const router = createRouter({
    history: createWebHistory(),
    routes: [
        { path: '/weather', component: Get_weather },
        { path: '/delete', component: Delete_employee },
        { path: '/add', component: Add_employee },
        { path: '/all', component: Show_all_employees },
        { path: '/single', component: Show_single_employee },
    ]
});



const app = createApp(App)

app.use(router);

app.mount('#app')