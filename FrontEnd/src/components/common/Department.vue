<template>
	<BaseCombobox
		@setItemSelected3="setItemSelected3"
		@setItemSelected4="setItemSelected4"
		@setItemSelected2="setItemSelected"
		:faCaretUp="faCaretUp"
		:faCaretDown="faCaretDown"
		v-model="itemSelected"
		@setItemSelected="setItemSelected"
		:itemSelected="itemSelected"
		:category="category"
		:end="end"
		:header="header"
		v-bind:content="departments"
	></BaseCombobox>
</template>

<script>
import * as axios from "axios";
import BaseCombobox from "../base/BaseCombobox.vue";
export default {
	props: ["departmentId2", "end", "faCaretUp", "faCaretDown"],

	async created() {
		this.$parent.$on("showCombobox", this.showCombobox);
		const response = await axios.get(
			"https://localhost:44349/api/Departments/"
		);
		this.departments = response.data;
	},
	mounted() {},
	methods: {
		setItemSelected4() {
			this.$emit("setItemSelected4");
		},
		// Hàm đặt giá trị
		setItemSelected3() {
			this.$emit("setItemSelected3");
		},

		// Hàm xổ xuống của đơn vị
		showCombobox() {
			this.$emit("showCombobox");
		},

		// Hàm chọn giá trị
		setItemSelected(data) {
			this.$emit("setItemSelected", data);
		},
	},
	computed: {
		itemSelected: function() {
			return { departmentId: this.departmentId2 };
		},
	},

	data() {
		return {
			departments: [],
			category: "department",
			header: "Tất cả phòng ban",
		};
	},
	components: {
		BaseCombobox,
	},
};
</script>

<style></style>
