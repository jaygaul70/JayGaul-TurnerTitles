/// reference path <"angular.js"/>

var app = angular.module('MovieModule', []);
app.controller('MovieController', function ($scope, $http) {

    GetStoryTypes();

    function GetStoryTypes() {
        alert('getstorytypes');
        var titleid = $scope.titleId;
        var urll = '/Title/GetStoryTypes/' + titleid;
        if (titleid) {
            $http({
                method: 'GET',
                url: urll
            }).success(function (data, status, headers, config) {
                $scope.storytypes = data;
            }).error(function (data, status, headers, config) {
                $scope.message = 'unexpected error';
            });
        }
        else {
            $scope.storytypes = null;
        }
    }

    $scope.GetStory = function () {
        var storyId = $scope.storytype;
        if (storyId) {
            $http({
                method: 'POST',
                url: '/Title/GetStoryline',
                data: JSON.stringify({ storyId: storyId })
            }).success(function (data, status, headers, config) {
                $scope.storyline = data;
            }).error(function (data, status, headers, config) {
                $scope.message = 'unexpected error';
            });
        }
        else {
            $scope.storyline = null;
        }
    }

    $scope.GetStoryline = function () {
        var storyId = $scope.storytypeng;
        if (storyId) {
            $http({
                method: 'POST',
                url: '/Title/GetStoryline',
                data: JSON.stringify({ storyId: storyId })
            }).success(function (data, status, headers, config) {
                $scope.storyline = data;
            }).error(function (data, status, headers, config) {
                $scope.message = 'unexpected error';
            });
        }
        else {
            $scope.storyline = null;
        }
    }

});