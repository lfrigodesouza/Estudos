angular.module('alurapic', ['minhasDiretivas', 'ngAnimate', 'ngRoute', 'meusServicos'])
    .config(function ($routeProvider, $locationProvider) {

        $locationProvider.html5Mode(true);

        $routeProvider.when('/fotos', {
            templateUrl: 'partials/principal.html',
            controller: 'FotosController',
        });
        $routeProvider.when('/', {
            templateUrl: 'partials/principal.html',
            controller: 'FotosController',
        });

        $routeProvider.when('/fotos/new', {
            templateUrl: 'partials/foto.html',
            controller: 'FotoController',
        });

        $routeProvider.when('/404', {
            templateUrl: 'partials/404.html',
        });

        $routeProvider.otherwise({
            redirectTo: '/404'
        });

        $routeProvider.when('/fotos/edit/:fotoId', {
            templateUrl: 'partials/foto.html',
            controller: 'FotoController',
        });
    });