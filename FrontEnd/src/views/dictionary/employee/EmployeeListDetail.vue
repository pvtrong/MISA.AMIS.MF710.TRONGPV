<template>
	<div :class="{ isHide: isHide }" class="m-dialog dialog-detail">
		<div class="dialog-modal"></div>
		<div class="dialog-content">
			<div class="dialog-header" @mousedown="dragElement()">
				<div class="dialog-header-title">
					THÔNG TIN NHÂN VIÊN
				</div>
				<div class="type-customer">
					<input type="checkbox" /> Là khách hàng
				</div>
				<div class="type-customer">
					<input type="checkbox" />Là nhà cung cấp
				</div>
				<div class="dialog-header-close">
					<button class="help-btn" title="Giúp (F1)"></button>
					<button
						class="close-btn"
						title="Đóng (ESC)"
						v-on:click="btnCancelOnClick"
					></button>
				</div>
			</div>
			<div class="dialog-body">
				<div class="m-row mg-top-0 m-flex">
					<div class="m-col el-left  m-flex-2">
						<div class="m-row mg-top-0 m-flex">
							<div class="m-col m-flex-2">
								<div class="m-label">
									Mã <span class="label-required">*</span>
								</div>
								<div>
									<input
										@keyup.enter.exact="
											$refs.txtFullName.focus
										"
										tabindex="1"
										@focus="noCheckValidate('EmployeeCode')"
										@blur="
											checkValidateEmployeeCode(employee)
										"
										ref="txtEmployeeCode"
										id="txtEmployeeCode"
										name="EmployeeCode"
										fieldName="EmployeeCode"
										type="text"
										v-model="employee.employeeCode"
									/>
								</div>
							</div>
							<div class="m-flex-3  mg-left-5px">
								<div class="m-label">
									Tên <span class="label-required">*</span>
								</div>
								<div>
									<input
										@keyup.enter.exact="focusCombobox"
										ref="txtFullName"
										tabindex="2"
										@keyup.shift.enter.prevent="
											$refs.txtEmployeeCode.focus
										"
										@focus="noCheckValidate('FullName')"
										@blur="checkValidateFullName(employee)"
										id="txtFullName"
										name="FullName"
										fieldName="FullName"
										class="input-required"
										type="text"
										v-model="employee.fullName"
									/>
								</div>
							</div>
						</div>
						<div class="m-row m-flex">
							<div class="m-flex-1">
								<div class="m-label">
									Đơn vị <span class="label-required">*</span>
								</div>
								<Department
									@setItemSelected3="setItemSelected3"
									@setItemSelected4="setItemSelected4"
									ref="txtDepartmentId"
									:tabindex="3"
									@focus="noCheckValidate('DepartmentId')"
									id="txtDepartmentId"
									:end="false"
									:faCaretUp="true"
									:faCaretDown="false"
									:departmentId2="employee.departmentId"
									@setItemSelected="setDepartmentId"
								></Department>
							</div>
						</div>
						<div class="m-row m-flex">
							<div class="m-flex-1">
								<div class="m-label" title="Chức danh">
									Chức danh
								</div>
								<div>
									<input
										@keyup.enter.exact="
											$refs.txtDateOfBirth.focus
										"
										@keyup.shift.enter.prevent="
											focusCombobox
										"
										tabindex="4"
										ref="txtPosition"
										id="txtPosition"
										name="PositionName"
										fieldName="text"
										type="text"
										v-model="employee.positionName"
									/>
								</div>
							</div>
						</div>
					</div>
					<div class="m-col el-left  m-flex-2">
						<div class="m-row mg-top-0 mg-left-20px m-flex">
							<div class="m-flex-2">
								<div class="m-label">Ngày sinh</div>
								<input
									@keyup.shift.enter.prevent="
										$refs.txtPosition.focus
									"
									@keyup.enter.exact="
										$refs.txtIdentityNumber.focus
									"
									id="txtDateOfBirth"
									ref="txtDateOfBirth"
									tabindex="5"
									class="m-combobox-input"
									type="date"
									v-model="employee.dateOfBirth"
									autocomplete="off"
								/>
							</div>
							<div class="m-flex-3 mg-left-10px">
								<BaseRadio
									@setItemSelected2="setItemSelected2"
									v-model="setItemSelected"
									@setItemSelected="setItemSelected"
									:itemSelected="{
										genderId: this.employee.gender,
									}"
									:category="gender.category"
									:header="gender.header"
									:content="gender.genders"
								></BaseRadio>
							</div>
						</div>
						<div class="m-row m-flex mg-left-20px">
							<div class="m-flex-3">
								<div
									class="m-label"
									title="Số chứng minh thư nhân dân hoặc căn cước công dân"
								>
									Số CMTND/ Căn cước
								</div>
								<div>
									<input
										@keyup.shift.enter.prevent="
											$refs.txtDateOfBirth.focus
										"
										@keyup.enter.exact="
											$refs.txtDateOfIN.focus
										"
										ref="txtIdentityNumber"
										tabindex="7"
										id="txtIdentityNumber"
										name="IdentifyNumber"
										fieldName="text"
										type="text"
										v-model="employee.identifyNumber"
									/>
								</div>
							</div>
							<div class="m-flex-2 mg-left-5px">
								<div class="m-label">Ngày cấp</div>
								<input
									@keyup.shift.enter.prevent="
										$refs.txtIdentityNumber.focus
									"
									@keyup.enter.exact="
										$refs.txtPlaceOfIN.focus
									"
									ref="txtDateOfIN"
									tabindex="8"
									class="m-combobox-input"
									type="date"
									autocomplete="off"
									v-model="employee.dateOfIN"
								/>
							</div>
						</div>

						<div class="m-row m-flex mg-left-20px">
							<div class=" m-flex-4">
								<div class="m-label">Nơi cấp</div>
								<div>
									<input
										@keyup.shift.enter.prevent="
											$refs.txtDateOfIN.focus
										"
										@keyup.enter.exact="
											$refs.txtAddress.focus
										"
										ref="txtPlaceOfIN"
										tabindex="9"
										name="PlaceOfIN"
										type="text"
										v-model="employee.placeOfIN"
									/>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="m-row m-flex">
					<div class="m-col el-left  m-flex-2">
						<div class="m-row mg-top-0 m-flex">
							<div class=" m-flex-1">
								<div class="m-flex">
									<button
										@click="changAciveTabDailogTrue"
										class="tabTitle"
										:class="{
											active: tabDetail,
										}"
									>
										Liên hệ
									</button>
									<button
										@click="changAciveTabDailogFalse"
										class="tabTitle"
										:class="{
											active: !tabDetail,
										}"
									>
										Tài khoản ngân hàng
									</button>
								</div>

								<div class="tabView">
									<div v-show="tabDetail === true">
										<div class="m-row m-flex">
											<div
												class="m-col el-left  m-flex-2"
											>
												<div
													class="m-row mg-top-0 m-flex mg-left-10px mg-right-10px"
												>
													<div class=" m-flex-1">
														<div class="m-label">
															Địa chỉ
														</div>
														<div>
															<input
																@keyup.shift.enter.prevent="
																	focusPlaceOfIN
																"
																ref="txtAddress"
																@keyup.enter.exact="
																	focusPhoneNumber
																"
																tabindex="10"
																name="PlaceOfIN"
																type="text"
																v-model="
																	employee.address
																"
															/>
														</div>
													</div>
												</div>
												<div
													class="m-row m-flex mg-left-10px mg-right-10px"
												>
													<div class=" m-flex-1">
														<div class="m-label">
															ĐT di động
														</div>
														<div>
															<input
																@keyup.enter.exact="
																	focusPhoneStatic
																"
																@keyup.shift.enter.prevent="
																	focusAdress
																"
																ref="txtPhoneNumber"
																tabindex="11"
																name="PlaceOfIN"
																type="text"
																v-model="
																	employee.phoneNumber
																"
															/>
														</div>
													</div>
													<div
														class=" m-flex-1 mg-left-5px"
													>
														<div class="m-label">
															ĐT cố định
														</div>
														<div>
															<input
																@keyup.enter.exact="
																	focusEmail
																"
																@keyup.shift.enter.prevent="
																	focusPhoneNumber
																"
																ref="txtPhoneStatic"
																tabindex="12"
																name="PlaceOfIN"
																type="text"
																v-model="
																	employee.phoneStatic
																"
															/>
														</div>
													</div>
													<div
														class=" m-flex-1 mg-left-5px"
													>
														<div class="m-label">
															Email
														</div>
														<div>
															<input
																@keyup.enter.shift.prevent="
																	focusPhoneStatic
																"
																ref="email"
																tabindex="13"
																name="PlaceOfIN"
																type="text"
																v-model="
																	employee.email
																"
															/>
														</div>
													</div>
													<div
														class=" m-flex-1"
													></div>
												</div>
											</div>
										</div>
									</div>
									<div v-show="tabDetail == false">
										<div class="m-row m-flex">
											<div
												class="m-col el-left  m-flex-2"
											>
												<div
													class="m-row mg-top-0 m-flex"
												>
													<div
														class=" m-flex-1 mg-left-10px mg-right-10px"
													>
														<div
															class="tableEmployeeBanks"
														>
															<table
																id="employeeBanks"
															>
																<tr>
																	<th
																		width="20%"
																	>
																		SỐ TÀI
																		KHOẢN
																	</th>
																	<th
																		width="25%"
																	>
																		TÊN NGÂN
																		HÀNG
																	</th>
																	<th
																		width="20%"
																	>
																		CHI
																		NHÁNH
																	</th>
																	<th
																		width="31%"
																	>
																		TỈNH/TP
																		CỦA NGÂN
																		HÀNG
																	</th>
																	<th
																		width="4%"
																	></th>
																</tr>
																<tr
																	v-for="item in employee.employeeBanks"
																	:key="
																		item.index
																	"
																>
																	<td>
																		<input
																			tabindex="14"
																			type="text"
																			v-model="
																				item.bankNumber
																			"
																		/>
																	</td>
																	<td>
																		<input
																			tabindex="15"
																			type="text"
																			v-model="
																				item.bankName
																			"
																		/>
																	</td>
																	<td>
																		<input
																			tabindex="16"
																			type="text"
																			v-model="
																				item.branch
																			"
																		/>
																	</td>
																	<td>
																		<input
																			tabindex="17"
																			type="text"
																			v-model="
																				item.bankCity
																			"
																		/>
																	</td>
																	<td>
																		<div
																			@click="
																				btnDeleteOneOnClick(
																					employee,
																					[
																						{
																							employeeBankId:
																								item.employeeBankId,
																						},
																					]
																				)
																			"
																			id="btnDeleteEmployeeBank"
																		></div>
																	</td>
																</tr>
															</table>
														</div>

														<div
															class="footerEmployeeBanks m-flex"
														>
															<button
																@click="
																	addLineEmployeeBanks(
																		employee.employeeId
																	)
																"
																id="addLineEmployeeBanks"
															>
																Thêm dòng
															</button>
															<button
																@click="
																	btnDeleteOneOnClick(
																		employee,
																		employee.employeeBanks
																	)
																"
																id="deleteLineEmployeeBanks"
															>
																Xóa hết dòng
															</button>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="dialog-footer">
				<button
					v-on:click="btnCancelOnClick"
					id="btnCancel"
					class="m-btn m-second-button m-btn-cancel"
				>
					Hủy
				</button>
				<button
					@click="btnAddOnClick(employee)"
					id="btnSave"
					class="m-btn m-second-button"
					title="Cất (Ctrl + S)"
				>
					Cất
				</button>
				<button
					@click="btnAddAndSaveOnClick(employee)"
					id="btnSaveAndAdd"
					class="m-btn m-btn-default"
					title="Cất và thêm (Ctrl + Shift + S)"
				>
					Cất và Thêm
				</button>
			</div>
		</div>
	</div>
