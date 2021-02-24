<template>
	<div class="content">
		<div class="header-content">
			<div class="title">Nhân viên</div>
			<div class="content-feature">
				<button
					@click="btnAddOnClick"
					id="btnAdd"
					class="m-btn m-btnIcon m-btn-default"
				>
					<div class="btn-text">Thêm</div>
				</button>
				<EmployeeListDetail
					@addEmployeeBank="addEmployeeBank"
					@changeEmployeeBanks="changeEmployeeBanks"
					@deleteEmployeeBanks="deleteEmployeeBanks"
					@closePopup="closePopup"
					@closePopup2="closePopup2"
					:isHide="isHideParent"
					:employee="this.dialog.employee"
					:mode="this.dialog.mode"
					@notifyBoard="notifyBoard"
				></EmployeeListDetail>
			</div>
		</div>
		<div class="filter-bar">
			<div class="filter-left">
				<input
					v-model="filter.keyword"
					@change="changeInput()"
					id="txtSearchEmployee"
					class="icon-search input-search"
					type="text"
					placeholder="Tìm theo mã, tên nhân viên"
				/>
			</div>
		</div>
		<div
			class="grid grid-employee el-table el-table--fit el-table--scrollable-y el-table--enable-row-hover el-table--enable-row-transition"
		>
			<table
				id="tbListData"
				cellspacing="0"
				cellpadding="0"
				border="0"
				class="el-table__body"
				style="min-width: 100%"
			>
				<thead>
					<tr class="el-table__row">
						<th
							colspan="1"
							rowspan="1"
							class="el-table_30_column_114 is-leaf"
							fieldName="EmployeeCode"
						>
							<div class="cell">Mã nhân viên</div>
						</th>
						<th
							colspan="1"
							rowspan="1"
							class="el-table_30_column_115 is-leaf"
							fieldName="FullName"
						>
							<div class="cell">Tên nhân viên</div>
						</th>
						<th
							colspan="1"
							rowspan="1"
							class="el-table_30_column_116 is-leaf"
							fieldName="Position"
						>
							<div class="cell">Chức danh</div>
						</th>
						<th
							colspan="1"
							rowspan="1"
							class="el-table_30_column_116 is-leaf"
							fieldName="DepartmentName"
						>
							<div class="cell">Tên đơn vị</div>
						</th>
						<th
							colspan="1"
							rowspan="1"
							class="el-table_30_column_116 is-leaf"
							fieldName="BankNumber"
						>
							<div class="cell">Số tài khoản</div>
						</th>
						<th
							colspan="1"
							rowspan="1"
							class="el-table_30_column_116 is-leaf"
							fieldName="BankName"
						>
							<div class="cell">Tên ngân hàng</div>
						</th>
						<th
							colspan="1"
							rowspan="1"
							class="el-table_30_column_116 is-leaf"
							fieldName="Status"
						>
							<div class="cell">Trạng thái</div>
						</th>
						<th
							colspan="1"
							rowspan="1"
							class="el-table_30_column_116 is-leaf"
							fieldName="Branch"
						>
							<div class="cell">Chi nhánh</div>
						</th>
						<th
							colspan="1"
							rowspan="1"
							class="el-table_30_column_116 is-leaf"
							fieldName="Feature"
						>
							<div class="cell">Chức năng</div>
						</th>
					</tr>
				</thead>
				<tbody>
					<tr
						class="el-table__row"
						v-for="employee in employees"
						:key="employee.employeeId"
						@dblclick="rowOnClick({ ...employee })"
					>
						<td>
							<div class="cell">
								{{
									employee !== null &&
									employee.employeeCode !== null
										? employee.employeeCode
										: ""
								}}
							</div>
						</td>
						<td>
							<div class="cell">
								{{
									employee !== null &&
									employee.fullName !== null
										? employee.fullName
										: ""
								}}
							</div>
						</td>
						<td>
							<div class="cell">
								{{
									employee !== null &&
									employee.position !== null
										? employee.positionName
										: ""
								}}
							</div>
						</td>
						<td>
							<div class="cell">
								{{
									employee !== null &&
									employee.departmentName !== null
										? employee.departmentName
										: ""
								}}
							</div>
						</td>
						<td>
							<div class="cell">
								{{
									employee !== null &&
									employee.employeeBanks !== undefined &&
									employee.employeeBanks.length > 0
										? employee.employeeBanks[0].bankNumber
										: ""
								}}
							</div>
						</td>
						<td>
							<div class="cell">
								{{
									employee !== null &&
									employee.employeeBanks !== undefined &&
									employee.employeeBanks.length > 0
										? employee.employeeBanks[0].bankName
										: ""
								}}
							</div>
						</td>
						<td>
							<div class="cell">
								{{
									employee !== null &&
									employee.employeeBanks !== undefined &&
									employee.employeeBanks.length > 0
										? formatStatus(
												employee.employeeBanks[0].status
										  )
										: ""
								}}
							</div>
						</td>
						<td>
							<div class="cell">
								{{
									employee !== null &&
									employee.employeeBanks !== undefined &&
									employee.employeeBanks.length > 0
										? employee.employeeBanks[0].branch
										: ""
								}}
							</div>
						</td>
						<td style="width: 30px">
							<BaseDropBox
								:status="
									employee !== null &&
									employee.employeeBanks !== undefined &&
									employee.employeeBanks.length > 0
										? formatStatus(
												employee.employeeBanks[0].status
										  )
										: ''
								"
								@changeStatusBanking="
									changeStatusBanking(
										employee.employeeId,
										employee.employeeBanks[0]
									)
								"
								@deleteOnClick="
									deleteOnClick(
										[employee.employeeId],
										employee.employeeCode
									)
								"
								@cloneOnClick="cloneOnClick({ ...employee })"
								@editOnClick="rowOnClick({ ...employee })"
							></BaseDropBox>
						</td>
					</tr>
				</tbody>
			</table>
		</div>
		<div class="paging-bar">
			<div class="paging-record-info">
				Tổng số: <b>{{ this.employees[0].totalEmployees }}</b> bản ghi.
			</div>

			<div class="paging-record-option">
				<Combobox
					:faCaretUp="false"
					:faCaretDown="true"
					v-model="setItemSelected"
					@setItemSelected="setItemSelected"
					:end="pagi.end"
					:itemSelected="pagi.itemSelected"
					:category="pagi.category"
					:header="pagi.header"
					:content="pagi.pagis"
				>
				</Combobox>
			</div>
			<div class="pagination-row">
				<button
					:disabled="pagi.pageNumber <= 1"
					@click="getOffset(pagi.pageNumber - 1)"
					class="pagination-button"
				>
					Trước
				</button>
				<span
					v-for="(item, index) in new Array(getNumberPages)"
					:key="index"
				>
					<button
						@click="getOffset(index + 1)"
						class="pagination-button "
						:class="{
							active: pagi.pageNumber == index + 1,
							nonee:
								getNumberPages > 6 &&
								index + 1 != 1 &&
								index + 1 != 2 &&
								index + 1 != getNumberPages &&
								index + 1 != getNumberPages - 1 &&
								index + 1 != pagi.pageNumber,
						}"
					>
						{{ index + 1 }}
					</button>
				</span>

				<button
					:disabled="pagi.pageNumber >= getNumberPages"
					@click="getOffset(pagi.pageNumber + 1)"
					class="pagination-button"
				>
					Sau
				</button>
			</div>
		</div>
		<BasePopUp
			:isHide="!this.popup.isHide"
			:header="this.popup.header"
			:type="this.popup.type"
			:content="this.popup.content"
			@notifyDanger="notifyDanger"
			:className="this.popup.className"
			:data="this.popup.data"
		/>
	</div>
