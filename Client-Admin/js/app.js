/**
 * Created by asus on 1/2/2017.
 */

var routerApp = angular.module('routerApp', ['ui.router', 'ngFileUpload', 'cloudinary']);

routerApp.config(function($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/error');

    $stateProvider
        .state('home', {
            url:'/home' ,
            templateUrl: 'clothing.html',
            Controller: 'MyCtrl'
        })
        .state('clothing', {
            url:'/clothing' ,
            templateUrl: 'clothing.html',
            Controller: 'MyCtrl',
            ata: {
                permissions: {
                    only: 'ADMIN',
                    redirectTo: 'order'
                }
            }
        })
        .state('order', {
            url:'/order' ,
            templateUrl: 'order.html',
            Controller: ''
        })
        .state('error', {
            url: '/error',
            templateUrl: 'error-404.html'
        })
        .state('danhsach', {
            url: '/danhsach',
            templateUrl: 'danhsach.html'
        });
});

routerApp.controller('MyCtrl', function ($scope,$http) {
    $http.get("https://private-167575-test10548.apiary-mock.com/mathang")

        .then(function(response) {
            $scope.myWelcome = response.data;
        });

});


routerApp.controller('MyController', function ($scope, $http) {
    $http.get("https://private-167575-test10548.apiary-mock.com/mathang")
        .then(function(response) {
            $scope.myWelcome = response.data;
        });
});
