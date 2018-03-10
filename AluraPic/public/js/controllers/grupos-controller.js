angular.module('alurapic').controller('gruposController', function ($scope, $http) {
    $scope.grupos= [];

    $http.get('v1/grupos')
    .success(function (grupos) {
        $scope.grupos = grupos;
    })
    .error(function (erro) {
        console.log(erro);
        
    });
});