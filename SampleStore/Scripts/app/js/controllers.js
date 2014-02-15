'use strict';

/* Controllers */

angular.module('myApp.controllers', []).
  controller('ProductsCtrl', ['$scope', 'Products', function($scope, Products) {
      $scope.products = Products.getProducts();
  }])
  .controller('MyCtrl2', [function() {

  }]);