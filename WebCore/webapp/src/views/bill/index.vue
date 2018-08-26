<template>
	<div>
		<header class="mui-bar mui-bar-nav">
			<a href="#/" class="mui-icon mui-icon-left-nav mui-pull-left"></a>
			<h1 class="mui-title">账本列表</h1>
		</header>
		<div class="mui-content">

			<ul class="mui-table-view mui-table-view-striped mui-table-view-condensed">
				<li class="mui-table-view-cell" v-for="bill in billdata">
					<div class="mui-table">
						<div class="mui-table-cell mui-col-xs-8">
							<h4 class="mui-ellipsis">{{bill.chargeName}}_{{bill.typeName}}_{{bill.money}}</h4>
							<h5>地址:{{bill.address}}</h5>
							<p class="mui-h6 mui-ellipsis">备注:{{bill.remarkInfo}}</p>
						</div>
						<div class="mui-table-cell mui-col-xs-4 mui-text-right">
							<span class="mui-h5">{{bill.chargeTime1}}</span>
						</div>
					</div>
				</li>

			</ul>

		</div>

	</div>
</template>
<script>
	import global_ from '@/components/tool/Global'
	import axios from 'axios'
	import pullTo from 'vue-pull-to'
	//import { fetchDataList } from 'api'
	export default {
		name: 'billadd',
		data() {
			return {
				billdata: []
			}
		},
		mounted() {

			axios.get(global_.requestServerPath + "/bill", {
				params: {
					index: 1,
					size: 20
				}
			}).then(resp => {
				//console.log(resp.data.data)
				this.billdata = resp.data.data;
			})
		},
		methods: {
			 
		}
	}
	  
</script>