/**
 * Created by asus on 1/2/2017.
 */
var routerApp = angular.module('routerApp', ['ui.router']);

routerApp.config(function($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/home');


    $stateProvider
        .state('home', {
            url:'/home' ,
            templateUrl: 'clothing.html',
            Controller: 'MyController'
        })
        .state('clothing', {
            url:'/clothing' ,
            templateUrl: 'clothing.html',
            Controller: 'MyController',
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
        .state('danhsach', {
            url: '/danhsach',
            templateUrl: 'danhsach.html'
        });
});

routerApp.run(runBlock);
function runBlock(PermissionStore, $q) {
    PermissionStore.definePermission('ADMIN', function(stateParams) {
        return true;
    });

};

routerApp.controller('MyController', function ($scope, $http) {
    $http.get("https://private-167575-test10548.apiary-mock.com/mathang")
        .then(function(response) {
            $scope.myWelcome = response.data;
        });
});