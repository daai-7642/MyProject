<template>
	<div>
		<header class="mui-bar mui-bar-nav">
			<h1 class="mui-title">主页</h1>
		</header>

		<div class="mui-content">
			<ul class="mui-table-view mui-grid-view mui-grid-9">
				<li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
					<a href="#/bill/index">
						<svg class="mui-icon icon" aria-hidden="true">
							<use xlink:href="#icon-jizhang"></use>
						</svg>
						<div class="mui-media-body">记账本</div>
					</a>
				</li>
				<li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
					<a href="#/bill/add">
						<svg class="mui-icon icon" aria-hidden="true">
							<use xlink:href="#icon-tianjiaadd142"></use>
						</svg>
						<div class="mui-media-body">记账</div>
					</a>
				</li>
				<li class="mui-table-view-cell mui-media mui-col-xs-4 mui-col-sm-3">
					<a href="#">
						<svg class="mui-icon icon" aria-hidden="true">
							<use xlink:href="#icon-tongji"></use>
						</svg>
						<div class="mui-media-body">统计</div>
					</a>
				</li>

			</ul>

		</div>
	</div>
</template>
<script>
	sessionStorage.clear();
	var _toast = false;

	mui.back = function() { 
		return false;
		if(!_toast || !_toast.isVisible()) {
			_toast = mui.toast('再按一次返回键退出', {
				duration: 'long',
				type: 'div'
			});
		} else {
			plus.runtime.quit();
		}
	}
</script>