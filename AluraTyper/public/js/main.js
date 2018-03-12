let campo = $(".campo-digitacao");
let tempoInicial = $('#tempo-digitacao').text();


$(function () {
    atualizaTamanhoFrase();
    inicializaContadores();
    inicializaCronometro();
    inicializaMarcadores();
    $('#botao-reiniciar').click(reiniciaJogo);
});

function atualizaTamanhoFrase() {
    let frase = $('.frase').text();
    let numPalavras = frase.split(' ').length;
    let tamanhoFrase = $('#tamanhoFrase');
    tamanhoFrase.text(numPalavras);
}

function inicializaContadores() {
    campo.on("input", function () {
        let conteudo = campo.val();
        let qtdPalavras = conteudo.split(/\S+/).length - 1;
        $('#contador-palavras').text(qtdPalavras);
        $('#contador-caracteres').text(conteudo.length);
    });
};

function inicializaCronometro() {
    let tempoRestante = tempoInicial;
    campo.one("focus", function () {
        let cronometroId = setInterval(function () {
            tempoRestante--;
            $('#tempo-digitacao').text(tempoRestante);
            if (tempoRestante < 1) {
                clearInterval(cronometroId);
                finalizaJogo();
            }
        }, 1000);
    });
}

function finalizaJogo() {
    campo.toggleClass("campo-desativado");
    campo.attr("disabled", true);
    inserePlacar();
}

function reiniciaJogo() {
    campo.attr("disabled", false);
    campo.val('');
    $('#contador-palavras').text(0);
    $('#contador-caracteres').text(0);
    $('#tempo-digitacao').text(tempoInicial);
    campo.removeClass("campo-desativado");
    campo.removeClass("borda-vermelha");
    campo.removeClass("borda-verde");
    inicializaCronometro();
}

function inicializaMarcadores() {
    let frase = $(".frase").text();
    campo.on("input", function () {
        let digitado = campo.val();
        let comparavel = frase.substr(0, digitado.length);
        if (digitado == comparavel) {
            campo.addClass("borda-verde");
            campo.removeClass("borda-vermelha");
        } else {
            campo.addClass("borda-vermelha");
            campo.removeClass("borda-verde");
        }

    });
}
