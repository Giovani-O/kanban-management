import Vue from 'vue'
import VueRouter from 'vue-router'
import KanbanDashboard from '../components/KanbanDashboard.vue'
import ForumDashboard from '../components/ForumDashboard.vue';

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Quadros Kanban',
    component: KanbanDashboard
  },
  {
    path: '/forum/dashboard',
    name: 'Forum de Disciplinas',
    component: ForumDashboard
  }
]

const router = new VueRouter({
  routes
})

export default router
