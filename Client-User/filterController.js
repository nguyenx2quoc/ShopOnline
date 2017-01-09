var filCtrl = angular.module('filCtrl', []);

filCtrl.controller('filCtrltype', ['$scope','$http','$stateParams', function($scope,$http,$stateParams){
	$scope.nam = "nam";
	$scope.nu = "nu";
	$scope.namquan = "namquan";
	$scope.namao = "namao";
	$scope.nuquan = "nuquan";
	$scope.nuao = "nuao";
	$scope.dam = "dam";
	$scope.quan = "quan";
	$scope.ao = "ao";
	$scope.tatca = "tatca";
	$scope.type = $stateParams.type;
	$scope.showtype = "";
	$scope.listitems = [];
	if($scope.type == "tatca")
	{
		$http.get("http://apishoponline.apphb.com/api/Server/getallctmh")
		.then(function(response) {
        $scope.listitems.push(response.data);
      });
		$scope.showtype = "Tất cả";
	}
	if($scope.type == "nam")
	{
		$http.get("http://apishoponline.apphb.com/api/Server/getsptheogt?GT="+$scope.type)
		.then(function(response) {
        $scope.listitems.push(response.data);
      });
		$scope.showtype = "Nam";
	}
	if($scope.type == "nu")
	{
		$http.get("http://apishoponline.apphb.com/api/Server/getsptheogt?GT="+ "nữ")
		.then(function(response) {
        $scope.listitems.push(response.data);
      });
		$scope.showtype = "Nữ";
	}
	if($scope.type == "namquan")
	{
		$http.get("http://apishoponline.apphb.com/api/Server/getspnam?LH="+ "quần")
		.then(function(response) {
        $scope.listitems.push(response.data);
      });
		$scope.showtype = "Quần Nam";
	}
	if($scope.type == "nuquan")
	{
		$http.get("http://apishoponline.apphb.com/api/Server/getspnu?LH="+ "quần")
		.then(function(response) {
        $scope.listitems.push(response.data);
      });
		$scope.showtype = "Quần Nữ";
	}
	if($scope.type == "namao")
	{
		$http.get("http://apishoponline.apphb.com/api/Server/getspnam?LH="+ "áo")
		.then(function(response) {
        $scope.listitems.push(response.data);
      });
		$scope.showtype = "Áo Nam";
	}
	if($scope.type == "nuao")
	{
		$http.get("http://apishoponline.apphb.com/api/Server/getspnu?LH="+ "áo")
		.then(function(response) {
        $scope.listitems.push(response.data);
      });
		$scope.showtype = "Áo Nữ";
	}
	if($scope.type == "namdam")
	{
		$http.get("http://apishoponline.apphb.com/api/Server/getspnam?LH="+ "đầm")
		.then(function(response) {
        $scope.listitems.push(response.data);
      });
		$scope.showtype = "Đầm Nam";
	}
	if($scope.type == "nudam")
	{
		$http.get("http://apishoponline.apphb.com/api/Server/getspnu?LH="+ "đầm")
		.then(function(response) {
        $scope.listitems.push(response.data);
      });
		$scope.showtype = "Đầm Nữ";
	}
	if($scope.type == "dam")
	{
		$http.get("http://apishoponline.apphb.com/api/Server/getsptheoloai?LH="+ "đầm")
		.then(function(response) {
        $scope.listitems.push(response.data);
      });
		$scope.showtype = "Đầm";
		$scope.model = {type:"dam"};
	}
	if($scope.type == "quan")
	{
		$http.get("http://apishoponline.apphb.com/api/Server/getsptheoloai?LH="+ "quần")
		.then(function(response) {
        $scope.listitems.push(response.data);
      });
		$scope.showtype = "Quần";
		$scope.model = {type:"quan"};
	}
	if($scope.type == "ao")
	{
		$http.get("http://apishoponline.apphb.com/api/Server/getsptheoloai?LH="+ "áo")
		.then(function(response) {
        $scope.listitems.push(response.data);
      });
		$scope.showtype = "Áo";
		$scope.model = {type:"ao"};
	}
	}]);

filCtrl.controller('filCtrlid', ['$scope','$http','$stateParams', function($scope,$http,$stateParams){
	$scope.nam = "nam";
	$scope.nu = "nu";
	$scope.namquan = "namquan";
	$scope.namao = "namao";
	$scope.nuquan = "nuquan";
	$scope.nuao = "nuao";
	$scope.dam = "dam";
	$scope.quan = "quan";
	$scope.ao = "ao";
	$scope.tatca = "tatca";
	$scope.id = $stateParams.id;
	$scope.listitems = [];
	$http.get("http://apishoponline.apphb.com/api/Server/getctmh?IDMH=" + $scope.id)
		.then(function(response) {
        $scope.listitems.push(response.data);
      });
	
	}]);