import Vue from 'vue';
import VueRouter from 'vue-router';
import KanbanDashboard from '../components/KanbanDashboard.vue';
import ForumDashboard from '../components/ForumDashboard.vue';
import SettingsDashboard from '../components/SettingsDashboard.vue';
import Login from '../components/Login.vue';

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Quadros Kanban',
    component: KanbanDashboard,
  },
  {
    path: '/forum/dashboard',
    name: 'Forum de Disciplinas',
    component: ForumDashboard,
  },
  {
    path: '/settings/dashboard',
    name: 'Configurações',
    component: SettingsDashboard,
  },
  {
    path: '/login',
    name: 'Login',
    component: Login,
  }
]

const router = new VueRouter({
  routes
})

export default router
