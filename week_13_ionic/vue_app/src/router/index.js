import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'HelloWorld',
      component: () =>
        import('../components/HelloWorld.vue')
    },

    {
      path: '/about',
      name: 'About',
      component: () =>
        import('../components/About.vue')
    },

    {
      path: '/don',
      name: 'Don',
      component: () =>
        import('../components/Don.vue')
    },

    {
      path: '/details/:id/:day/:month',
      name: 'Details',
      component: () =>
        import(/* webpackChunkName: "download" */ '../components/Details.vue')
    }
  ]
})
