import Vue from 'vue'
import global_ from '@/components/tool/Global'
Vue.prototype.GLOBAL = global_
import Router from 'vue-router'
import HelloWorld from '@/components/HelloWorld'
//bill
import billindex from '@/views/bill/index'
import billadd from '@/views/bill/add'
import billtype from '@/views/bill/type'
//home
import homeindex from '@/views/home/index'
Vue.use(Router)

export default new Router({
	routes: [
	
	 {
			path: "/",
			name: "homeindex",
			component: homeindex
		},
		{
			path: '/hello',
			name: 'HelloWorld',
			component: HelloWorld
		},
		{
			path: '/bill/index',
			name: "billindex",
			component: billindex
		},
		{
			path: "/bill/add",
			name: "billadd",
			component: billadd
		},
		{
			path: "/bill/type",
			name: "billtype",
			component: billtype
		}
	]
})