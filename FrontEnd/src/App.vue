<template>
	<!--  Phạm Văn Trọng MF710 -->

	<div id="app">
		<TheHeader></TheHeader>
		<TheNavbar></TheNavbar>
		<EmployeeList></EmployeeList>
		<!-- <CustomerList /> -->
	</div>
</template>

<script>
import TheHeader from "./components/useOnly/TheHeader.vue";
import TheNavbar from "./components/useOnly/TheNavbar.vue";
// import CustomerList from "./views/dictionary/customer/CustomerList.vue";
import EmployeeList from "./views/dictionary/employee/EmployeeList.vue";
export default {
	data() {
		return {};
	},
	created() {},
	name: "App",
	components: {
		TheHeader,
		TheNavbar,
		// CustomerList,
		EmployeeList,
	},
};
</script>

<style>
@import "./assets/css/common/main.css";
</style>
