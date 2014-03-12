'use strict';

/* Controllers */

angular.module('myApp.controllers', ['ui.bootstrap']).
  controller('ProductsCtrl', ['$scope', "$modal", 'Products', function ($scope, $modal, Products) {
      Products.getProducts().then(function (products) {
          $scope.products = products;
      });;

      $scope.addProduct = function () {
          var modalInstance = $modal.open({
              templateUrl: '/Scripts/app/partials/addProduct.html',
              controller: 'AddProductCtrl'
          });

          modalInstance.result.then(function (item) {
              $scope.products.push(item);
          })
      }
  }])
.controller("AddProductCtrl", ["$scope", "$modalInstance", "Products", function ($scope, $modalInstance, Products) {
    $scope.save = function (product, form) {
        $scope.submitted = true;
        console.log(form);
        if (form.$valid) {
            var newProd = Products.addProduct(product);
            $modalInstance.close(newProd);
        }


    }
    $scope.cancel = function () {
        $modalInstance.close("hide");
    }
}]);
