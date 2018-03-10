angular.module('alurapic').controller('FotoController', function ($scope, recursoFoto, $resource, $routeParams, cadastroDeFotos) {
    $scope.foto = {};
    $scope.mensagem = '';


    if ($routeParams.fotoId) {
        recursoFoto.get({
            fotoId: $routeParams.fotoId
        }, function (foto) {
            if (!foto) {
                $scope.mensagem = 'Foto de ID ' + $routeParams.fotoId + ' não encontrada!';
            }

            $scope.foto = foto;
        }, function (erro) {
            console.log(erro);
            $scope.mensagem = 'Foto de ID ' + $routeParams.fotoId + ' não encontrada!';
        });
    }
    //     $http.get('v1/fotos/' + $routeParams.fotoId)
    //         .success(function (foto) {
    //             if (!foto) {
    //                 $scope.mensagem = 'Foto de ID ' + $routeParams.fotoId + ' não encontrada!';
    //             }

    //             $scope.foto = foto;
    //         })
    //         .error(function (erro) {
    //             console.log(erro);
    //             $scope.mensagem = 'Foto de ID ' + $routeParams.fotoId + ' não encontrada!';
    //         });
    // }

    $scope.submeter = function () {
        if ($scope.formulario.$valid) {
            console.log($scope.foto);
            cadastroDeFotos.cadastrar($scope.foto)
                .then(function (dados) {
                    $scope.mensagem = dados.mensagem;
                    if (dados.inclusao) $scope.foto = {};
                })
                .catch(function (dados) {
                    $scope.mensagem = dados;
                });

            // if ($scope.foto._id) {
            //     recursoFoto.update({
            //         fotoId: $scope.foto._id
            //     }, $scope.foto, function (foto) {
            //         $scope.mensagem = 'Foto alterada com sucesso';
            //     }, function (erro) {
            //         $scope.mensagem = 'Não foi possível alterar foto';
            //         console.log(error);
            //     });
            //     // $http.put('v1/fotos/' + $scope.foto._id, $scope.foto)
            //     //     .success(function (foto) {
            //     //         $scope.mensagem = 'Foto alterada com sucesso';
            //     //     })
            //     //     .error(function (erro) {
            //     //         $scope.mensagem = 'Não foi possível alterar foto';
            //     //         console.log(error);
            //     //     });
            // } else {
            //     recursoFoto.post($scope.foto, function (dados) {
            //         $scope.foto = {};
            //         $scope.mensagem = 'Foto cadastrada com sucesso';
            //     }, function (error) {
            //         $scope.mensagem = 'Não foi possível cadastrar foto';
            //         console.log(error);
            //     });
            //     // $http.post('v1/fotos', $scope.foto)
            //     //     .success(function (dados) {
            //     //         $scope.foto = {};
            //     //         $scope.mensagem = 'Foto cadastrada com sucesso';
            //     //     }).error(function (error) {
            //     //         $scope.mensagem = 'Não foi possível cadastrar foto';
            //     //         console.log(error);
            //     //     });
            // }
        }
    };
});