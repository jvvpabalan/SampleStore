'use strict';

/* Controllers */

angular.module('myApp.controllers', ['ui.bootstrap']).
  controller('ProductsCtrl', ['$scope', "$modal", 'Products', function ($scope, $modal, Products) {

      $scope.productToEdit = null;
      $scope.editUrl = "/Scripts/app/partials/editProduct.html"
      Products.getProducts().then(function (products) {
          $scope.products = products;
      });;

      $scope.addProduct = function () {
          var modalInstance = $modal.open({
              templateUrl: '/Scripts/app/partials/addProduct.html',
              controller: 'AddProductCtrl'
          });

          modalInstance.result.then(function (item) {
              if (item !== undefined) {
                  console.log(item);
                  $scope.products.push(item);
              }
          })
      }

      $scope.editProduct = function (product) {
          $scope.productToEdit = product;
      }

      $scope.saveEdit = function (product, form) {
          //Update form if valid
          if (form.$valid) {
              var newProduct = Products.update(product);
              $scope.productToEdit = null;
          }
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
        $modalInstance.close();
    }
}]);