</template>

<script>
import { Notyf } from "notyf";
import "notyf/notyf.min.css"; // for React, Vue and Svelte

// Create an instance of Notyf
const notyf = new Notyf({
	position: {
		x: "center",
		y: "top",
	},
});
import * as axios from "axios";
import Department from "../../../components/common/Department.vue";
import BaseCombobox from "../../../components/base/BaseCombobox";
import BaseRadio from "../../../components/base/BaseRadio.vue";
export default {
	created() {
		document.onkeydown = function(e) {
			e = e || window.event; //Get event
			if (e.ctrlKey) {
				var c = e.which || e.keyCode; //Get key code
				switch (c) {
					case 83: //Block Ctrl+S
						e.preventDefault();
						e.stopPropagation();
						break;
					case 40: //Block Ctrl+S
						e.preventDefault();
						e.stopPropagation();
						break;
				}
			}
			if (e.altKey) {
				e.preventDefault();
				e.stopPropagation();
			}
		};

		window.addEventListener("keyup", this.changeActiveTabDailog);
	},
	props: {
		isHide: Boolean,
		employee: Object,
		mode: String,
	},

	data() {
		return {
			// Thay đổi liên hệ hoặc thông tin ngân hàng
			tabDetail: true,

			// * tọa độ của dialog
			position: {
				pos1: 0,
				pos2: 0,
				pos3: 0,
				pos4: 0,
			},

			filter: {
				keyword: "",
				departmentId: "",
			},

			gender: {
				header: "Giới tính",
				genders: [
					{ genderId: 0, genderName: "Nam", value: 0 },
					{ genderId: 1, genderName: "Nữ", value: 1 },
					{ genderId: 2, genderName: "Khác", value: 2 },
				],
				category: "gender",
			},

			dialog: false,
		};
	},
	computed: {},

	components: {
		Department,
		BaseCombobox,
		BaseRadio,
	},
	methods: {
		//#region Các hàm xử lý sự kiện
		// Hàm xóa ngân hàng của nhân viên
		async btnDeleteOneOnClick(employee, employeeBankId) {
			let employeeBankIds = [];
			employeeBankId.forEach(function(item) {
				employeeBankIds.push(item.employeeBankId);
			});

			let self = this;
			let res = await axios.delete(
				"https://localhost:44349/api/EmployeeBanks",
				{
					data: employeeBankIds,
				}
			);
			self.$emit("deleteEmployeeBanks");
			self.getEmployeeBanks(employee);
			self.tabDetail = true;
			self.tabDetail = false;
		},

		// Xử lý sự kiện nút cất và thêm
		async btnAddAndSaveOnClick(employee) {
			await this.checkValidate(employee);
			await this.putEmployee(employee, employee.employeeBanks);
			this.$emit("closePopup", false);
		},

		// xử lý sự kiện click button thêm dòng
		addLineEmployeeBanks(employeeId) {
			this.$emit("addEmployeeBank", employeeId);
		},

		// * Hàm xử lý sự kiện khi nhấn nút click
		async btnAddOnClick(employee) {
			this.checkValidate(employee);
			this.putEmployee(employee, employee.employeeBanks);
		},

		// * Hàm xử lý sự kiện khi bấm nút hủy
		btnCancelOnClick() {
			this.$emit("closePopup2");
		},
		//#endregion
		//#region  Các hàm focus khi dùng bàn phím
		focusPlaceOfIN() {
			this.$refs.txtPlaceOfIN.focus();
		},
		focusAdress() {
			this.$refs.txtAddress.focus();
		},
		focusPhoneStatic() {
			this.$refs.txtPhoneStatic.focus();
		},
		focusEmail() {
			this.$refs.email.focus();
		},
		focusPhoneNumber() {
			this.$refs.txtPhoneNumber.focus();
		},
		setItemSelected2() {
			this.$refs.txtIdentityNumber.focus();
		},
		focusGender() {
			this.$emit("focusGender");
			document.getElementById("txtDateOfBirth").blur();
		},
		setItemSelected3() {
			this.$refs.txtPosition.focus();
		},
		setItemSelected4() {
			this.$refs.txtFullName.focus();
		},
		focusCombobox() {
			if (
				document
					.getElementsByClassName("m-pop-up")[0]
					.classList.contains("isHide")
			) {
				this.$emit("showCombobox");
				document.getElementById("txtFullName").blur();
				document.getElementById("txtPosition").blur();
			}
		},
		focusInput() {
			this.$refs.txtEmployeeCode.focus();
		},
		//#endregion

		//#region Các hàm check validate
		// Hàm bỏ check validate
		noCheckValidate(prop) {
			document
				.getElementById("txt" + prop)
				.classList.remove("required-error");
		},
		// Hàm checkvalidate của mã
		checkValidateEmployeeCode(employee) {
			if (!employee.employeeCode) {
				document
					.getElementById("txtEmployeeCode")
					.classList.add("required-error");
			}
		},
		// Hàm checkvalidate của tên
		checkValidateFullName(employee) {
			if (!employee.fullName) {
				document
					.getElementById("txtFullName")
					.classList.add("required-error");
			}
		},
		// Hàm check validate khi cất
		checkValidate(employee) {
			if (!employee.employeeCode) {
				document
					.getElementById("txtEmployeeCode")
					.classList.add("required-error");
			}
			if (!employee.departmentId) {
				document
					.getElementById("txtDepartmentId")
					.classList.add("required-error");
			} else
				document
					.getElementById("txtDepartmentId")
					.classList.remove("required-error");
			if (!employee.fullName) {
				document
					.getElementById("txtFullName")
					.classList.add("required-error");
			}
		},
		//#endregion

		//#region
		// Hàm cập nhật lại dữ liệu ngân hàng khi dữ liệU bị thay đổi
		getEmployeeBanks() {
			return this.getEmployeeBank;
		},

		// Hàm thay đổi tab View liên hệ hay là ngân hàng
		changAciveTabDailogTrue() {
			this.tabDetail = true;
		},
		changAciveTabDailogFalse() {
			this.tabDetail = false;
		},

		// Hàm xử lý sự kiện nhập bàn phím
		changeActiveTabDailog(event) {
			if (event.which === 18) {
				this.tabDetail = !this.tabDetail;
			} else if (event.which === 83 && event.ctrlKey === true) {
				this.btnAddOnClick(this.employee);
				event.preventDefault();
			} else if (
				event.which === 83 &&
				event.ctrlKey === true &&
				event.shiftKey === true
			) {
				this.btnAddAndSaveOnClick(this.employee);
				event.preventDefault();
			} else if (
				event.which == 27 &&
				document
					.getElementsByClassName("m-pop-up")[0]
					.classList.contains("isHide")
			) {
				this.btnCancelOnClick();
			}
			//
		},

		// * truyền departmentId từ component combobox
		setDepartmentId(data) {
			this.employee.departmentId = data.id.toString();
		},

		// * Hàm để lấy số nhân viên/1 trang từ component combobox
		setItemSelected(data) {
			this.employee.gender = data.id;
		},

		//Hàm put dữ liệu lên server
		async putEmployee(employee, employeeBanks) {
			var temp = employee;
			var str = "";
			let self = this;
			if (this.mode === "add" || this.mode === "clone") {
				if (temp.departmentId === "") {
					temp.departmentId = "00000000-0000-0000-0000-000000000000";
				}
				let res = await axios
					.post("https://localhost:44349/api/Employees/", temp)
					.catch(async function(error) {
						if (error.response) {
							error.response.data.userMsg.forEach(function(item) {
								str += item + ", ";
							});
							str += "vui lòng kiểm tra lại!";
							self.$emit("notifyBoard", {
								content: str,
							});
						}
					});
				if (
					temp.departmentId === "00000000-0000-0000-0000-000000000000"
				) {
					temp.departmentId = "";
				}
				if (res !== undefined) {
					let res2 = await axios.get(
						"https://localhost:44349/api/Employees?employeeCode=" +
							temp.employeeCode
					);
					employeeBanks.forEach(async function(employeeBank) {
						employeeBank.employeeId = res2.data[0].employeeId;
						let res3 = await axios.post(
							"https://localhost:44349/api/EmployeeBanks/",
							employeeBank
						);
					});
					this.$emit("closePopup", true);
					notyf.success("Thêm thành công!");
				}
			} else {
				if (temp.departmentId === "") {
					temp.departmentId = "00000000-0000-0000-0000-000000000000";
				}
				let res1 = await axios
					.put("https://localhost:44349/api/Employees/", temp)
					.catch(async function(error) {
						if (error.response) {
							var str = "";
							error.response.data.userMsg.forEach(function(item) {
								str += item + ", ";
							});
							str += "vui lòng kiểm tra lại!";
							self.$emit("notifyBoard", {
								content: str,
							});
						}
					});

				if (
					temp.departmentId === "00000000-0000-0000-0000-000000000000"
				) {
					temp.departmentId = "";
				}
				if (res1 !== undefined) {
					employeeBanks.forEach(async function(employeeBank) {
						if (!employeeBank.employeeBankId) {
							let res3 = await axios.post(
								"https://localhost:44349/api/EmployeeBanks/",
								employeeBank
							);
						} else {
							let res3 = await axios.put(
								"https://localhost:44349/api/EmployeeBanks/",
								employeeBank
							);
						}
					});
					this.$emit("closePopup", true);
					notyf.success("Sửa thành công!");
				}
			}
		},

		/// Các hàm xử lý sự kiện di chuyển dialog
		// * Hàm nhấn di chuyển
		dragElement() {
			const elmnt = document.getElementsByClassName("dialog-header");
			if (elmnt[0]) {
				elmnt[0].onmousedown = this.dragMouseDown;
			} else {
				elmnt[0].onmousedown = this.dragMouseDown;
			}
		},

		// * Hàm nhấn chuột
		dragMouseDown(e) {
			e = e || window.event;
			// get the mouse cursor position at startup:
			this.position.pos3 = e.clientX;
			this.position.pos4 = e.clientY;
			document.onmouseup = this.closeDragElement;
			// call a function whenever the cursor moves:
			document.onmousemove = this.elementDrag;
		},

		// * Hàm thay đổi tọa độ của dialog
		elementDrag(e) {
			var elmnt = document.getElementsByClassName("m-dialog");
			e = e || window.event;
			// calculate the new cursor position:

			this.position.pos1 = this.position.pos3 - e.clientX;
			this.position.pos2 = this.position.pos4 - e.clientY;
			this.position.pos3 = e.clientX;
			this.position.pos4 = e.clientY;
			if (
				elmnt[0].offsetTop - this.position.pos2 >
				window.screen.availHeight - 794
			)
				elmnt[0].style.top = window.screen.availHeight - 794 + "px";
			else if (elmnt[0].offsetTop - this.position.pos2 < -80)
				elmnt[0].style.top = -80 + "px";
			else
				elmnt[0].style.top =
					elmnt[0].offsetTop - this.position.pos2 + "px";
			if (
				elmnt[0].offsetLeft - this.position.pos1 <
				-window.screen.availWidth + 180
			) {
				elmnt[0].style.left = -window.screen.availWidth + "px" + 180;
			} else if (elmnt[0].offsetLeft - this.position.pos1 > -520) {
				elmnt[0].style.left = -520 + "px";
			} else
				elmnt[0].style.left =
					elmnt[0].offsetLeft - this.position.pos1 + "px";
		},

		// * Hàm dừng di chuyển dialog
		closeDragElement() {
			/* stop moving when mouse button is released:*/
			document.onmouseup = null;
			document.onmousemove = null;
		},
	},

	// Hàm focus vào mã khi mở form
	mounted() {
		this.$watch(
			"isHide",
			function() {
				this.noCheckValidate("EmployeeCode");
				this.noCheckValidate("FullName");
				this.noCheckValidate("DepartmentId");
				this.focusInput();
			},
			{ immediate: true }
		);
	},
};
</script>

