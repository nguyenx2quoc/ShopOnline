var checkCtrl = angular.module('checkCtrl', []);
checkCtrl.controller('checkCtrl', ['$scope','$http','$stateParams', function($scope, $http,$stateParams){
	$scope.listitems = [];
	$scope.total;
	$scope.idct;
	$scope.user = {diachi: '', dienthoai: ''};
	$scope.id = $stateParams.id;
	$http.get("http://apishoponline.apphb.com/api/Server/getctmhtheoid?IDCTMH=" + $scope.id)
	.then(function(response) {
        $scope.listitems = response.data;
        $scope.total = parseInt($scope.listitems[0].Gia,10) + 30000;
        $scope.idct = parseInt($scope.listitems[0].IDCT,10);
      });
	
	$scope.mua = function(){
		var parameter = JSON.stringify({
  			  	"H_Email": $scope.user.diachi,
    			"H_SDT": $scope.user.dienthoai,
    			"H_TongTien": $scope.total,
    			"C_IDCTMH":$scope.idct
				 });
			 $http.post('http://apishoponline.apphb.com/api/Server/themhoadon', parameter).
   				 success(function(data, status, headers, config) {
       				swal("Online Shop!", "Cảm ơn bạn đã mua hàng!", "success");
     			 }).
     		 	error(function(data, status, headers, config) {
       				swal("Online Shop!", "Lỗi!", "success");
      			});


	};
	
}]);