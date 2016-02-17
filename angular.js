var app = angular.module('myApp', []);

app.controller('library', function($scope, $http)
{
		$http.get('http://localhost:32520/api/movies')
		.success(function (response) {
			$scope.movies = response;
			
		});
	
		function getDataInner(){
			$http.get('http://localhost:32520/api/movies/'+$scope.search)
				.success(function (response) {
					$scope.specificMovie = response;
				});
		};
	
		$scope.getData = getDataInner;
	
		$http.get('http://localhost:32520/api/genres')
		.success(function (response) {
			$scope.genres = response;
			
		});
		
		$http.get('http://localhost:32520/api/directors')
		.success(function (response) {
			$scope.directors = response;
			
		});
	
		$http.get('http://localhost:32520/api/languages')
		.success(function (response) {
			$scope.languages = response;
			
		});

});
