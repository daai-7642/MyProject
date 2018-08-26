<template>
	<div>
		<header class="mui-bar mui-bar-nav">
			<a class="mui-action-back mui-icon mui-icon-left-nav mui-pull-left"></a>
			<h1 class="mui-title">录入</h1>
		</header>
		<form class="mui-content" v-on:submit="submitdata">
			<div class="mui-content-padded" style="margin: 5px;">

				<h5>信息录入</h5>

				<div class="mui-input-group">

					<div class="mui-input-row">
						<label>概要：</label>
						<input type="text" required="" v-model="bill.ChargeName" class="mui-input-clear" placeholder="消费概要">
					</div>
					<div class="mui-input-row">
						<label>类型：</label>
						<input type="text" required="" v-model="bill.TypeNmae" class="mui-input-clear" placeholder="类型" v-on:click="selecttype">
						<input type="text" v-model="bill.TypeId" class="mui-input-clear" placeholder="类型" v-on:click="selecttype">
					</div>
					<div class="mui-input-row">
						<label>时间：</label>
						<input type="date" required="" v-model="bill.ChargeTime" ref="currdate" value="">
					</div>
					<div class="mui-input-row">
						<label>金额：</label>
						<input type="number" required="" v-model="bill.Money" class="mui-input-clear" placeholder="相关金额">
					</div>
					<div class="mui-input-row">
						<label>地址：</label>
						<input type="text" v-model="bill.Address" class="mui-input-clear" placeholder="相应的地址">
					</div>

				</div>
				<div class="mui-input-row" style="margin: 10px 0px;">
					<textarea id="textarea" v-model="bill.RemarkInfo" rows="5" placeholder="备注"></textarea>
				</div>
				<div class="mui-button-row">
					<button type="submit" class="mui-btn mui-btn-primary">确认</button>&nbsp;&nbsp;
					<button type="button" class="mui-btn mui-btn-danger" onclick="return false;">取消</button>
				</div>
			</div>
		</form>
	</div>
</template>

<script>
	import global_ from '@/components/tool/Global'
	import axios from 'axios'
	export default {
		name: 'billadd',
		data() {
			return {
				bill: {
					ChargeName: "",
					TypeId: "",
					ChargeTime: "",
					Money: "",
					Address: "",
					RemarkInfo: ""
				},
				//currdate:"2018-08-26"
			}
		},
		mounted() {

			const typedata = this.getParams();
			if(typedata != null) {
				this.bill.TypeId = typedata.value;
				this.bill.TypeNmae = typedata.name;
			}
			const date = new Date();
			const currdate = date.getFullYear() + "-" + ("0" + (date.getMonth() + 1)).slice(-2) + "-" + date.getDate();

			this.bill.ChargeTime = currdate;
		},
		methods: {
			getParams() {
				// 取到路由带过来的参数 
				let routerParams = this.$route.query
				// 将数据放在当前组件的数据内
				//console.log(routerParams);
				return routerParams.data;
			},
			selecttype() {
				this.$router.push({
					path: 'type',
					//name: '要跳转的路径的 name,在 router 文件夹下的 index.js 文件内找',
					params: {}
				})
			},
			submitdata() {
				axios.post(global_.requestServerPath + "/bill", this.bill)
					.then(resp => {
						if(resp.data.code == 1) {
							mui.toast("录入成功");
							this.$router.push({
								path: 'index',
								//name:"跳转的path也能",
								query: {
									name: 'index',
									data: {}
								}
							})
						} else {
							mui.toast("操作失败");
						}
					})
				//				axios.get(global_.requestServerPath+"/bill", {
				//						params: {
				//							index:1,
				//							size:3,
				//						}
				//					})
				//					.then(resp => {
				//						console.log(resp.data);
				//					}).catch(err => { //
				//						console.log('请求失败：' + err.status + ',' + err.statusText);
				//					});

				console.log(JSON.stringify(this.bill));
			}
		},

	}
	//{{currdate}}
	//new Date()
</script>