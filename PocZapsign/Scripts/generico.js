function showLoader() {
    document.getElementById('divLoadingFitBank').style.display = 'block';
    return false;
}

function hideLoader() {
    document.getElementById('divLoadingFitBank').style.display = 'none';
}

function mascara(o, f) {
    v_obj = o
    v_fun = f
    setTimeout(execmascara, 1)
}

function execmascara() {
    v_obj.value = v_fun(v_obj.value)
}

function mtel(v) {
    v = v.replace(/\D/g, "").substr(0, 11);    //Remove tudo o que não é dígito
    v = v.replace(/^(\d{2})(\d)/g, "($1) $2"); //Coloca parênteses em volta dos dois primeiros dígitos
    v = v.replace(/(\d)(\d{4})$/, "$1-$2");    //Coloca hífen entre o quarto e o quinto dígitos
    return v;
}

function mCPF(cpf) {

    var num = cpf.replace(/[^\d]/g, ''); //remove todos os caracteres não numéricos
    var len = num.length; //guarda o número de digitos até o momento

    if (len <= 6) {
        cpf = num.replace(/(\d{3})(\d{1,3})/g, '$1.$2');
    } else if (len <= 9) {
        cpf = num.replace(/(\d{3})(\d{3})(\d{1,3})/g, '$1.$2.$3');
    } else {
        cpf = num.replace(/(\d{3})(\d{3})(\d{3})(\d{1,2})/g, "$1.$2.$3-$4");
    }
    return cpf.substr(0, 14);
}

function mRG(rg) {
    var num = rg.replace(/[^\d]/g, ''); //remove todos os caracteres não numéricos
    var len = num.length; //guarda o número de digitos até o momento

    if (len <= 5) {
        rg = num.replace(/(\d{2})(\d{1,3})/g, '$1.$2');
    } else if (len <= 8) {
        rg = num.replace(/(\d{2})(\d{3})(\d{1,3})/g, '$1.$2.$3');
    } else {
        rg = num.replace(/(\d{2})(\d{3})(\d{3})(\d{1})/g, "$1.$2.$3-$4");
    }
    return rg.substr(0, 12);
}


function validarEmail(email) {
    var re = /\S+@\S+\.\S+/;
    return re.test(email);
}
