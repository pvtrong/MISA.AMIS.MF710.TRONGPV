<template>
	<div class="m-dropBox ">
		<div class="headerDopbox ">
			<button @click="editOnClick" class="m-dropBoxBtn ">
				Sửa
			</button>
			<button @click="changeShow" class="m-btnIconDropBox cbb">
				<div class="iconDropBox cbb"></div>
			</button>
		</div>
		<div v-show="this.isShow === true" class="contentDropBox">
			<div @click="cloneOnClick">Nhân bản</div>
			<div @click="deleteOnClick">Xóa</div>
			<div @click="changeStatusBanking">Ngừng sử dụng</div>
		</div>
	</div>
</template>

<script>
export default {
	created() {
		// Hàm xử lý sự kiện dropbox được click
		window.addEventListener("click", this.documentClick);
	},
	data() {
		return {
			isShow: false,
		};
	},
	methods: {
		// Hàm xử lý sự kiện xóa:
		deleteOnClick() {
			this.$emit("deleteOnClick");
		},

		// Hàm xử lý sự kiện thay đổi trạng thái thẻ ngân hàng
		changeStatusBanking() {
			this.$emit("changeStatusBanking");
		},

		// Hàm xử lý sự kiện nhân bản
		cloneOnClick() {
			this.$emit("cloneOnClick");
		},

		// Hàm xử lý sự kiện click
		editOnClick() {
			this.$emit("editOnClick");
		},

		// Hàm để mở đóng dropbox nếu mà click mọi chỗ mà khác dropbox thì dropbox sẽ đóng còn ko thì mở cái dropbox tại vị trí click
		documentClick(event) {
			if (event.target.className.includes("cbb")) {
				event.target.isShow = true;
			} else this.isShow = false;
		},

		// Show dialog nhân bản, xóa, ngừng sử dụng
		changeShow() {
			this.isShow = !this.isShow;
		},
	},
};
</script>

<style>
.contentDropBox {
	border: 1px solid #c9ccd2;
	position: absolute;
	top: 37px;
	right: 37px;
	z-index: 4;
	min-width: 10px;
	min-height: 10px;
	padding: 2px 1px;
	background-color: #fff;
}

.contentDropBox div {
	height: 27px;
	width: 100%;
	padding: 8px;
	line-height: 10px;
}
.headerDopbox {
	display: flex;
	align-items: center;
}

.contentDropBox div:hover {
	cursor: pointer;
	color: #2ca01c;
	background-color: #f1f1f1;
}

.m-dropBox {
	display: flex;
	width: 87px;
	height: 36px;
	align-items: center;
}
.m-dropBox button:active {
	border: 1px solid #0075c0;
}

.m-dropBoxBtn {
	width: 40;
	height: 36px;
	background-color: inherit;
	outline: none;
	color: #0075c0 !important;
	font-weight: bold;
	font-family: GoogleSans-Light;
	border: none;
	cursor: pointer;
}
.m-btnIconDropBox {
	height: 32px;
	width: 32px;
	padding: 8px 10px;
	background-color: inherit;
	outline: none;
	border: none;
	cursor: pointer;
}

.iconDropBox {
	width: 26px;
	height: 20px;
	background: url("../../assets/content/img/Sprites.64af8f61.svg") no-repeat;
	background-position: -898px -360px;
}
</style>