<style scope>
#addLineEmployeeBanks {
	margin-right: 10px;
}

.footerEmployeeBanks {
	width: 100%;
	height: 34px;
}

.footerEmployeeBanks button {
	min-width: 5px;
	margin-top: auto;
	border: none;
	outline: none;
	border: 1px solid #8d9096;
	border-radius: 4px;
	font-weight: bold;
	color: rgb(17, 17, 17);
	height: 24px;
	background-color: #fff;
	padding: 2px 20px;
	cursor: pointer;
}

#employeeBanks {
	border-collapse: collapse;
	width: 100%;
	background-color: #f8f8f8;
}
.tableEmployeeBanks {
	width: 100%;
	max-height: 135px;
	overflow: auto;
}

#employeeBanks td,
#employeeBanks th {
	border: 1px solid #ddd;
	padding: 8px;
}

#employeeBanks th {
	text-align: left;
}
.isHide {
	display: none;
}
.m-dialog {
	z-index: 999;
	position: absolute;
	top: 0;
	right: 50%;
	width: 900px;
	height: 625px;
	left: -999px;
	top: 50px;
	color: rgb(17, 17, 17);
}

.dialog-modal {
	position: fixed;
	top: 0;
	bottom: 0;
	left: 0;
	right: 0;
	background-color: black;
	opacity: 0.4;
	z-index: -1;
}

