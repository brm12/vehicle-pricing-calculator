import { createRouter, createWebHistory } from 'vue-router'
import VehiclePricingForm from '../components/VehiclePricingForm.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: VehiclePricingForm
    },
  ]
})

export default router
