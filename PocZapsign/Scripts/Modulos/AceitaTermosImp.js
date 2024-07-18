function openBase64Pdf(base64String) {
	var pdfData = 'data:application/pdf;base64,' + base64String;
	var pdfWindow = window.open("");
	pdfWindow.document.write("<iframe width='100%' height='100%' src='" + pdfData + "'></iframe>");
}

function EnviarAssinaturaDigital() {

	const queryString = window.location.search;
	const urlParams = new URLSearchParams(queryString);
	const pessoaId = urlParams.get('id');

	CriarPDFBase64().then(base64data => {
		AceitaTermosImp.EnviarAssinatura(pessoaId, base64data, EnviarAssinaturaDigital_Callback);
	}).catch(error => {
		console.error("Houve um erro ao criar o PDF!", error);
	});

}

function EnviarAssinaturaDigital_Callback(response) {
	var dadosJson = JSON.parse(response.value);
	alert(dadosJson.mensagem);
	if (dadosJson.success == "True") {
		window.location.assign("CriarAssinatura.aspx");
	}
}

function CriarPDFBase64() {
	
	return new Promise((resolve, reject) => {
		// Criar uma nova tabela		
		var tabelaTemp = document.getElementById('Panel1');

		// Configurações para html2canvas e jsPDF
		html2canvas(tabelaTemp, { scale: 1 }).then(canvas => {
			var imgData = canvas.toDataURL('image/jpeg');
			var pdf = new jspdf.jsPDF('p', 'mm', 'a4'); // Orientação retrato e tamanho A4
			var pageWidth = pdf.internal.pageSize.getWidth();
			var imgWidth = canvas.width;
			var imgHeight = canvas.height;
			var ratio = pageWidth / imgWidth;
			var newWidth = imgWidth * ratio;
			var newHeight = imgHeight * ratio;

			// Verifica se a altura da imagem excede a altura da página
			if (newHeight > pdf.internal.pageSize.getHeight()) {
				// Redimensiona a imagem para caber na página
				newHeight = pdf.internal.pageSize.getHeight();
				newWidth = imgWidth * (newHeight / imgHeight);
			}

			pdf.addImage(imgData, 'PNG', 0, 10, newWidth, newHeight);

			var blob = pdf.output('blob');

			var reader = new FileReader();
			reader.readAsDataURL(blob);
			reader.onloadend = function () {
				var base64data = reader.result;
				base64data = base64data.replace('data:application/pdf;base64,', '');
				resolve(base64data);
			}

		}).catch(error => {
			reject(error);
		}).finally(() => {
		});
	});
}
