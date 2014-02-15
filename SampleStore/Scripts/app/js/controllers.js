'use strict';

/* Controllers */

angular.module('myApp.controllers', []).
  controller('ProductsCtrl', ['$scope', function($scope) {
      $scope.products = [{ Name: "Playstation 4", Category: "Gaming", Price: 399.00 }];
  }])
  .controller('MyCtrl2', [function() {

  }]);