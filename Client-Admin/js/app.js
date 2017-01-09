/**
 * Created by asus on 1/2/2017.
 */

var routerApp = angular.module('routerApp', ['ui.router', 'ngFileUpload', 'angular-cloudinary', 'LocalStorageModule']);
routerApp.constant('AUTH_EVENTS', {
        notAuthenticated: 'auth-not-authenticated'
    })
routerApp.constant('API_ENDPOINT', {
        url: 'http://localhost:57919/'
        //  For a simulator use: url: 'http://127.0.0.1:8080/api'
    });


routerApp.config(function($stateProvider, $urlRouterProvider, $locationProvider, $httpProvider) {

    $urlRouterProvider.otherwise('/home');

    $stateProvider
        .state('login', {
            url:'/' ,
            templateUrl: 'login.html',

        });
    $stateProvider   .state('home', {
            url:'/home' ,
            templateUrl: 'clothing.html',

        });
    $stateProvider   .state('chitietsp', {
            url:'/chitietsp' ,
            templateUrl: 'chitietsanpham.html',

        });
    $stateProvider  .state('sanpham', {
            url:'/sanpham' ,
            templateUrl: 'clothing.html',

        });
        // .state('clothingmain', {
        //     url:'/sanpham' ,
        //     templateUrl: 'clothing.html',
        //     Controller: 'MyCtrl'
        // })
    $stateProvider   .state('themmoi', {
            url:'/sanpham/themmoi' ,
            templateUrl: 'themmoi.html',

        });
    $stateProvider   .state('chitet', {
            url:'/sanpham/chitiet' ,
            templateUrl: 'chitietsanpham.html'
        });
    $stateProvider  .state('order', {
            url:'/hoadon' ,
            templateUrl: 'order.html',
            Controller: 'HoaDonCtrl'
        });
    $stateProvider  .state('error', {
            url: '/404',
            templateUrl: 'error-404.html'
        });
});

routerApp.controller('UpLoadCtrl', function ($scope,$http, cloudinary, $timeout, AuthService) {
    $scope.uploadFiles1 =  function (file, errFiles) {
        $scope.f1 = file;
        $scope.errFile1 = errFiles && errFiles[0];
        if (file) {
            AuthService.notUseAuthorizationHeaders();
            file.upload = cloudinary.upload(file, { /* cloudinary options here */ }).then(function (resp) {
                //alert('all done!');
                console.log(resp);
                $scope.url1 = resp.data.url;
                AuthService.useAuthorizationHeaders();
                $timeout(function () {
                    file.result = resp.data;
                });
            }, function (resp) {
                // if (resp.status > 0)
                // $scope.errorMsg1 = resp.status + ': ' + 'Loại file không hỗ trợ';
            }, function (evt) {
                file.progress = Math.min(100, parseInt(100.0 *
                    evt.loaded / evt.total));
            });
        }
    };
    $scope.uploadFiles2 =  function (file, errFiles) {
        $scope.f1 = file;
        $scope.errFile1 = errFiles && errFiles[0];
        if (file) {
            AuthService.notUseAuthorizationHeaders();
            file.upload = cloudinary.upload(file, { /* cloudinary options here */ }).then(function (resp) {
                //alert('all done!');
                console.log(resp);
                $scope.url2 = resp.data.url;
                AuthService.useAuthorizationHeaders();
                $timeout(function () {
                    file.result = resp.data;
                });
            }, function (resp) {
                // if (resp.status > 0)
                // $scope.errorMsg1 = resp.status + ': ' + 'Loại file không hỗ trợ';
            }, function (evt) {
                file.progress = Math.min(100, parseInt(100.0 *
                    evt.loaded / evt.total));
            });
        }
    };
    $scope.uploadFiles3 =  function (file, errFiles) {
        $scope.f1 = file;
        $scope.errFile1 = errFiles && errFiles[0];
        if (file) {
            AuthService.notUseAuthorizationHeaders();
            file.upload = cloudinary.upload(file, { /* cloudinary options here */ }).then(function (resp) {
                //alert('all done!');
                console.log(resp);
                $scope.url3 = resp.data.url;
                AuthService.useAuthorizationHeaders();
                $timeout(function () {
                    file.result = resp.data;
                });
            }, function (resp) {
                // if (resp.status > 0)
                // $scope.errorMsg1 = resp.status + ': ' + 'Loại file không hỗ trợ';
            }, function (evt) {
                file.progress = Math.min(100, parseInt(100.0 *
                    evt.loaded / evt.total));
            });
        }
    };
});

routerApp.controller('MyCtrl', function ($scope,$http, cloudinary, $timeout, $stateParams) {
    // $http.get("http://apishoponline.apphb.com/api/Server/getsp")
    //     .then(function(response) {
    //         $scope.test = "Nam"
    //         $scope.myWelcome = response.data;
    //     });


});

routerApp.config(['cloudinaryProvider', function (cloudinaryProvider) {
    cloudinaryProvider.config({
        upload_endpoint: 	'https://api.cloudinary.com/v1_1/' ,
        cloud_name: 'shoponlineimage',
        upload_preset: 'bfa8vkr6'
    });
}]);


routerApp.controller('HoaDonCtrl', function ($scope, $http) {
    // $http.get("http://apishoponline.apphb.com/api/Server/hoadon")
    //     .then(function(response) {
    //         $scope.hoadon = response.data;
    //     });
});

routerApp.controller('LoginCtrl', function ($scope, AuthService, $window, $state) {
    $scope.user = {
        username: '',
        password: '',
        grant_type: 'password',
        client_id: ''
    }
    console.log($scope.user);
    $scope.login = function () {
        AuthService.login($scope.user).then(function () {
            window.sessionStorage.setItem('username', $scope.user.username);
           $window.location.href = '/Client-Admin/#/home';
        }, function (errMg) {
            $window.alert("Tên đăng nhập không chính xác");

        });
    };
});

routerApp.run(function ($rootScope, $state, AuthService, AUTH_EVENTS, $location) {
    $rootScope.$on('$stateChangeStart', function (event, next, nextParams, fromState) {
        if (!AuthService.isAuthenticated()){
            console.log(next.name);
            if (next.name !== 'login'){
                event.preventDefault();
                $state.go('login');
            }
        }
    })
});