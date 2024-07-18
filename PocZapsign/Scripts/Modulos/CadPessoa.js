document.addEventListener("DOMContentLoaded", function () {
    // Máscaras para os campos
    maskCPF(document.getElementById('txtCPF'));
    maskCEP(document.getElementById('txtCEP'));
    maskTelCel(document.getElementById('txtTelCel'));

    // Validação dos campos
    document.getElementById("form1").addEventListener("submit", function (event) {
        var isValid = true;

        var cpfInput = document.getElementById('txtCPF');
        var emailInput = document.getElementById('txtEmail');
        var nomeInput = document.getElementById('txtNome');

        if (!validateCPF(cpfInput.value)) {
            isValid = false;
            cpfInput.classList.add("is-invalid");
        } else {
            cpfInput.classList.remove("is-invalid");
        }

        if (!validateEmail(emailInput.value)) {
            isValid = false;
            emailInput.classList.add("is-invalid");
        } else {
            emailInput.classList.remove("is-invalid");
        }

        if (nomeInput.value.length < 3) {
            isValid = false;
            nomeInput.classList.add("is-invalid");
        } else {
            nomeInput.classList.remove("is-invalid");
        }

        if (!isValid) {
            event.preventDefault();
        }
    });
});

function maskCPF(input) {
    input.addEventListener("input", function () {
        input.value = input.value
            .replace(/\D/g, "")
            .replace(/(\d{3})(\d)/, "$1.$2")
            .replace(/(\d{3})(\d)/, "$1.$2")
            .replace(/(\d{3})(\d{1,2})$/, "$1-$2");
    });
}

function maskCEP(input) {
    input.addEventListener("input", function () {
        input.value = input.value
            .replace(/\D/g, "")
            .replace(/(\d{5})(\d)/, "$1-$2");
    });
}

function maskTelCel(input) {
    input.addEventListener("input", function () {
        input.value = input.value
            .replace(/\D/g, "")
            .replace(/(\d{2})(\d)/, "($1) $2")
            .replace(/(\d{5})(\d{1,4})$/, "$1-$2");
    });
}

function validateCPF(cpf) {
    cpf = cpf.replace(/[^\d]+/g, '');

    if (cpf.length !== 11 || /^(\d)\1{10}$/.test(cpf)) {
        return false;
    }

    let sum = 0;
    let remainder;

    for (let i = 1; i <= 9; i++) {
        sum += parseInt(cpf.substring(i - 1, i)) * (11 - i);
    }

    remainder = (sum * 10) % 11;

    if ((remainder == 10) || (remainder == 11)) {
        remainder = 0;
    }

    if (remainder != parseInt(cpf.substring(9, 10))) {
        return false;
    }

    sum = 0;

    for (let i = 1; i <= 10; i++) {
        sum += parseInt(cpf.substring(i - 1, i)) * (12 - i);
    }

    remainder = (sum * 10) % 11;

    if ((remainder == 10) || (remainder == 11)) {
        remainder = 0;
    }

    if (remainder != parseInt(cpf.substring(10, 11))) {
        return false;
    }

    return true;
}

function validateEmail(email) {
    var re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(email);
}