.m-dialog .dialog-content {
	background-color: #ffffff;
	z-index: 1000;
	border-radius: 5px 5px 0 0px;

	width: 100%;
	height: 100%;
}

.m-dialog .dialog-content .dialog-body {
	overflow: auto;
	width: calc(100% - 50px);
	height: calc(100% - 135px);
}

.m-dialog .dialog-header {
	display: flex;
	padding: 24px;
	cursor: move;
}

.m-dialog .dialog-header .dialog-header-close {
	position: absolute;
	right: 0;
	top: 0;
}

.m-dialog .dialog-header .dialog-header-close:hover {
	border-radius: 5px;
}

.m-dialog .dialog-header .dialog-header-close button {
	width: 40px;
	height: 40px;
	border-radius: 0 5px 0 0;
	border: none;
	outline: none;
	cursor: pointer;
	background-color: #ffffff;
	background: url("../../../assets/content/img/Sprites.64af8f61.svg")
		no-repeat;
}

.help-btn {
	background-position: -82px -135px !important;
}
.close-btn {
	background-position: -138px -135px !important;
}

/*Tiêu đề của dialog*/

.m-dialog .dialog-header .dialog-header-title {
	font-size: 20px;
	font-weight: bold;
	-moz-user-select: none; /* Firefox */
	-ms-user-select: none; /* Internet Explorer */
	-khtml-user-select: none; /* KHTML browsers (e.g. Konqueror) */
	-webkit-user-select: none; /* Chrome, Safari, and Opera */
	-webkit-touch-callout: none; /* Disable Android and iOS callouts*/
}

