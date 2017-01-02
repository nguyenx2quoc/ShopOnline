/**
 * Created by asus on 12/20/2016.
 */

var routerApp = angular.module('routerApp', ['ui.router']);

routerApp.config(function($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/home');

    $stateProvider
        .state('women', {
            url: '/women',
            templateUrl: 'women.html',
            controller: 'WomenController'
        });
    $stateProvider   .state('register', {
            url: '/register',
            templateUrl: 'register.html'
        });
    $stateProvider   .state('checkout', {
            url: '/checkout',
            templateUrl: 'checkout.html'
        })
    $stateProvider.state('details', {
            url: '/details',
            templateUrl: 'details.html',

        });
    $stateProvider   .state('contact', {
            url: '/contact',
            templateUrl: 'contact.html'
        })
});

routerApp.controller('WomenController',['$scope', '$http', function ($scope, $http) {

}]);

routerApp.controller('DetailController',['$scope', '$http', function ($scope, $http) {

}]);