/**
 * Created by asus on 12/20/2016.
 */

var routerApp = angular.module('routerApp', ['ui.router']);

routerApp.config(function($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/home');

    $stateProvider
        .state('women', {
            url: '/women',
            templateUrl: 'women.html'
        })
        .state('register', {
            url: '/register',
            templateUrl: 'register.html'
        })
        .state('checkout', {
            url: '/checkout',
            templateUrl: 'checkout.html'
        })
        .state('details', {
            url: '/details',
            templateUrl: 'details.html'
        })
        .state('contact', {
            url: '/contact',
            templateUrl: 'contact.html'
        })
});
