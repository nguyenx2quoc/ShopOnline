var homeCtrl = angular.module('homeCtrl', []);
homeCtrl.controller('homeCtrl', ['$scope','$http', function($scope, $http){
	$scope.listitems = [];
	$http.get("http://apishoponline.apphb.com/api/Server/getsp")
	.then(function(response) {
        $scope.listitems.push(response.data);
      });
}]);