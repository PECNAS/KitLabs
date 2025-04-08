window.addEventListener("load", function(e) {
	var buttons = document.querySelectorAll(".btn");
	buttons.forEach((btn) => {
		btn.addEventListener("click", OnBtnTap);
	});
});

function OnBtnTap() {
	var res_input = document.querySelector("#res-input");
	res_input.value += this.innerHTML;
}

function RemoveSign() {
	var res_input = document.querySelector("#res-input");
	console.log(res_input);
	res_input.value = "";
}

function Calculate() {
	var res_input = document.querySelector("#res-input");
	res_input.value = eval(res_input.value);
}