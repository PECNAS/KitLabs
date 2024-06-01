class Matrix2x2 {
	constructor(n) {
		this.matrix = [[], []];

		if (typeof(n) == "number") {
			for (var i = 0; i < 2; i++) {
				for (var j = 0; j < 2; j++) {
					this.matrix[i][j] = n;
				}
			}
		} else if (typeof(n) == "object") {
			for (var i = 0; i < 2; i++) {
				for (var j = 0; j < 2; j++) {
					this.matrix[i][j] = n[i][j];
				}
			}
		}
	}

	add(mat) {
		var temp = [[], []]
		for (var i = 0; i < 2; i++) {
			for (var j = 0; j < 2; j++) {
				temp[i][j] = this.matrix[i][j] + mat.matrix[i][j];
			}
		}

		return temp;
	}

	sub(mat) {
		var temp = [[], []]
		for (var i = 0; i < 2; i++) {
			for (var j = 0; j < 2; j++) {
				temp[i][j] = this.matrix[i][j] - mat.matrix[i][j];
			}
		}

		return temp;
	}

	multiNumber(n) {
		var temp = [[], []]
		for (var i = 0; i < 2; i++) {
			for (var j = 0; j < 2; j++) {
				temp[i][j] = n * this.matrix[i][j];
			}
		}

		return temp;
	}

	multi(mat, a, b) {
		if (mat) var matrix = mat.matrix;
		else var matrix = [[a], [b]]
		var result = [[], []];

		for (var i = 0; i < 2; i++) {
			for (var j = 0; j < matrix[0].length; j++) {
				var sum = 0;

				for (var k = 0; k < 2; k++) {
					sum += this.matrix[i][k] * matrix[k][j];
				}

				result[i][j] = sum;
			}
		}
		return result;
	}

	det() {
		var det = this.matrix[0][0] * this.matrix[1][1] - this.matrix[1][0] * this.matrix[0][1];

		return det;
	}

	transpon() {
		var temp = [[], []];

		for (var i = 0; i < 2; i++) {
			for (var j = 0; j < 2; j++) {
				temp[j][Math.abs(1 - i)] = this.matrix[i][j];
			}
		}

		return temp;
	}

	inverseMatrix() {
		var determinant = this.det();
		if (determinant == 0) {
			// обратной матрицы не существует
		}

		var inverseMatrix = [
		[this.matrix[1][1] / determinant, -this.matrix[0][1] / determinant],
		[-this.matrix[1][0] / determinant, this.matrix[0][0] / determinant]];

		return inverseMatrix;
	}

	multiVector(a, b) {
		return this.multi(null, a, b)
	}
}

function create_matrix(btn) {
	if (btn.id == "create-matrix") {
		var inputs = document.querySelector(".create-first-matrix").querySelectorAll(".el-input");
	} else {
		var inputs = document.querySelectorAll(".second-el-input");
	}
	var correct = true;

	inputs.forEach((e) => {
		if (e.value == "") {
			if (correct == true) {
				alert("Необходимо заполнить все столбцы");
				correct = false;
			}
		}
	});

	if (correct) {
		var matrix = [
				[Number(inputs[0].value), Number(inputs[1].value)],
				[Number(inputs[2].value), Number(inputs[3].value)]
			];

		if (btn.id == "create-matrix") {
			var user_matrix_elements = document.querySelectorAll(".user-first-matrix-el");
		} else {
			var user_matrix_elements = document.querySelectorAll(".user-second-matrix-el");
		}

		for (var i = 0; i < 4; i++) {
			user_matrix_elements[i].innerHTML = inputs[i].value;
			inputs[i].value = "";
		}

		if (btn.id == "create-matrix") {
			m1 = new Matrix2x2(matrix);
			alert("Матрица успешно создана!");
			console.log(m1.matrix);
		} else {
			m2 = new Matrix2x2(matrix);
			alert("Дополнительная матрица успешно создана!");
			console.log(m2.matrix);
		}
	}
}

window.onload = (event) => {
	var m1 = null;
	var m2 = null;
}

function print_matrix(matrix) {
	alert(matrix[0][0] + " " + matrix[0][1] + "\n" + matrix[1][0] + " " + matrix[1][1])
}

function add_matrix() {
	print_matrix(m1.add(m2));
	console.log(m1.add(m2));
}

function multiNumber_matrix() {
	print_matrix(m1.multiNumber(
		document.querySelector(
			"#multiNumber"
			).value
		));
}

function sub_matrix() {
	print_matrix(m1.sub(m2));
}

function multi_matrix() {
	print_matrix(m1.multi(m2));
}

function det_matrix() {
	alert(m1.det());
}

function transpon_matrix() {
	print_matrix(m1.transpon());
}

function inverse_matrix() {
	print_matrix(m1.inverseMatrix());
}
// var m1 = new Matrix2x2([[1, 2], [3, 4]]);
// var m2 = new Matrix2x2([[8, 2], [1, 4]]);

// var m = m1.add(m2);
// print_matrix(m);
// var m = m1.sub(m2);
// console.log(m);
// var m = m1.multiNumber(10);
// console.log(m);
// var m = m1.multi(m2);
// console.log(m);
// var det = m1.det();
// console.log(det);
// var m = m1.inverseMatrix();
// console.log(m);
// var tm = m1.multiVector(2, 2);
// console.log(tm);