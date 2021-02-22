<template>
	<div class="navbar">
		<div class="logo-site">
			<div class="logo-box">
				<div class="toggle-icon"></div>
				<div class="amis-logo"></div>
			</div>
		</div>
		<div class="navbar-content">
			<a class="nav-item" href="employee.html">
				<div class="nav-item-icon nav-item-dashboard"></div>
				<div class="nav-item-text">Tổng quan</div>
			</a>
			<a class="nav-item" href="employee.html">
				<div class="nav-item-icon nav-item-current"></div>
				<div class="nav-item-text">Tiền mặt</div>
			</a>
			<a class="nav-item" href="employee.html">
				<div class="nav-item-icon nav-item-currentSend"></div>
				<div class="nav-item-text">Tiền gửi</div>
			</a>
			<a class="nav-item" href="employee.html">
				<div class="nav-item-icon nav-item-bought"></div>
				<div class="nav-item-text">Mua hàng</div>
			</a>
			<a class="nav-item" href="employee.html">
				<div class="nav-item-icon nav-item-marketing"></div>
				<div class="nav-item-text">Bán hàng</div>
			</a>
			<a class="nav-item" href="employee.html">
				<div class="nav-item-icon nav-item-manager"></div>
				<div class="nav-item-text">Quản lý đơn hàng</div>
			</a>
			<a class="nav-item" href="employee.html">
				<div class="nav-item-icon nav-item-stock"></div>
				<div class="nav-item-text">Kho</div>
			</a>
			<a class="nav-item" href="employee.html">
				<div class="nav-item-icon nav-item-tools"></div>
				<div class="nav-item-text">Công cụ dụng cụ</div>
			</a>
			<a class="nav-item" href="employee.html">
				<div class="nav-item-icon nav-item-resource"></div>
				<div class="nav-item-text">Tài sản cố định</div>
			</a>
			<a class="nav-item" href="employee.html">
				<div class="nav-item-icon nav-item-tax"></div>
				<div class="nav-item-text">Thuế</div>
			</a>
			<a class="nav-item" href="employee.html">
				<div class="nav-item-icon nav-item-cost"></div>
				<div class="nav-item-text">Giá thành</div>
			</a>
			<a class="nav-item" href="employee.html">
				<div class="nav-item-icon nav-item-total"></div>
				<div class="nav-item-text">Tổng hợp</div>
			</a>
			<a class="nav-item" href="employee.html">
				<div class="nav-item-icon nav-item-bank"></div>
				<div class="nav-item-text">Ngân sách</div>
			</a>
			<a class="nav-item" href="employee.html">
				<div class="nav-item-icon nav-item-report"></div>
				<div class="nav-item-text">Báo cáo</div>
			</a>
			<a class="nav-item" href="employee.html">
				<div class="nav-item-icon nav-item-finance"></div>
				<div class="nav-item-text">Phân tích tài chính</div>
			</a>
		</div>
	</div>
</template>

<script>
export default {};
</script>

<style scope>
.navbar {
	position: relative;
	float: left;
	width: 178px;
	height: 100vh;
	background-color: #393a3d;
	border-right: 1px solid #bbbbbb;
	color: #fff !important;
}

.navbar .logo-site {
	display: flex;
	align-items: center;
	width: 100%;
	height: 50px;
	color: #fff !important;
}
.navbar .logo-box {
	display: flex;
	position: absolute;
	width: 100%;
	left: 24px;
	cursor: pointer;
	color: #fff !important;
}

/*Logo page*/
.navbar .logo-box .toggle-icon {
	width: 30px;
	height: 30px;
	background: url("../../assets/content/icon/Sprites.64af8f61.svg") no-repeat -424px -86px;
}

.navbar .logo-box .amis-logo {
	width: 100%;
	height: 32px;
	margin-left: 10px;
	/* background-image: url('<svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="213.333" height="60" viewBox="0 0 213.333 60">'); */
	background-image: url("../../assets/content/img/svgexport-1.svg");
	background-position: 0 center;
	background-size: contain;
	background-repeat: no-repeat;
}

.navbar .navbar-content {
	width: 100%;
	color: #fff !important;
}

.navbar .navbar-content .nav-item {
	display: flex;
	padding-left: 24px;
	height: 44px;
	cursor: pointer;
	line-height: 44px;
	color: #fff !important;
}

.navbar .navbar-content .nav-item:active {
	background-color: #393a3d;
}

.navbar .navbar-content .nav-item:focus {
	background-color: #626262;
}

.navbar .navbar-content .nav-item:hover {
	background-color: #626262;
	color: #fff !important;
	cursor: pointer;
}

.nav-item .nav-item-icon {
	width: 20px;
	height: 20px;
	align-self: center;
	margin-right: 10px;
	color: #fff !important;
	background: url("../../assets/content/icon/Sprites.64af8f61.svg") no-repeat;
}

/*Tổng quan*/
.nav-item-dashboard {
	background-position: -32px -1631px !important;
}

/* Tiền mặt */
.nav-item-current {
	background-position: -75px -1631px !important;
}

/* Tiền gửi */
.nav-item-currentSend {
	background-position: -119px -1631px !important;
}

/* Mua hàng */
.nav-item-bought {
	background-position: -163px -1631px !important;
}

/* Bán hàng */
.nav-item-marketing {
	background-position: -206px -1631px !important;
}
/* Quản lý đơn hàng */
.nav-item-manager {
	background-position: -252px -1631px !important;
}
/*  Kho */
.nav-item-stock {
	background-position: -293px -1631px !important;
}
/* Công cụ dụng cụ */
.nav-item-tools {
	background-position: -338px -1631px !important;
}
/* Tài sản cố định */
.nav-item-resource {
	background-position: -380px -1631px !important;
}
/* Thuế */
.nav-item-tax {
	background-position: -425px -1631px !important;
}
/* Giá thành */
.nav-item-cost {
	background-position: -469px -1631px !important;
}
/* Tổng hợp */
.nav-item-total {
	background-position: -512px -1631px !important;
}
/* Ngân sách */
.nav-item-bank {
	background-position: -380px -1631px !important;
}

/*Báo cáo*/
.nav-item-report {
	background-position: -549px -1631px !important;
}
/* Phân tích tài chính */
.nav-item-finance {
	background-position: -206px -1631px !important;
}
</style>
