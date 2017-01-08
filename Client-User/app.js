/**
 * Created by asus on 12/20/2016.
 */

 angular.module('myApp', ['ui.router','homeCtrl','filCtrl','indexCtrl']);

//var routerApp = angular.module('routerApp', ['ui.router']);

angular.module('myApp').config(function($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/home');

   
     $stateProvider
        .state('filtertype', {
            url: '/filtertype/:type',
            templateUrl: 'filter.html',
        });
       
    $stateProvider   .state('register', {
            url: '/register',
            templateUrl: 'register.html'
        });

      $stateProvider   .state('home', {
            url: '/home',
            templateUrl: 'home.html'
        });
    $stateProvider   .state('checkout', {
            url: '/checkout',
            templateUrl: 'checkout.html'
        })
    $stateProvider.state('details', {
            url: '/details/:id',
            templateUrl: 'details.html',

        });
    $stateProvider   .state('contact', {
            url: '/contact',
            templateUrl: 'contact.html'
        })
});
