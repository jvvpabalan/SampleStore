'use strict';

/* Controllers */

angular.module('myApp.controllers', []).
  controller('ProductsCtrl', ['$scope', 'Products', function($scope, Products) {
      Products.getProducts().then(function (products) {
          $scope.products = products;
      });;
  }])
  .controller('MyCtrl2', [function() {

  }]);