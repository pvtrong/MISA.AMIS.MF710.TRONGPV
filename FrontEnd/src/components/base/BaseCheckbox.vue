<template>
	<div class="cell">
		<label class="input-container">
			<input type="checkbox" :class="{ checked: this.status }" />
			<span @click="changeCheckbox()" class="checkmark"></span>
		</label>
	</div>
</template>

<script>
export default {
	props: {
		status: Boolean,
		id: String,
	},
	data() {
		return {};
	},
	methods: {
		// Thay đổi trạng thái checkbox
		changeCheckbox() {
			let data = { status: !this.status, id: this.id };
			this.$emit("changeCheckbox", data);
		},
	},
	computed: {},
};
</script>

<style>
.input-container {
	display: block;
	position: relative;
	padding-left: 35px;
	margin-bottom: 22px;
	cursor: pointer;
	font-size: 22px;
	-webkit-user-select: none;
	-moz-user-select: none;
	-ms-user-select: none;
	user-select: none;
}

.input-container input {
	position: absolute;
	opacity: 0;
	cursor: pointer;
	height: 0;
	width: 0;
}

.checkmark {
	position: absolute;
	left: 0;
	height: 20px;
	width: 20px;
	background-color: #ffffff;
	border-radius: 4px;
	border: solid 1px #bbbbbb;
}

.input-container:hover input ~ .checkmark {
	background-color: #e5e5e5;
}

.input-container input.checked ~ .checkmark {
	background-color: #019160;
}

.checkmark:after {
	content: "";
	position: absolute;
	display: none;
}

.input-container input.checked ~ .checkmark:after {
	display: block;
}

.input-container .checkmark:after {
	left: 6px;
	top: 2px;
	width: 5px;
	height: 10px;
	border: solid #ffffff;
	border-width: 0 3px 3px 0;
	-webkit-transform: rotate(45deg);
	-ms-transform: rotate(45deg);
	transform: rotate(45deg);
}
</style>
