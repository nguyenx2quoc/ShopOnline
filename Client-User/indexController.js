var indexCtrl = angular.module('indexCtrl', []);

indexCtrl.controller('indexCtrl', ['$scope','$http','$stateParams', function($scope,$http,$stateParams){
	$scope.nam = "nam";
	$scope.nu = "nu";
	$scope.namquan = "namquan";
	$scope.namao = "namao";
	$scope.nuquan = "nuquan";
	$scope.nuao = "nuao";
	$scope.dam = "dam";
	}]);