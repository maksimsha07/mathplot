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
      component: ()=> import('../views/Mapping/MappPlank.vue')
    },
    {
      path: '/MappLogistic',
      name: 'MappLogistic',
      meta: {layout: 'Main'},
      component: ()=> import('../views/Mapping/MappLogistic.vue')
    },
    {
      path: '/MappSinus',
      name: 'MappSinus',
      meta: {layout: 'Main'},
      component: ()=> import('../views/Mapping/MappSinus.vue')
    },
    {
      path: '/MappTwoStor',
      name: 'MappTwoStor',
      meta: {layout: 'Main'},
      component: ()=> import('../views/Mapping/MappTwoStor.vue')
    },
    {
      path: '/MappGaus',
      name: 'MappGaus',
      meta: {layout: 'Main'},
      component: ()=> import('../views/Mapping/MappGaus.vue')
    },
    {
      path: '/OneDimensionalMappings/0',
      name: 'OneDimensionalMappings',
      meta: {layout: 'Main'},
      component: ()=> import('../views/Theory/OneDimensionalMappings.vue')
    },
    {
      path: '/TwoDimensionalMappings/0',
      name: 'TwoDimensionalMappings',
      meta: {layout: 'Main'},
      component: ()=> import('../views/Theory/TwoDimensionalMappings.vue')
    },
    {
      path: '/OneDimensionalMappings/1',
      name: 'TheoryLogistic',
      meta: {layout: 'Main'},
      component: ()=> import('../views/Theory/TheoryLogistic.vue')
    },
    {
      path: '/OneDimensionalMappings/2',
      name: 'BifurcationTheory',
      meta: {layout: 'Main'},
      component: ()=> import('../views/Theory/BifurcationTheory.vue')
    },
    {
      path: '/OneDimensionalMappings/3',
      name: 'LyapunovExponentsTheory',
      meta: {layout: 'Main'},
      component: ()=> import('../views/Theory/LyapunovExponentsTheory.vue')
    },
    {
      path: '/:login/Profile',
      name: 'ProfileUser',
      meta: {layout: 'Main'},
      component: ()=> import('../views/User/User.vue')
    },
    {
      path: '/:login/Charts',
      name: 'ChartsUser',
      meta: {layout:'Main'},
      component: ()=> import('../views/User/UserChart.vue')
    },
    {
      path: '*',
      name: 'NotFound',
      component: () => import('../views/Home.vue')
    }

  ]
})