</template>

<script>
import * as axios from "axios";
import BaseCheckbox from "../../../components/base/BaseCheckbox.vue";
import Combobox from "../../../components/base/BaseCombobox.vue";
import BaseDropBox from "../../../components/base/BaseDropBox.vue";
import Departments from "../../../components/common/Department.vue";
import EmployeeListDetail from "./EmployeeListDetail.vue";
import BasePopUp from "../../../components/base/BasePopUp.vue";
export default {
	data() {
		return {
			threeDotPrev: 0,
			threeDotPrev: 0,
			/// * bộ dữ liệu để filter
			filter: {
				keyword: "",
			},

			isHideParent: true, /// * trạng thái dialog
			offset: 0, /// * offset trang

			/// * Dữ liệu nhân viên
			employees: [],
			arrBanks: [],
			/// * Dữ liệu phân trang
			pagi: {
				pagis: [
					{ pagiId: 1, pagiName: "10 bản ghi/trang", value: 10 },
					{ pagiId: 2, pagiName: "20 bản ghi/trang", value: 20 },
					{ pagiId: 3, pagiName: "30 bản ghi/trang", value: 30 },
					{ pagiId: 4, pagiName: "50 bản ghi/trang", value: 50 },
					{ pagiId: 5, pagiName: "100 bản ghi/trang", value: 100 },
				],
				itemSelected: { pagiId: 1 },
				category: "pagi",
				end: true,
				header: "Số nhân viên/trang",
				pageNumber: 1,
			},

			// Dữ liệu của dialog
			dialog: {
				mode: "add",
				employee: {
					departmentId: "",
					employeeBanks: [],
				},
			},

			/// * Data của Pop up
			popup: {
				isHide: false,
				header: "",
				type: "danger",
				data: [],
				className: "",
				content: "Bạn có chắc muốn xóa bản ghi này không?",
			},

			selected: [],
		};
	},

	// ban đầu lấy dữ liệu để render
	async created() {
		const response = await axios.get(
			"https://localhost:44349/api/Employees?keyword=" +
				this.filter.keyword +
				"&limitParam=" +
				this.getLimit +
				"&offsetParam=" +
				this.offset
		);

		this.employees = await response.data;
		const employeeBanks = await axios.get(
			"https://localhost:44349/api/EmployeeBanks"
		);
		this.arrBanks = employeeBanks.data;
		let empty = [];
		this.employees.forEach(function(employee) {
			employee.employeeBanks = [];
			employeeBanks.data.map(function(employeeBank) {
				if (employee.employeeId === employeeBank.employeeId) {
					employee.employeeBanks.push(employeeBank);
				}
			});
			empty.push(employee);
		});
		this.employees = empty;
	},

	props: {},

	name: "Employees",

	components: {
		EmployeeListDetail,
		Combobox,
		Departments,
		BaseCheckbox,
		BasePopUp,
		BaseDropBox,
	},

	methods: {
		getOffset(index) {
			console.log(index);
			this.pagi.pageNumber = index;
			this.offset = (index - 1) * this.getLimit;
			this.render();
		},
		// Hàm thêm dòng ngân hàng tạm thời
		addEmployeeBank(data) {
			if (!data) {
				this.dialog.employee.employeeBanks.push({
					bankCity: "",
					bankNumber: "",
					bankName: "",
					branch: "",
					branch: "",
				});
			} else
				this.dialog.employee.employeeBanks.push({
					bankCity: "",
					bankNumber: "",
					bankName: "",
					branch: "",
					branch: "",
					employeeId: data,
				});
		},

		// Hàm truyền data vào pop up để mở pop up
		async notifyDanger(data) {
			console.log(data.className);
			if (data.accept === true) {
				const res = await axios.delete(
					"https://localhost:44349/api/" + data.className,
					{
						data: data.id,
					}
				);

				this.render();
			}
			this.popup.isHide = false;
		},

		/// * Hàm render lại dữ liệu khi click sự kiện
		async render() {
			console.log("render");
			const response = await axios.get(
				"https://localhost:44349/api/Employees?keyword=" +
					this.filter.keyword +
					"&limitParam=" +
					this.getLimit +
					"&offsetParam=" +
					this.offset
			);
			let self = this;
			this.employees = await response.data;
			var empty = [];
			this.employees.forEach(function(employee) {
				employee.employeeBanks = [];
				self.arrBanks.map(function(employeeBank) {
					if (employee.employeeId === employeeBank.employeeId) {
						employee.employeeBanks.push(employeeBank);
					}
				});
				empty.push(employee);
			});
			self.employees = empty;
		},

		// * Hàm để lấy số nhân viên/1 trang từ component combobox
		setItemSelected(data) {
			this.pagi.pageNumber = 1;
			this.offset = 0;
			this.pagi.itemSelected = { pagiId: data.id };
			this.render();
		},

		// * Hàm xử lý sự kiện thêm
		async btnAddOnClick() {
			this.dialog.employee = await {
				departmentId: "",
				gender: 0,
				employeeBanks: [],
			};
			let res = await this.getNextCode();
			let str = await "NV";
			for (
				let i = 0;
				i < 6 - parseInt(res.slice(2, 7) + 1).toString().length;
				i++
			) {
				str += "0";
			}
			let str1 = (await parseInt(res.slice(2, 7))) + 1;
			str += await str1;
			console.log(str);
			this.dialog.employee.employeeCode = await str;

			this.isHideParent = await true;
			this.isHideParent = await false;
		},

		/// * Hàm lấy mã số nhân viên lớn nhất
		async getNextCode() {
			let response = await axios.get(
				"https://localhost:44349/api/Employees/CodeMax"
			);
			return response.data[0].employeeCode;
		},

		//* Hàm mở dialog detail
		async closePopup(value) {
			const employeeBanks = await axios.get(
				"https://localhost:44349/api/EmployeeBanks"
			);
			this.arrBanks = await employeeBanks.data;
			await this.render();
			if (value === false) {
				await this.btnAddOnClick();
				this.isHideParent = false;
			} else {
				this.isHideParent = value;
			}
		},
		// popup để xử lý nút hủy sẽ đỡ nặng
		closePopup2() {
			this.isHideParent = true;
		},

		// Hàm thay đổi tài khoản ngân hàng của nhân viên đó
		changeEmployeeBanks(data) {
			let self = this;
			console.log(data);
			let length = this.employees.length;
			for (var i = 0; i < length; i++) {
				if (self.employees[i].employeeId === data.employeeId) {
					self.employees[i].employeeBanks = data.employeeBanks;
				}
			}
		},

		// Hàm xóa tài khoản ngân hàng của nhân viên đó
		async deleteEmployeeBanks() {
			let self = this;
			const employeeBanks = await axios.get(
				"https://localhost:44349/api/EmployeeBanks"
			);

			self.arrBanks = await employeeBanks.data;
			var empty = [];
			self.employees.forEach(function(employee) {
				employee.employeeBanks = [];
				self.arrBanks.map(function(employeeBank) {
					if (employee.employeeId === employeeBank.employeeId) {
						employee.employeeBanks.push(employeeBank);
					}
				});
				empty.push(employee);
			});
			self.employees = empty;

			self.employees.forEach(function(item) {
				if (item.employeeId === self.dialog.employee.employeeId) {
					self.dialog.employee.employeeBanks = item.employeeBanks;
				}
			});
		},

		/// * Hàm render lại dữ liệu khi ấn search
		changeInput() {
			this.offset = 0;
			this.pagi.pageNumber = 1;
			this.render();
		},

		//#region Các hàm chức năng
		// Hàm xử lý sự kiện click nút thay đổi trạng thái của tài khoản ngân hàng
		async changeStatusBanking(employeeId, employeeBank) {
			employeeBank.status = 1 - employeeBank.status;
			let res3 = await axios.put(
				"https://localhost:44349/api/EmployeeBanks/",
				employeeBank
			);
			this.render();
		},

		// Hàm hiện cảnh báo lỗi
		async notifyBoard(data) {
			console.log(data);
			this.popup.content = data.content;
			this.popup.type = "notify";
			this.popup.isHide = true;
		},

		// Hàm xử lý sự kiện nút xóa
		async deleteOnClick(employeeIds, employeeCode) {
			this.popup.content =
				"Bạn có thực sự muốn xóa Nhân viên <" +
				employeeCode +
				"> không?";
			this.popup.type = "danger";
			this.popup.isHide = true;
			this.popup.className = "Employees";
			this.popup.data = employeeIds;
		},

		// Hàm xử lý sự kiện nút nhân bản:
		async cloneOnClick(employee) {
			let res = await this.getNextCode();
			let str = await "NV";
			for (
				let i = 0;
				i < 6 - parseInt(res.slice(2, 7) + 1).toString().length;
				i++
			) {
				str += "0";
			}
			let str1 = (await parseInt(res.slice(2, 7))) + 1;
			str += await str1;
			console.log("str:" + str);

			this.dialog.employee = await employee;
			this.dialog.employee.employeeCode = await str;
			this.dialog.employee.dateOfIN = this.convert(
				this.dialog.employee.dateOfIN
			);
			this.dialog.employee.dateOfBirth = this.convert(
				this.dialog.employee.dateOfBirth
			);
			this.isHideParent = false;
			this.render();
		},

		///Hàm xử lý sự kiện click nút sửa
		async rowOnClick(employee) {
			this.dialog.employee = await employee;
			this.dialog.employee.dateOfIN = this.convert(
				this.dialog.employee.dateOfIN
			);
			this.dialog.employee.dateOfBirth = this.convert(
				this.dialog.employee.dateOfBirth
			);
			this.dialog.mode = "edit";
			this.isHideParent = false;
		},
		//#endregion

		//#region Các hàm format
		// * Hàm format lại ngày
		formatDate(date) {
			var date2 = new Date(date);
			var year = date2.getFullYear();
			if (year < 1000) return "";
			// lấy ngày:
			var day = date2.getDate();
			if (day < 10) day = "0" + day;

			// lấy tháng:
			var month = date2.getMonth() + 1;
			if (month < 10) month = "0" + month;
			// lấy năm:

			return day + "/" + month + "/" + year;
		},

		/// * Convert datetime in db to date input html
		convert(str) {
			var date = new Date(str),
				mnth = ("0" + (date.getMonth() + 1)).slice(-2),
				day = ("0" + date.getDate()).slice(-2);
			return [date.getFullYear(), mnth, day].join("-");
		},

		// * Hàm fomart lại status
		formatStatus(status) {
			if (status === 0) {
				return "Ngừng sử dụng";
			} else return "Đang sử dụng";
		},
		//#endregion
	},

	computed: {
		getNumberPages: function() {
			return Math.ceil(this.employees[0].totalEmployees / this.getLimit);
		},
		getSelected: function() {
			return this.selected;
		},

		// * hàm lấy dữ liệu nhân viên trong trang đó
		getEmployees: function() {
			return this.employees;
		},

		/// * Hàm lấy số nhân viên/trang
		getLimit: function() {
			return this.pagi.pagis.filter(
				(item) => item.pagiId === this.pagi.itemSelected.pagiId
			)[0].value;
		},

		/// * Hàm lấy offset mới của trang
		getOffsetNew: function() {
			return this.offset + 1;
		},
	},
};
</script>

<style scope>
/*Page tile*/
.content .header-content {
	padding: 8px 0 16px 0;
	display: flex;
	align-items: center;
}

.content .header-content .title {
	font-size: 25px !important;
	font-weight: bold;
	color: #111 !important;
}

.content .header-content .content-feature {
	position: absolute;
	right: 16px;
}

/* Paging */
.content .paging-bar {
	height: 56px;
}

#btnAdd {
	border-radius: 30px;
	padding: 8ox 20px;
}
.pagination-button {
	border: none;
	cursor: pointer;
	background-color: #fff;
	border-radius: 3px;
	border: 1px solid #fff;
}
.pagination-button:hover {
	border: 1px solid #bbb;
}

.pagination-button.active {
	border: 1px solid #bbb !important;
	font-weight: bold;
	background-color: #bbb;
}
.pagination-button:focus {
	outline: none;
}

.pagination-button:disabled {
	cursor: default;
	border: none;
}

.nonee {
	display: none;
}
</style>
