import Vue from 'vue'
import global_ from '@/components/tool/Global'
Vue.prototype.GLOBAL = global_
import Router from 'vue-router'
import HelloWorld from '@/components/HelloWorld'
import billindex from '@/views/bill/index'
import billadd from '@/views/bill/add'
import billtype from '@/views/bill/type'
Vue.use(Router)
 
export default new Router({
	routes: [{
			path: '/',
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