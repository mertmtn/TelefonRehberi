var app = angular.module('myApp', []);

app.controller('myControllerPersonel', function ($scope, $http) {
    $http.get("/Admin/getPersonelList/").then(
       function (response) {
           $scope.personelList = response.data;
       });
    $http.get("/Admin/getDepartmanList/").then(
       function (response) {
           $scope.departmanList = response.data;
       });
});