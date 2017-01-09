var detailCtrl = angular.module('detailCtrl', []);
detailCtrl.controller('detailCtrl', ['$scope','$http','$stateParams', function($scope, $http,$stateParams){
	$scope.listitems = [];
	$scope.id = $stateParams.id;
	$http.get("http://apishoponline.apphb.com/api/Server/getctmhtheoid?IDCTMH=" + $scope.id)
	.then(function(response) {
        $scope.listitems.push(response.data);
      });
}]);