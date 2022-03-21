import Vue from 'vue';
import VueRouter from 'vue-router';
import KanbanDashboard from '../components/KanbanDashboard.vue';
import SettingsDashboard from '../components/SettingsDashboard.vue';
import Login from '../components/Login.vue';

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Quadros Kanban',
    component: KanbanDashboard,
    props: true,
  },
  {
    path: '/settings/dashboard',
    name: 'Configurações',
    component: SettingsDashboard,
    props: true,
  },
  {
    path: '/login',
    name: 'Login',
    component: Login,
    props: true,
  }
]

const router = new VueRouter({
  routes
})

export default router
