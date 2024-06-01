function sqrt() {
	var n = parseFloat(document.querySelector("#request-input").value);
	if (n >= 0) {
	    var x = n;
	    var y = (x + 1) / 2;
	    console.log(x, y);
	    while (y < x) {
	        x = y;
	        y = (x + n / x) / 2;
	    }

		document.querySelector("#result").innerHTML = x;

	} else if (n < 0) {
		alert("Число не может быть отрицательным!");
	}
}
