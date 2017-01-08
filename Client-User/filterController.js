var filCtrl = angular.module('filCtrl', []);

filCtrl.controller('filCtrltype', ['$scope','$http','$stateParams', function($scope,$http,$stateParams){
	$scope.type = $stateParams.type;
	$scope.listitems = [];
	if($scope.type == "nam")
	{
		$http.get("http://apishoponline.apphb.com/api/Server/getsptheogt?GT="+$scope.type)
		.then(function(response) {
        $scope.listitems.push(response.data);
      });
	}
	if($scope.type == "nu")
	{
		$http.get("http://apishoponline.apphb.com/api/Server/getsptheogt?GT="+ "nữ")
		.then(function(response) {
        $scope.listitems.push(response.data);
      });
	}
	}]);