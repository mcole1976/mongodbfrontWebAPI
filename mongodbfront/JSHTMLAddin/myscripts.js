
var app = angular.module("myApp", []);

var headers = new Headers();
headers.append('Access-Control-Allow-Origin', '*');



app.controller("myCtrl", function($scope, $http) {
    $http.get('https://localhost:44377/api/logs',headers)
    .then(function (response) {
    //Console.Log(response.data);
    $scope.results = [];
    $scope.myWelcome = response.data

    $scope.items = response.data;

    // response.data.forEach($scope.items, function (item) {
    //   $scope.results.push({
    //     meal: item.meal,
    //     calorie_Count: item.calorie_Count,
    //     meal_Description: item.meal_Description, 
    //     date: item.date
    // });
    // })


    // angular.forEach($scope.items, function(item) {
    //   $scope.results.push({
    //     meal: item.meal,
    //     calorie_Count: item.calorie_Count,
    //     meal_Description: item.meal_Description, 
    //     date: item.date})
    // });

    $scope.items.forEach((item) => {
      console.log(item.meal);

        
      $scope.results.push({
        meal: item.meal,
        calorie_Count: item.calorie_Count,
        meal_Description: item.meal_Description, 
        date: item.date
      });
    });


  });


  $scope.firstName = "John";
  $scope.lastName = "Doe";
});