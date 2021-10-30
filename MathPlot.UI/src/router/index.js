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
      meta: {layout: 'Main'},
      component: () => import('../views/Home.vue')
    },
    {
      path: '/MainNoAuth',
      name: 'MainNoAuth',
      meta: {layout: 'Main'},
      component: () => import('../views/Main.vue')
    },
    {
      path: '/MappPlank',
      name: 'MappPlank',
      meta: {layout: 'Main'},
      component: ()=> import('../views/MappPlank.vue')
    },
    {
      path: '/OneDimensionalMappings/0',
      name: 'OneDimensionalMappings',
      meta: {layout: 'Main'},
      component: ()=> import('../views/OneDimensionalMappings.vue')
    },
    {
      path: '/TwoDimensionalMappings/0',
      name: 'TwoDimensionalMappings',
      meta: {layout: 'Main'},
      component: ()=> import('../views/TwoDimensionalMappings.vue')
    },
    {
      path: '/OneDimensionalMappings/1',
      name: 'TheoryLogistic',
      meta: {layout: 'Main'},
      component: ()=> import('../views/TheoryLogistic.vue')
    }
  ]
})

