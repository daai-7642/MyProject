<template>
	<div>
		<pull-to :top-load-method="refresh" :bottom-load-method="loadmore">
			<ul class="mui-table-view mui-table-view-striped mui-table-view-condensed">
				<li class="mui-table-view-cell" v-for="bill in dataList">
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
		</pull-to>
	</div>
</template>

<script>
	import PullTo from 'vue-pull-to'
	//import { fetchDataList } from 'api' 
	import global_ from '@/components/tool/Global'
	import axios from 'axios'
	export default {
		name: 'refrech',
		components: {
			PullTo
		},
		data() {
			return {
				dataList: [],
				index: 1
			}
		},
		mounted() {
			this.refresh();
		},
		methods: {
			refresh(loaded) {
				this.index = 1;
				this.load();

				//     this.fetchDataList()
				//      .then((res) => {
				//        this.dataList = res.data.dataList
				//        loaded('done')
				//      })
				loaded('done');
			},
			loadmore() {
				console.log(2);
				//this.load();

				let that = this;
				setTimeout(() => {
					axios.get(global_.requestServerPath + "/bill", {
						params: {
							index: this.index,
							size: 8
						}
					}).then(resp => {
						mui.hideLoading(h => {});
						that.dataList.concat(resp.data.data);
						console.log(that.dataList);
						that.index += 1;
						console.log(this.index);
							loaded('done');
					})
				}, 1000);

			
			},
			load() {
				let that = this;
				axios.get(global_.requestServerPath + "/bill", {
					params: {
						index: this.index,
						size: 8
					}
				}).then(resp => {
					mui.hideLoading(h => {});
					that.dataList = resp.data.data;
					this.index = 2;
				})
			}
		}
	}
</script>