<template>
	<div>
		<header class="mui-bar mui-bar-nav">
			<a href="#/" class="mui-icon mui-icon-left-nav mui-pull-left"></a>
			<h1 class="mui-title">账本列表</h1>
		</header>
		<div class="mui-content">
			<ul class="mui-table-view mui-table-view-striped mui-table-view-condensed">
				<li class="mui-table-view-cell"  v-for="bill in billdata"> 
					<div class="mui-table">
						<div class="mui-table-cell mui-col-xs-10">
							<h4 class="mui-ellipsis">{{bill.ChargeName}}{{bill.typeName}}{{bill.money}}</h4>
							<h5>{{bill.address}}</h5>
							<p class="mui-h6 mui-ellipsis">{{bill.remarkInfo}}</p>
						</div>
						<div class="mui-table-cell mui-col-xs-2 mui-text-right">
							<span class="mui-h5">{{bill.chargeTime1}}</span>
						</div>
					</div>
				</li>
				<li class="mui-table-view-cell">
					<div class="mui-table">
						<div class="mui-table-cell mui-col-xs-10">
							<h4 class="mui-ellipsis-2">信息化推进办公室张彦合同付款信息化推进办公室张彦合同付款信息化推进办公室张彦合同付款</h4>
							<h5>申请人：李四</h5>
							<p class="mui-h6 mui-ellipsis">Hi，李明明，申请交行信息卡，100元等你拿，李明明，申请交行信息卡，100元等你拿，</p>
						</div>
						<div class="mui-table-cell mui-col-xs-2 mui-text-right">
							<span class="mui-h5">12:25</span>

						</div>
					</div>
				</li>
				<li class="mui-table-view-cell">
					<div class="mui-table">
						<div class="mui-table-cell mui-col-xs-10">
							<h4 class="mui-ellipsis-2">信息化推进办公室张彦合同付款信息化推进办公室张彦合同付款信息化推进办公室张彦合同付款</h4>
							<h5>申请人：李四</h5>
							<p class="mui-h6 mui-ellipsis">Hi，李明明，申请交行信息卡，100元等你拿，李明明，申请交行信息卡，100元等你拿，</p>
						</div>
						<div class="mui-table-cell mui-col-xs-2 mui-text-right">
							<span class="mui-h5">12:25</span>

						</div>
					</div>
				</li>
				<li class="mui-table-view-cell">
					<div class="mui-table">
						<div class="mui-table-cell mui-col-xs-10">
							<h4 class="mui-ellipsis-2">信息化推进办公室张彦合同付款信息化推进办公室张彦合同付款信息化推进办公室张彦合同付款</h4>
							<h5>申请人：李四</h5>
							<p class="mui-h6 mui-ellipsis">Hi，李明明，申请交行信息卡，100元等你拿，李明明，申请交行信息卡，100元等你拿，</p>
						</div>
						<div class="mui-table-cell mui-col-xs-2 mui-text-right">
							<span class="mui-h5">12:25</span>

						</div>
					</div>
				</li>
				<li class="mui-table-view-cell">
					<div class="mui-table">
						<div class="mui-table-cell mui-col-xs-10">
							<h4 class="mui-ellipsis-2">信息化推进办公室张彦合同付款信息化推进办公室张彦合同付款信息化推进办公室张彦合同付款</h4>
							<h5>申请人：李四</h5>
							<p class="mui-h6 mui-ellipsis">Hi，李明明，申请交行信息卡，100元等你拿，李明明，申请交行信息卡，100元等你拿，</p>
						</div>
						<div class="mui-table-cell mui-col-xs-2 mui-text-right">
							<span class="mui-h5">12:25</span>

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
					size: 10
				}
			}).then(resp => {
				//console.log(resp.data.data)
				this.billdata=resp.data.data;
			})
		},
		methods: {}
	}
</script>