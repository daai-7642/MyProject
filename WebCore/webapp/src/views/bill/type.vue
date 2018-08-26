<template>
	<div>
		<h5 class="mui-content-padded">类型选择</h5>
		<div class="mui-card">
			<form class="mui-input-group">
				<div class="mui-input-row mui-radio mui-left">
					<label>支出</label>
					<input name="radio1" type="radio" v-on:click="typeselect" data-txt="支出" value="1" checked>
				</div>
				<div class="mui-input-row mui-radio mui-left">
					<label>收入</label>
					<input name="radio1" type="radio" v-on:click="typeselect" data-txt="收入" value="2">
				</div>

			</form>
		</div>
	</div>
</template>
<script>
	export default {
		name: 'billtype',
		data() {
			return {

			}
		},
		mounted() {
			//console.log(this.$route.params);
		},
		methods: {
			typeselect: function(event) { 
				let bill = JSON.parse(sessionStorage.getItem("billdata"));
				bill.TypeId = event.target.value;
				bill.TypeNmae = event.target.dataset.txt;
				sessionStorage.setItem("billdata", JSON.stringify(bill))
				this.$router.push({
					path: 'add',

				})
			}
		}
	}
</script>