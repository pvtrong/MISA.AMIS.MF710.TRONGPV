<template>
	<div class="header">
		<div class="department-info">
			<BaseCombobox
				:faCaretUp="true"
				:faCaretDown="false"
				icon="up"
				@setItemSelected="setItemSelected"
				:end="office.end"
				:itemSelected="office.itemSelected"
				:category="office.category"
				:header="office.header"
				:content="office.offices"
			></BaseCombobox>
		</div>
		<div class="account-info">
			<div class="tools">
				<input
					class="icon-search input-search2"
					type="text"
					placeholder="Nhập từ khóa tìm kiếm"
				/>
				<div id="tools-threedot"></div>
				<div id="tools-setting"></div>

				<div id="tools-message"></div>
				<div id="tools-help"></div>
				<div id="tools-notify"></div>
			</div>
			<div class="account-avatar"></div>
			<div class="account-name">Phạm Văn Trọng</div>
			<div class="account-option icon-option-default-16"></div>
		</div>
	</div>
</template>

<script>
import BaseCombobox from "../base/BaseCombobox";
export default {
	methods: {
		setItemSelected(data) {
			this.office.itemSelected = { officeId: data.id };
		},
	},
	components: {
		BaseCombobox,
	},
	data() {
		return {
			office: {
				offices: [
					{ officeId: 1, officeName: "MISA" },
					{ officeId: 2, officeName: "MISA" },
				],
				itemSelected: { officeId: 1 },
				category: "office",
				end: false,
				header: "Tất cả nhà hàng",
			},
		};
	},
};
</script>

<style scope>
.tools {
	margin-right: 20px;
	cursor: pointer;
	display: flex;
	align-items: center;
}
.tools div {
	border: 1px solid #fff;
	border-radius: 4px;
}

.tools div:hover {
	border: 1px solid #393a3d;
}
#tools-notify {
	width: 34px;
	height: 48px;
	background-image: url("../../assets/content/icon/Sprites.64af8f61.svg");
	background-position: -783px -17px !important;
	background-repeat: no-repeat;
}

#tools-help {
	width: 34px;
	height: 48px;
	background-image: url("../../assets/content/icon/Sprites.64af8f61.svg");
	background-position: -726px -17px !important;
	background-repeat: no-repeat;
}

#tools-message {
	width: 34px;
	height: 48px;
	background-image: url("../../assets/content/icon/Sprites.64af8f61.svg");
	background-position: -894px -17px !important;
	background-repeat: no-repeat;
}

#tools-setting {
	width: 34px;
	height: 48px;
	background-image: url("../../assets/content/icon/Sprites.64af8f61.svg");
	background-position: -670px -17px !important;
	background-repeat: no-repeat;
}
#tools-threedot {
	width: 34px;
	height: 48px;
	background-image: url("../../assets/content/icon/Sprites.64af8f61.svg");
	background-position: -563px -17px !important;
	background-repeat: no-repeat;
}

.header {
	position: absolute;
	top: 0;
	left: 179px;
	height: 50px;
}
.department-info .m-combobox {
	border: none !important;
}

.header {
	display: flex;
	align-items: center;
	width: calc(100% - 179px);
	border-bottom: 1px solid #bbbbbb;
}

.header .department-info {
	padding: 16px;
	font-size: 16px;
	min-width: 40px;
}
.header .account-info {
	position: absolute;
	right: 24px;
	display: flex;
	align-items: center;
}

.header .account-info .account-avatar {
	width: 30px;
	cursor: pointer;
	height: 30px;
	border: 1px solid #ccc;
	border-radius: 50%;
	background-image: url("../../assets/content/icon/avatar-default.png");
	background-size: contain;
}

.header .account-info .account-name {
	padding: 10px;
	cursor: pointer;
}

.header .account-info .account-option {
	height: 16px;
	cursor: pointer;
}
</style>
