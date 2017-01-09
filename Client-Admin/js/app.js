/**
 * Created by asus on 1/2/2017.
 */

var routerApp = angular.module('routerApp', ['ui.router', 'ngFileUpload', 'angular-cloudinary']);

routerApp.config(function($stateProvider, $urlRouterProvider, $locationProvider) {

    $urlRouterProvider.otherwise('/home');

    $stateProvider
        .state('login', {
            url:'/' ,
            templateUrl: 'login.html',
            Controller: ''
        })
        .state('home', {
            url:'/home' ,
            templateUrl: 'clothing.html',
            Controller: 'MyCtrl'
        })
        .state('chitietsp', {
            url:'/chitietsp' ,
            templateUrl: 'chitietsanpham.html',
            Controller: 'MyCtrl'
        })
        .state('sanpham', {
            url:'/sanpham' ,
            templateUrl: 'clothing.html',
            Controller: 'MyCtrl'
        })
        // .state('clothingmain', {
        //     url:'/sanpham' ,
        //     templateUrl: 'clothing.html',
        //     Controller: 'MyCtrl'
        // })
        .state('themmoi', {
            url:'/sanpham/themmoi' ,
            templateUrl: 'themmoi.html',
            Controller: 'MyCtrl'
        })
        .state('chitet', {
            url:'/sanpham/chitiet' ,
            templateUrl: 'chitietsanpham.html'
        })
        .state('order', {
            url:'/hoadon' ,
            templateUrl: 'order.html',
            Controller: 'HoaDonCtrl'
        })
        .state('error', {
            url: '/404',
            templateUrl: 'error-404.html'
        });
});

routerApp.controller('UpLoadCtrl', function ($scope,$http, cloudinary, $timeout) {
    $scope.uploadFiles =  function (file, errFiles) {
        $scope.f1 = file;
        $scope.errFile1 = errFiles && errFiles[0];
        if (file) {

            file.upload = cloudinary.upload(file, { /* cloudinary options here */ }).then(function (resp) {
                //alert('all done!');
                console.log(resp);
                $scope.url1 = resp.data.url;

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
