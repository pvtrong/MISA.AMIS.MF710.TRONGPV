<template>
	<div class="m-radio">
		<div class="m-label">{{ header }}</div>
		<div class="m-radio-group" id="rdGender">
			<div
				v-for="item in content"
				:key="item.index"
				class="m-radio-item"
				:class="{ 'mg-left-10px': item.index > 1 }"
			>
				<input
					:class="{
						checked:
							itemSelected[`${category}Id`] === item['value'],
					}"
					type="radio"
					:fieldname="category"
					:value="item.value"
					:name="category"
				/>
				<span
					:value="item.value"
					:id="'gender' + item['value']"
					@keyup.enter="focusNext"
					@click="setItemSelected(item)"
				></span>
				<label for="rdMale">{{ item[category + "Name"] }}</label>
			</div>
		</div>
	</div>
</template>

<script>
export default {
	created() {
		this.$parent.$on("focusGender", this.showCombobox);
		window.addEventListener("keyup", this.setselected);
	},
	data() {
		return {
			isHide: true,
		};
	},
	props: ["header", "content", "itemSelected", "category"],
	computed: {},
	methods: {
		// Hàm xử lý sự kiện focus sang cái tab tiếp theo
		focusNext() {
			console.log(1234567);
			this.$emit("setItemSelected2");
		},

		// Hàm xử lý sự kiện focus vào item (giới tính) tiếP theo
		focusGender() {
			console.log("focus");
			document.getElementById("gender0").focus();
		},

		// Hàm xử lý sự kiện người dùng dùng bàn phím để đặt giá trị item
		setselected(event) {
			console.log(event);
			let index = 0;
			console.log(this.isHide);
			for (let i = 0; i < this.content.length; i++) {
				if (
					this.content[i][`genderId`] ===
					this.itemSelected[`genderId`]
				)
					index = i;
			}
			if (event.ctrlKey === true && event.which === 37) {
				if (index == 0) {
					index = 3;
					this.setItemSelected(this.content[index - 1]);
				} else {
					this.setItemSelected(this.content[index - 1]);
				}
			} else if (event.ctrlKey === true && event.which === 39) {
				console.log(222222);
				if (index == 2) {
					index = -1;
					this.setItemSelected(this.content[index + 1]);
				} else {
					this.setItemSelected(this.content[index + 1]);
				}
			}
		},

		// Hàm lấy giá trị được chọn
		itSelect(item) {
			return (
				item[`${this.category}Id`] ===
				this.itemSelected[`${this.category}Id`]
			);
		},

		// Hàm lấy giá trị được chọn
		getItemSelected() {
			let temp = this.content.filter(
				(item) =>
					item[`${this.category}Id`] ===
					this.itemSelected[`${this.category}Id`]
			);
			return temp;
		},

		// Hàm đặt giá trị được chọn
		setItemSelected(item) {
			this.isHide = false;
			let data = { id: item[`${this.category}Id`] };
			this.$emit("setItemSelected", data);
		},

		showCombobox() {
			this.isHide = !this.isHide;
			console.log(this.isHide);
		},
	},
};
</script>

<style>
.m-radio-group {
	display: flex;
	height: 32px;
}

.m-radio-group .m-radio-item {
	display: flex;
	align-items: center;
}

input[type="radio"] + span {
	width: 18px;
	height: 18px;
	border-radius: 18px;
	position: relative;
	background-size: contain;
	content: "";
	display: inline-block;
	visibility: visible;
	/*border: 1px solid #BBBBBB;*/
	cursor: pointer;
	border: 1px solid #bbbbbb;
	border-radius: 50%;
	margin-left: 5px;
	margin-right: 5px;
}

input[type="radio"] {
	display: none;
}

input[type="radio"].checked + span {
	width: 20px;
	height: 20px;
	border-radius: 20px;
	position: relative;
	background-image: url("../../assets/content/icon/radio.svg");
	background-repeat: no-repeat;
	background-position: center;
	background-size: auto;
	visibility: visible;
	cursor: pointer;
}
</style>
