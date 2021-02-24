<template>
	<div class="m-combobox cbb">
		<div class="input cbb" v-if="itemSelected[`${category}Id`] === ''">
			{{ header }}
		</div>
		<div class="input cbb" v-else>
			{{ getItemSelected()[0][`${category}Name`] }}
		</div>

		<div
			ref="txtDepartmentId"
			:class="{
				reverse: isHide,
				'fa-angle-up': faCaretUp,
				'fa-angle-down': faCaretDown,
			}"
			class="comboboxBtn fas cbb"
			@click="showCombobox()"
		>
			<div></div>
		</div>
		<div
			class="m-combobox-data"
			:style="end ? 'top:-' + content.length * 32 + 'px' : 'top:32px;'"
			:class="{ isHide: isHide }"
		>
			<div
				@click="setItemSelected(item)"
				:id="item[`${category}Id`]"
				v-for="item in content"
				:class="{ itSelected: itSelect(item) }"
				:key="item[`${category}Id`]"
				class="m-combobox-item"
			>
				<div class="checkmark2">
					<div></div>
				</div>
				<div class="textCbx">{{ item[`${category}Name`] }}</div>
			</div>
		</div>
	</div>
</template>

<script>
export default {
	created() {
		window.addEventListener("keyup", this.setselected);
		this.$parent.$on("showCombobox", this.showCombobox);
		window.addEventListener("click", this.documentClick);
	},
	props: [
		"tabindex",
		"header",
		"content",
		"itemSelected",
		"end",
		"category",
		"faCaretUp",
		"faCaretDown",
	],
	computed: {},
	methods: {
		// Hàm xử lý sự kiện khi người dùng gõ phím để tab index
		setselected(content) {
			if (this.category === "department") {
				let index = 0;
				for (let i = 0; i < this.content.length; i++) {
					if (
						this.content[i][`departmentId`] ===
						this.itemSelected[`departmentId`]
					)
						index = i;
				}
				if (content.which === 38 && this.isHide == false) {
					if (index == 0) {
						index = 3;
						this.setItemSelected2(this.content[index - 1]);
					} else {
						this.setItemSelected2(this.content[index - 1]);
					}
				} else if (content.which === 40 && this.isHide == false) {
					if (index == 2) {
						index = -1;
						this.setItemSelected2(this.content[index + 1]);
					} else {
						this.setItemSelected2(this.content[index + 1]);
					}
				}
				if (
					content.which === 13 &&
					this.isHide == false &&
					content.shiftKey === true &&
					content.path[0].id !== "txtFullName" &&
					content.path[0].id !== "txtPosition"
				) {
					if (this.getItemSelected().length === 0) {
						document
							.getElementById("txtDepartmentId")
							.classList.add("required-error");
					}
					this.$emit("setItemSelected4");
					this.isHide = true;
				} else if (
					content.which === 13 &&
					this.isHide == false &&
					content.path[0].id !== "txtFullName" &&
					content.path[0].id !== "txtPosition"
				) {
					if (this.getItemSelected().length === 0) {
						document
							.getElementById("txtDepartmentId")
							.classList.add("required-error");
					}
					this.$emit("setItemSelected3");
					this.isHide = true;
				}
			}
		},

		// Hàm xử lý sự kiện khi người dùng chọn đơn vị bằNg bàn phím
		setItemSelected2(item) {
			this.isHide = false;
			let data = { id: item[`departmentId`] };
			this.$emit("setItemSelected2", data);
		},

		// Hàm checkvalidate của đơn vị
		documentClick(event) {
			if (event.target.className.includes("cbb")) {
				event.target.isHide = false;
				document
					.getElementById("txtDepartmentId")
					.classList.remove("required-error");
			} else this.isHide = true;
		},

		// Hàm dùng chung cho các comboxbox kiểm tra cái nào được select trong mảng truyền vào
		itSelect(item) {
			return (
				item[`${this.category}Id`] ===
				this.itemSelected[`${this.category}Id`]
			);
		},

		// Hàm xổ xuống của combobox
		showCombobox() {
			document
				.getElementById("txtDepartmentId")
				.classList.remove("required-error");
			this.isHide = !this.isHide;
		},

		// Hàm lấy item được chọn
		getItemSelected() {
			let temp = this.content.filter(
				(item) =>
					item[`${this.category}Id`] ===
					this.itemSelected[`${this.category}Id`]
			);
			return temp;
		},

		// Hàm đặt item được chọn
		setItemSelected(item) {
			this.isHide = false;
			let data = { id: item[`${this.category}Id`] };
			this.$emit("setItemSelected", data);
		},
	},

	data() {
		return {
			isHide: true,
		};
	},
};
</script>

<style>
/* Combobox */
.m-combobox {
	cursor: pointer;
	position: relative;
	display: flex;
	border-radius: 4px;
	min-width: 100px;
	height: 31px;
	border: 1px solid #c9ccd2;
	-moz-user-select: none; /* Firefox */
	-ms-user-select: none; /* Internet Explorer */
	-khtml-user-select: none; /* KHTML browsers (e.g. Konqueror) */
	-webkit-user-select: none; /* Chrome, Safari, and Opera */
	-webkit-touch-callout: none; /* Disable Android and iOS callouts*/
}

.m-combobox .input {
	width: calc(100% - 48px);
	height: 31px;
	outline: none;
	margin: 0 21px 0 16px;
	padding-right: 20px;
	border-style: hidden;
	line-height: 31px;
	text-align: left;
}

.m-combobox:hover {
	border: 1px solid #bbb;
}

.m-combobox .input::placeholder {
	font-size: 11px;
}
.m-combobox .comboboxBtn {
	position: absolute;
	border-radius: 4px;
	right: 0;
	width: 31px;
	height: 31px;
	outline: none;
	cursor: pointer;
	background-color: #fff;
	font-size: 20px;
	line-height: 30px;
	font-weight: 600;
	text-align: center;
	color: #626262;
}

.m-combobox .comboboxBtn:hover {
	background-color: #c9ccd2;
}

.checkmark2 {
	width: 31px;
	height: 31px;
	display: flex;
}

.m-combobox-item.itSelected .checkmark2 div {
	width: 5px;
	height: 10px;
	border: solid #fff;
	border-width: 0 2px 2px 0;
	margin: 5px auto;
	-webkit-transform: rotate(45deg);
	-ms-transform: rotate(45deg);
	transform: rotate(45deg);
}
.m-combobox .m-combobox-data {
	position: absolute;
	top: 33px;
	background-color: #ffffff;
	width: 100%;
	z-index: 3;
	border-radius: 5px;
	border: 1px solid #c9ccd2;
}

.m-combobox.end .m-combobox-data {
	top: -120px;
}

.isHide {
	display: none;
}
.reverse {
	transform: rotate(180deg);
}

.m-combobox .m-combobox-data .m-combobox-item {
	display: flex;
	height: 31px;
	width: 100%;
	line-height: 31px;
	border-radius: 4px;
}

.m-combobox .m-combobox-data .m-combobox-item .textCbx {
	width: calc(100% - 31px);
}

.m-combobox .m-combobox-data .m-combobox-item:hover {
	background-color: #e9ebee;
	cursor: pointer;
}

.m-combobox .m-combobox-data .itSelected {
	background-color: #248b15 !important;
	color: #ffffff;
}
</style>
