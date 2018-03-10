angular.module('alurapic').controller('FotosController', function ($scope, recursoFoto) {
    $scope.fotos = [];
    $scope.filtro;
    $scope.mensagem = '';

    recursoFoto.query(function (fotos) {
        $scope.fotos = fotos;
    }, function (erro) {
        console.log(erro);
    });

    // $http.get('v1/fotos')
    //         .success(function (fotos) {
    //             $scope.fotos = fotos;
    //         })
    //     .error(function (erro) {
    //         console.log(erro);
    //     });
    // $http.get('v1/fotos')
    //     .then(function (retorno) {
    //         $scope.fotos = retorno.data;
    //     }).catch(function (erro) {
    //         console.log(erro);
    //     });
    $scope.remover = function (foto) {
        recursoFoto.delete({
            fotoId: foto._id
        }, function () {
            let indiceFotos = $scope.fotos.indexOf(foto);
            $scope.fotos.splice(indiceFotos, 1);
            console.log('Foto ' + foto.titulo + ' apagada com sucesso');
            $scope.mensagem = 'Foto ' + foto.titulo + ' apagada com sucesso';
        }, function (erro) {
            console.log(erro);
            console.log('Não foi possível remover a foto ' + foto.titulo);
            $scope.mensagem = 'Não foi possível remover a foto ' + foto.titulo;
        });
    };
    // $scope.remover = function (foto) {
    //     $http.delete('v1/fotos/' + foto._id)
    //         .success(function (dados) {
    //             let indiceFotos = $scope.fotos.indexOf(foto);
    //             $scope.fotos.splice(indiceFotos, 1);
    //             console.log('Foto ' + foto.titulo + ' apagada com sucesso');
    //             $scope.mensagem = 'Foto ' + foto.titulo + ' apagada com sucesso';
    //         })
    //         .error(function (erro) {
    //             console.log(erro);
    //             console.log('Não foi possível remover a foto ' + foto.titulo);
    //             $scope.mensagem = 'Não foi possível remover a foto ' + foto.titulo;
    //         });
    // }
});