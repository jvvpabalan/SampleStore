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
          //open bootstrap modal then pass controller and template
          var modalInstance = $modal.open({
              templateUrl: '/Scripts/app/partials/addProduct.html',
              controller: 'AddProductCtrl'
          });

          //add product to products model after closing the modal
          modalInstance.result.then(function (item) {
              if (item !== undefined) {
                  console.log(item);
                  $scope.products.push(item);
              }
          })
      }

      //Show edit product form
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

      $scope.cancelEdit = function () {
          $scope.productToRemove = null;
      }


      $scope.deleteProduct = function (product, index) {
          var modalInstance = $modal.open({
              templateUrl: '/Scripts/app/partials/deleteProduct.html',
              controller: 'RemoveProductCtrl',
              resolve: {
                  productToRemove: function () {
                      return product;
                  },

                  productIndex: function () {
                      return index;
                  }
              }

          });

          modalInstance.result.then(function (item) {
              $scope.products.splice(item, 1);

          });

      }
  }])
.controller("AddProductCtrl", ["$scope", "$modalInstance", "Products", function ($scope, $modalInstance, Products) {
    $scope.save = function (product, form) {
        $scope.submitted = true;
     
        if (form.$valid) {
            var newProd = Products.addProduct(product);
            $modalInstance.close(newProd);
        }

    }
    $scope.cancel = function () {
        $modalInstance.close();
    }
}])
.controller("RemoveProductCtrl", ["$scope", "$modalInstance", "Products", "productToRemove", "productIndex",
    function ($scope, $modalInstance, Products, productToRemove, productIndex) {
        $scope.product = productToRemove;
        console.log(productIndex);
        $scope.delete = function (product) {
            Products.removeProduct({ Id: product.Id });
            $modalInstance.close(productIndex);
        }
        $scope.cancel = function () {
            $modalInstance.close();
        }

}]);
