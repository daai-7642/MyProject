<template>
	<div>
		<header class="mui-bar mui-bar-nav">
			<a id="back" class="mui-action-back mui-icon mui-icon-left-nav mui-pull-left"></a>
			<h1 id="title" class="mui-title">下拉刷新和上拉加载更多</h1>
		</header>
		<div class="mui-content"></div>
	</div>
</template>
<script>
	import global_ from '@/components/tool/Global'
	import axios from 'axios' 
//	mui.init({
//				subpages: [{
//					url: '#/bill/billindexrefresh',
//					id: '/bill/billindexrefresh',
//					styles: {
//						top: '45px',
//						bottom: '0px',
//					}
//				}]
//			});
 

	//	var contentWebview = null; 
	//	document.querySelector('header').addEventListener('doubletap', function() {
	//		if(contentWebview == null) {
	//			contentWebview = plus.webview.currentWebview().children()[0];
	//		}
	//		contentWebview.evalJS("mui('#pullrefresh').pullRefresh().scrollTo(0,0,100)");
	//	});
</script>