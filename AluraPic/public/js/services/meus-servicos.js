angular.module('meusServicos', ['ngResource'])
    .factory('recursoFoto', function ($resource) {
        return $resource('v1/fotos/:fotoId', null, {
            update: {
                method: 'PUT'
            }
        });
    })
    .factory('cadastroDeFotos', function (recursoFoto, $q, $rootScope) {
        let servico = {};
        let evento = 'fotoCadastrada';
        servico.cadastrar = function (foto) {
            return $q(function (resolve, reject) {
                if (foto._id) {
                    recursoFoto.update({
                        fotoId: foto._id
                    }, foto, function (dados) {
                        $rootScope.$broadcast(evento);
                        resolve({
                            mensagem: 'Foto ' + foto.titulo + ' atualizada com sucesso',
                            inclusao: false
                        });
                    }, function (erro) {
                        console.log(erro);
                        reject('Não foi possível alterar a foto ' + foto.titulo);
                    });
                } else {
                    recursoFoto.save(foto, function (dados) {
                        $rootScope.$broadcast(evento);
                        resolve({
                            mensagem: 'Foto ' + foto.titulo + ' incluída com sucesso',
                            inclusao: true
                        })
                    }, function (erro) {
                        console.log(erro);
                        reject('Não foi possível alterar a foto ' + foto.titulo);
                    });

                }
            });
        };
        return servico;
    });