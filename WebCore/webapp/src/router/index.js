import Vue from 'vue'
import global_ from '@/components/tool/Global'
Vue.prototype.GLOBAL = global_
import Router from 'vue-router'
import HelloWorld from '@/components/HelloWorld'
//bill
import billindex from '@/views/bill/index'
import billbindex from '@/views/bill/bindex'
import billadd from '@/views/bill/add'
import billtype from '@/views/bill/type'
 
import billlist from '@/views/bill/blist'

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
			path: '/bill/bindex',
			name: "billbindex",
			component: billbindex
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
		},
	 
		{
			path: "/bill/blist",
			name: "billlist",
			component: billlist
		} 
	]
})
