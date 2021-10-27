import Vue from 'vue'
import Router from 'vue-router'


Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes:[
    {
      path: '/',
      name: 'home',
      meta: {layout: 'MainNoAuth'},
      component: () => import('../views/Home.vue')
    },
    {
      path: '/MainNoAuth',
      name: 'MainNoAuth',
      meta: {layout: 'MainNoAuth'},
      component: () => import('../views/Main.vue')
    },
    {
      path: '/MappPlank',
      name: 'MappPlank',
      meta: {layout: 'MainNoAuth'},
      component: ()=> import('../views/MappPlank.vue')
    },
    {
      path: '/OneDimensionalMappings',
      name: 'OneDimensionalMappings',
      meta: {layout: 'MainNoAuth'},
      component: ()=> import('../views/OneDimensionalMappings.vue')
    },
    {
      path: '/TwoDimensionalMappings',
      name: 'TwoDimensionalMappings',
      meta: {layout: 'MainNoAuth'},
      component: ()=> import('../views/TwoDimensionalMappings.vue')
    }
  ]
})