.dialog-content .dialog-body {
	padding: 0px 24px;
}

.tabView {
	width: 100%;
	height: 194px;
	border: 1px solid #c9ccd2;
	border-radius: 0 4px 4px 4px;
}
.tabTitle.active {
	background-color: #cce4f9;
	height: 32px;
}

.tabTitle {
	padding: 8px;
	outline: none;
	height: 25px;
	border: none;
	border: 1px solid #c9ccd2;
	border-radius: 4px 4px 0 0;
	cursor: pointer;
	background-color: #fff;
	margin-top: auto;
	border-bottom: none;
}

#btnDeleteEmployeeBank {
	background: url("../../../assets/content/icon/Sprites.64af8f61.svg")
		no-repeat -464px -313px;
	width: 15px;
	height: 15px;
	cursor: pointer;
}

.tabTitle:hover {
	color: #2ca01c;
}

.dialog-footer {
	display: flex;
	width: 100%;
	height: 88px;
	background-color: #fff;
	border-top: 1px solid #c9ccd2;
	border-radius: 0 0 5px 5px;
	align-items: center;
	justify-content: flex-end;
	padding: 24px;
	box-sizing: border-box;
}

.dialog-footer button {
	height: 36px;
	font-weight: bold;
}
#btnSave {
	margin-right: 16px;
}

#btnCancel {
	margin-right: auto;
}
.required-error {
	border: 1px solid #ff0000 !important;
}

.el-left {
	width: calc(100% - 180px);
}

.filter-left {
	display: flex;
}
.filter-left .m-combobox {
	margin-left: 10px;
	margin-right: 10px;
}

#txtSearchEmployee {
	min-width: 230px;
}

.type-customer {
	display: flex;
	align-items: center;
	margin: auto 20px;
}

.type-customer input {
	margin: auto 10px;
}
</style>
