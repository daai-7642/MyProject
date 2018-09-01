<template>
	<div>
		<header class="mui-bar mui-bar-nav">
			<a href="#/" class="mui-icon mui-icon-left-nav mui-pull-left"></a>
			<h1 class="mui-title">账本列表</h1>
		</header>

		<load :datalist="billdata"></load>
	</div>
</template>

<script>
	import load from '@/components/bill-refresh'
	import global_ from '@/components/tool/Global'
	import axios from 'axios'
	 
	//var pullToRefresh = mui(selector).pullToRefresh(options);
	export default {
		//		//el: '#vapp',
		data() {
			return {
				billdata: [],
				index:1,
			}
		},
		components: {
			load,
		},
		created: function() {
			this.init();
		},
		methods: {
			init: function() {
				mui.init({
					pullRefresh: {
						container: '#bill-pullrefresh',
						down: {
							style: 'circle',
							callback: this.pulldownRefresh()
						},
						up: {
							auto: true,
							contentrefresh: '正在加载...',
							callback: this.pullupRefresh()
						}
					}
				});

			},
			pullupRefresh: function() {
				console.log("up");
				//return false;
				let that = this;
				setTimeout(function() {

					mui('#pullrefresh').pullRefresh().endPullupToRefresh(true); //参数为true代表没有更多数据了。
					//var cells = document.body.querySelectorAll('.mui-table-view-cell');
					that.getdate(that);
//					var newCount = cells.length > 0 ? 5 : 20; //首次加载20条，满屏
//					console.log(cells.length);
//					for(var i = cells.length, len = i + newCount; i < len; i++) {
//						that.list.push({
//							id: i,
//							txt: "itemtest" + i + 1
//						});
//					}
				}, 1500);
			},
			pulldownRefresh: function() {
				console.log("down");
				//				return false;
				
				let that = this;
				setTimeout(function() {
					//that.addData(that); 
					that.getdate(that);
				mui('#pullrefresh').pullRefresh().endPulldown();
				//mui('#pullrefresh').pullRefresh().endPulldownToRefresh(true);
					mui.toast("为你推荐了5篇文章");
				}, 1500);
			},
			addData: function(that) {
				console.log(1);
				var cells = document.body.querySelectorAll('.mui-table-view-cell');
				for(var i = cells.length, len = i + 5; i < len; i++) {
					that.list.push({
						id: i,
						txt: "itemtest_" + i + 1
					});
				}
			},
			getdate: function(that) {
			 
				mui.showLoading("加载中..", "div");
				setTimeout(function() {
					mui.hideLoading(h => {});
				}, 5000)
				axios.get(global_.requestServerPath + "/bill", {
					params: {
						index: that.index,
						size: 20
					}
				}).then(resp => {
					mui.hideLoading(h => {});
					//console.log(resp.data.data)
					this.billdata = resp.data.data;
					that.index++;
					//mui('#pullrefresh').pullRefresh().endPulldownToRefresh();
				})
			}

		}

	}

	var count = 0;
</script>