<template>

	<div id="bill-pullrefresh" class="mui-content mui-scroll-wrapper">
		<div class="mui-scroll">
			<ul class="mui-table-view mui-table-view-striped mui-table-view-condensed">
				<li class="mui-table-view-cell" v-for="bill in datalist">
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
	<!--下拉刷新容器-->
	<!--<div id="pullrefresh" class="mui-content mui-scroll-wrapper">
		<div class="mui-scroll">
			 
			<ul class="mui-table-view mui-table-view-chevron">
				<li class="mui-table-view-cell" v-for="x in datalist">
					<a class="mui-navigate-right">{{x.txt}}</a>
				</li>
			</ul>
		</div>
	</div>-->

</template>
<script>
	export default {
		data() {
			return {
				//datalist:[]
			}
		},
		props: ["datalist"]
	}
</script>