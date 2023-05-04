// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getImage(url, id) {
	const xhr = new XMLHttpRequest();
	xhr.responseType = 'blob';
	xhr.onreadystatechange = function () {
		if (this.status === 200) {
			const parent = document.getElementById(id)
			const blob = this.response;
			const img = document.createElement('img');
			img.src = URL.createObjectURL(blob);
			parent.appendChild(img);
		} 	
	};
	xhr.open('GET', url);
	xhr.send();
}

